using System.IO;
using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using LibHac.NSZ;
using NSW.Core.Enums;
using NSW.Core.Services;
using Path = System.IO.Path;

namespace NSW.M2.Services;

public sealed class NspMergeService(string keysPath)
{
    public string Merge(BuildRequest req, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var libHacKeySet = ExternalKeyReader.ReadKeyFile(keysPath);
        return RunMergeProcess(req, libHacKeySet, progress, log, ct);
    }

    public static string RunMergeProcess(BuildRequest req, KeySet libHacKeySet, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var builder = new PartitionFileSystemBuilder();
        var disposables = new List<IDisposable>();
        var tempFiles = new List<string>();

        try
        {
            log?.Invoke("━━ 메타데이터 통합 분석 중... ━━", LogLevel.Info);
            var allPaths = new List<string>();
            if (!string.IsNullOrEmpty(req.UpdateFilePath)) allPaths.Add(req.UpdateFilePath);
            foreach (var p in req.DlcFilePaths) if (!allPaths.Contains(p)) allPaths.Add(p);
            if (!allPaths.Contains(req.BaseFilePath)) allPaths.Add(req.BaseFilePath);

            var meta = Utils.ExtractAggregateMetadata(libHacKeySet, allPaths, req.UpdateFilePath);
            log?.Invoke($"최종 ID: [{meta.TitleId}] 버전: {meta.DisplayVersion}", LogLevel.Ok);

            log?.Invoke("━━ Super NSP 병합 시작 ━━", LogLevel.Info);

            foreach (var path in allPaths)
            {
                if (string.IsNullOrEmpty(path) || !File.Exists(path)) continue;

                var storage = new LocalStorage(path, FileAccess.Read);
                disposables.Add(storage);

                IFileSystem fs;
                string ext = Path.GetExtension(path).ToLower();
                if (ext is ".xci" or ".xcz")
                {
                    var xci = new Xci(libHacKeySet, storage);
                    fs = xci.OpenPartition(XciPartitionType.Secure);
                }
                else
                {
                    var pfs = new PartitionFileSystem();
                    pfs.Initialize(storage).ThrowIfFailure();
                    fs = pfs;
                }
                disposables.Add(fs);

                foreach (var entry in fs.EnumerateEntries("/", "*"))
                {
                    var file = new UniqueRef<IFile>();
                    if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
                    {
                        file.Get.GetSize(out long size).ThrowIfFailure();
                        if (size == 0) continue;

                        string finalName = entry.Name;
                        IFile rawFile = file.Release();
                        disposables.Add(rawFile);

                        IStorage currentStorage = new FileStorage(rawFile);
                        disposables.Add(currentStorage);

                        if (Path.GetExtension(entry.Name).Equals(".ncz", StringComparison.CurrentCultureIgnoreCase))
                        {
                            var ncz = new Ncz(libHacKeySet, currentStorage.AsStream(), NczReadMode.Original);
                            currentStorage = ncz.BaseStorage;
                            finalName = Path.ChangeExtension(entry.Name, ".nca");
                        }
                        else if (Path.GetExtension(entry.Name).Equals(".nca", StringComparison.CurrentCultureIgnoreCase) && req.CompressToNcz)
                        {
                            var nca = new Nca(libHacKeySet, currentStorage);
                            if (nca.Header.ContentType is NcaContentType.Program or NcaContentType.PublicData)
                            {
                                string tempPath = Path.Combine(req.OutputDir, $"{Guid.NewGuid()}.tmp");
                                var fsTemp = File.Open(tempPath, FileMode.Create, FileAccess.ReadWrite);

                                NcaToNczConverter.Convert(currentStorage.AsStream(), fsTemp, libHacKeySet, req.NczCompressionLevel);

                                fsTemp.Position = 0;
                                currentStorage = fsTemp.AsStorage();

                                disposables.Add(fsTemp);
                                tempFiles.Add(tempPath);
                                finalName = Path.ChangeExtension(entry.Name, ".ncz");
                                log?.Invoke($"  [압축 완료] {finalName}", LogLevel.Ok);
                            }
                        }

                        builder.AddFile(finalName, currentStorage.AsFile(OpenMode.Read));
                    }
                }
            }

            string finalFileName = NspFileNameBuilder.Build("Merged", meta.KrTitle, meta.EnTitle, meta.TitleId, meta.DisplayVersion, meta.TitleVersion, meta.DlcCount);
            string finalPath = Path.Combine(req.OutputDir, finalFileName);

            using var nspStorage = builder.Build(PartitionFileSystemType.Standard);
            using (var fout = File.Open(finalPath, FileMode.Create, FileAccess.Write))
            {
                nspStorage.GetSize(out long totalSize).ThrowIfFailure();
                using var nspStream = nspStorage.AsStream();

                byte[] buffer = new byte[1024 * 1024];
                long totalRead = 0;

                // 헬퍼: 오프셋 예외 방지 루프
                while (totalRead < totalSize)
                {
                    ct.ThrowIfCancellationRequested();
                    int toRead = (int)Math.Min(buffer.Length, totalSize - totalRead);
                    int read = nspStream.Read(buffer, 0, toRead);
                    if (read <= 0) break;

                    fout.Write(buffer, 0, read);
                    totalRead += read;
                    progress?.Report(((int)((double)totalRead / totalSize * 100), finalFileName));
                }
                fout.Flush();
            }

            log?.Invoke($"병합 완료: {finalFileName}", LogLevel.Ok);
            return finalPath;
        }
        finally
        {
            for (int i = disposables.Count - 1; i >= 0; i--) disposables[i]?.Dispose();
            foreach (var temp in tempFiles) if (File.Exists(temp)) try { File.Delete(temp); } catch { }
        }
    }
}