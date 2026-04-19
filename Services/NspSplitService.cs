using LibHac;
using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Ncm;
using LibHac.Ns;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using LibHac.Tools.Ncm;
using NSW.Core.Enums;
using System.IO;
using System.Runtime.InteropServices;
using static LibHac.Ns.ApplicationControlProperty;
using Path = System.IO.Path;

namespace NSW.M2.Services;

public sealed class NspSplitService(string keysPath)
{
    public void Split(string sourceNspPath, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var keySet = ExternalKeyReader.ReadKeyFile(keysPath);
        using var storage = new LocalStorage(sourceNspPath, FileAccess.Read);
        var fs = NspHelper.OpenFileSystem(sourceNspPath, storage, keySet);

        var allFiles = new Dictionary<string, IStorage>();
        var disposables = new List<IDisposable>();
        string cachedGameTitle = null;

        try
        {
            foreach (var entry in fs.EnumerateEntries("/", "*"))
            {
                var file = new UniqueRef<IFile>();
                if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsFailure()) continue;

                IFile rawFile = file.Release();
                disposables.Add(rawFile);

                allFiles.Add(entry.Name, rawFile.AsStream().AsStorage());
            }

            var cnmtNcas = allFiles.Keys.Where(k => k.EndsWith(".cnmt.nca")).ToList();

            if (cnmtNcas.Count <= 1)
            {
                log?.Invoke("이미 단일 콘텐츠이거나 분리할 대상이 없습니다. 작업을 중단합니다.", LogLevel.Info);
                return;
            }

            foreach (var name in cnmtNcas)
            {
                var (title, _, _) = GetMetadata(name, allFiles, keySet);
                if (!string.IsNullOrWhiteSpace(title)) { cachedGameTitle = title; break; }
            }

            foreach (var cnmtNcaName in cnmtNcas)
            {
                ct.ThrowIfCancellationRequested();
                ProcessCnmt(cnmtNcaName, allFiles, keySet, cachedGameTitle, outputDir, progress, log, ct);
            }
        }
        finally { foreach (var d in disposables) d.Dispose(); }
    }

    private static void ProcessCnmt(string cnmtNcaName, Dictionary<string, IStorage> allFiles, KeySet keySet, string cachedTitle, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct)
    {
        try
        {
            var (title, version, cnmt) = GetMetadata(cnmtNcaName, allFiles, keySet);
            if (cnmt == null) return;

            string typeTag = GetTypeTag(cnmt.Type);
            string vValue = !string.IsNullOrWhiteSpace(version) ? version : cnmt.TitleVersion.ToString();
            string versionStr = (typeTag != "DLC") ? $" [v{vValue}]" : "";

            string outName = $"{cachedTitle ?? cnmt.TitleId.ToString("X16")} [{cnmt.TitleId:X16}] ({typeTag}){versionStr}.nsp";
            foreach (var c in Path.GetInvalidFileNameChars()) outName = outName.Replace(c, '_');

            var builder = new PartitionFileSystemBuilder();
            builder.AddFile(cnmtNcaName, allFiles[cnmtNcaName].AsFile(OpenMode.Read));

            foreach (var record in cnmt.ContentEntries)
            {
                string targetId = BitConverter.ToString(record.NcaId).Replace("-", "").ToLower();
                string matchName = allFiles.Keys.FirstOrDefault(k => k.StartsWith(targetId));

                if (matchName != null)
                {
                    var file = allFiles[matchName].AsFile(OpenMode.Read);
                    var stream = NspHelper.GetDecodedStream(file, matchName, keySet);
                    builder.AddFile(Path.ChangeExtension(matchName, ".nca"), stream.AsStorage().AsFile(OpenMode.Read));
                }
            }

            WriteNsp(builder, Path.Combine(outputDir, outName), outName, progress, ct);
            log?.Invoke($"{outName} 분리 완료", LogLevel.Ok);
        }
        catch (Exception ex) { log?.Invoke($"분리 실패 ({cnmtNcaName}): {ex.Message}", LogLevel.Error); }
    }

    private static (string Title, string Version, Cnmt Cnmt) GetMetadata(string cnmtNcaName, Dictionary<string, IStorage> allFiles, KeySet keySet)
    {
        try
        {
            using var ncaStorage = new FileStorage(allFiles[cnmtNcaName].AsFile(OpenMode.Read));
            var nca = new Nca(keySet, ncaStorage);
            using var cnmtFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);
            var entry = cnmtFs.EnumerateEntries("/", "*.cnmt").FirstOrDefault();
            if (entry == null) return (null, null, null);

            using var cFile = new UniqueRef<IFile>();
            cnmtFs.OpenFile(ref cFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();
            var cnmt = new Cnmt(cFile.Get.AsStream());

            var ctrlRecord = cnmt.ContentEntries.FirstOrDefault(x => x.Type == LibHac.Ncm.ContentType.Control);
            if (ctrlRecord == null) return (null, null, cnmt);

            string ctrlId = BitConverter.ToString(ctrlRecord.NcaId).Replace("-", "").ToLower();
            string ctrlFileName = allFiles.Keys.FirstOrDefault(k => k.StartsWith(ctrlId));
            if (ctrlFileName == null) return (null, null, cnmt);

            using var cs = new FileStorage(allFiles[ctrlFileName].AsFile(OpenMode.Read));
            var cNca = new Nca(keySet, cs);
            using var ctrlFs = cNca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);

            if (!ctrlFs.FileExists("/control.nacp")) return (null, null, cnmt);

            using var nacpFile = new UniqueRef<IFile>();
            ctrlFs.OpenFile(ref nacpFile.Ref, "/control.nacp".ToU8Span(), OpenMode.Read).ThrowIfFailure();
            var nacpData = new byte[Marshal.SizeOf<ApplicationControlProperty>()];
            nacpFile.Get.Read(out _, 0, nacpData).ThrowIfFailure();
            var control = MemoryMarshal.Read<ApplicationControlProperty>(nacpData);

            string kr = control.Title[(int)Language.Korean].NameString.ToString().Trim('\0', ' ');
            string en = control.Title[(int)Language.AmericanEnglish].NameString.ToString().Trim('\0', ' ');
            string ver = control.DisplayVersionString.ToString().Trim('\0', ' ');

            return (!string.IsNullOrWhiteSpace(kr) ? kr : en, ver, cnmt);
        }
        catch { return (null, null, null); }
    }

    private static void WriteNsp(PartitionFileSystemBuilder builder, string outPath, string outName, IProgress<(int pct, string label)> progress, CancellationToken ct)
    {
        try
        {
            using var nspStorage = builder.Build(PartitionFileSystemType.Standard);
            nspStorage.GetSize(out long size);

            using var fout = File.Open(outPath, FileMode.Create, FileAccess.Write);
            using var nspStream = nspStorage.AsStream();

            byte[] buffer = new byte[1024 * 1024];
            long totalRead = 0;

            while (totalRead < size)
            {
                ct.ThrowIfCancellationRequested();

                int toRead = (int)Math.Min(buffer.Length, size - totalRead);
                int read = nspStream.Read(buffer, 0, toRead);

                if (read <= 0) break;

                fout.Write(buffer, 0, read);
                totalRead += read;

                int pct = (int)((double)totalRead / size * 100);
                progress?.Report((pct, outName));
            }

            fout.Flush();
        }
        catch (Exception ex)
        {
            throw new Exception($"NSP 쓰기 실패: {ex.Message}", ex);
        }
    }

    private static string GetTypeTag(ContentMetaType type)
    {
        return type switch
        {
            ContentMetaType.Application => "BASE",
            ContentMetaType.Patch => "UPD",
            ContentMetaType.AddOnContent => "DLC",
            ContentMetaType.Delta => "DLC",
            _ => type.ToString().ToUpper()
        };
    }
}