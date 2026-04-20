using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Ncm;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using LibHac.Tools.Ncm;
using NSW.Core;
using NSW.Core.Enums;
using NSW.Core.Models;
using System.IO;
using Path = System.IO.Path;
using Res = NSW.M2.Properties.Resources;

namespace NSW.M2.Services;

public sealed class NspSplitService(string keysPath)
{
    public int Split(string sourceNspPath, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var keySet = ExternalKeyReader.ReadKeyFile(keysPath);

        var allMetas = Utils.GetMetadataFromContainer(keySet, sourceNspPath);

        if (allMetas.Count <= 1)
        {
            log?.Invoke(Res.Log_SplitNoTarget, LogLevel.Info);
            return 0;
        }

        using var storage = new LocalStorage(sourceNspPath, FileAccess.Read);
        var fs = NspHelper.OpenFileSystem(sourceNspPath, storage, keySet);
        var allFiles = new Dictionary<string, IStorage>();
        var disposables = new List<IDisposable>();
        int successCount = 0;

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

            string cachedBaseTitle = allMetas.FirstOrDefault(m => m.Type == ContentMetaType.Application)?.KrTitle
                                     ?? allMetas.FirstOrDefault()?.KrTitle;

            foreach (var meta in allMetas)
            {
                ct.ThrowIfCancellationRequested();
                if (ProcessSplitItem(meta, allFiles, keySet, cachedBaseTitle, outputDir, progress, log, ct))
                    successCount++;
            }
        }
        finally { foreach (var d in disposables) d.Dispose(); }

        return successCount;
    }

    private static bool ProcessSplitItem(MetadataResult meta, Dictionary<string, IStorage> allFiles, KeySet keySet, string baseTitle, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct)
    {
        try
        {
            string typeTag = meta.GetTypeTag();
            string displayVer = meta.GetEffectiveDisplayVersion();
            string versionPart = (typeTag != "DLC") ? $" [v{displayVer}]" : "";
            string outName = $"{baseTitle} [{meta.TitleId}] ({typeTag}){versionPart}.nsp";

            foreach (var c in Path.GetInvalidFileNameChars())
                outName = outName.Replace(c, '_');

            var builder = new PartitionFileSystemBuilder();
            string titleIdHex = meta.TitleId.ToUpper();

            var tikName = allFiles.Keys.FirstOrDefault(k => k.EndsWith(".tik") && k.Contains(titleIdHex, StringComparison.OrdinalIgnoreCase));
            if (tikName != null) builder.AddFile(tikName, allFiles[tikName].AsFile(OpenMode.Read));

            var certName = allFiles.Keys.FirstOrDefault(k => k.EndsWith(".cert") && k.Contains(titleIdHex, StringComparison.OrdinalIgnoreCase));
            if (certName != null) builder.AddFile(certName, allFiles[certName].AsFile(OpenMode.Read));

            if (!allFiles.ContainsKey(meta.FileName)) return false;
            string cnmtNcaName = meta.FileName;
            builder.AddFile(cnmtNcaName, allFiles[cnmtNcaName].AsFile(OpenMode.Read));

            using var ncaStorage = new FileStorage(allFiles[cnmtNcaName].AsFile(OpenMode.Read));
            var nca = new Nca(keySet, ncaStorage);
            using var cnmtFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);
            var entry = cnmtFs.EnumerateEntries("/", "*.cnmt").First();

            using var cFile = new UniqueRef<IFile>();
            cnmtFs.OpenFile(ref cFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();
            var cnmt = new Cnmt(cFile.Get.AsStream());

            foreach (var record in cnmt.ContentEntries)
            {
                string targetId = BitConverter.ToString(record.NcaId).Replace("-", "").ToLower();
                string matchName = allFiles.Keys.FirstOrDefault(k => k.StartsWith(targetId, StringComparison.OrdinalIgnoreCase));

                if (matchName != null)
                {
                    var file = allFiles[matchName].AsFile(OpenMode.Read);
                    var stream = NspHelper.GetDecodedStream(file, matchName, keySet);
                    builder.AddFile(Path.ChangeExtension(matchName, ".nca"), stream.AsStorage().AsFile(OpenMode.Read));
                }
            }

            WriteNsp(builder, Path.Combine(outputDir, outName), outName, progress, ct);

            string tikStatus = tikName != null ? Res.Status_Tik_O : Res.Status_Tik_X;
            log?.Invoke(string.Format(Res.Log_SplitComplete, outName, tikStatus), LogLevel.Ok);

            return true;
        }
        catch (Exception ex)
        {
            log?.Invoke(string.Format(Res.Log_SplitFailed, meta.TitleId, ex.Message), LogLevel.Error);
            return false;
        }
    }

    private static void WriteNsp(PartitionFileSystemBuilder builder, string outPath, string outName, IProgress<(int pct, string label)> progress, CancellationToken ct)
    {
        try
        {
            using var nspStorage = builder.Build(PartitionFileSystemType.Standard);
            nspStorage.GetSize(out long size);

            using var fout = File.Open(outPath, FileMode.Create, FileAccess.Write);
            using var nspStream = nspStorage.AsStream();

            byte[] buffer = new byte[0x800000];
            long totalRead = 0;

            while (totalRead < size)
            {
                ct.ThrowIfCancellationRequested();

                int toRead = (int)Math.Min(buffer.Length, size - totalRead);
                int read = nspStream.Read(buffer, 0, toRead);

                if (read <= 0) break;

                fout.Write(buffer, 0, read);
                totalRead += read;

                var (pct, label, _, _) = Utils.CalculateProgress(totalRead, size, outName);
                progress?.Report((pct, label));
            }

            fout.Flush();
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format(Res.Log_WriteNspFailed, ex.Message), ex);
        }
    }
}