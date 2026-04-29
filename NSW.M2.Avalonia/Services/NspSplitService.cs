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
using System;
using System.IO;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NSW.Core;
using NSW.Core.Enums;
using NSW.Core.Models;
using Path = System.IO.Path;
using Res = NSW.Core.Properties.Resources;
using System.Text.RegularExpressions;
using NSW.Avalonia.Services;
using NSW.Utils;

namespace NSW.M2.Avalonia.Services;

public static class NspSplitService
{
    public static int Split(string sourceNspPath, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var keySet = KeySetProvider.Instance.KeySet;
        var allMetas = Core.Utils.GetMetadataFromContainer(keySet, sourceNspPath);

        if (allMetas.Count <= 1)
        {
            log?.Invoke(Res.Log_SplitNoTarget, LogLevel.Info);
            return 0;
        }

        var disposables = new List<IDisposable>();
        var allFiles = new Dictionary<string, IStorage>();
        int successCount = 0;

        try
        {
            var storage = new LocalStorage(sourceNspPath, FileAccess.Read);
            disposables.Add(storage);

            var fs = NspHelper.OpenFileSystem(sourceNspPath, storage, keySet);
            disposables.Add(fs);

            foreach (var entry in fs.EnumerateEntries("/", "*"))
            {
                var file = new UniqueRef<IFile>();
                if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsFailure()) continue;
                IFile rawFile = file.Release();
                disposables.Add(rawFile);
                allFiles.Add(entry.Name, rawFile.AsStream().AsStorage());
            }

            string cachedBaseTitle =
                allMetas.FirstOrDefault(m => m.Type == ContentMetaType.Application)
                is { } appMeta
                ? (!string.IsNullOrEmpty(appMeta.KrTitle) ? appMeta.KrTitle : appMeta.EnTitle)
                : allMetas.FirstOrDefault()
                is { } firstMeta
                ? (!string.IsNullOrEmpty(firstMeta.KrTitle) ? firstMeta.KrTitle : firstMeta.EnTitle)
                : string.Empty;

            foreach (var meta in allMetas)
            {
                ct.ThrowIfCancellationRequested();
                if (ProcessSplitItem(meta, allFiles, keySet, cachedBaseTitle, outputDir, progress, log, ct))
                    successCount++;
            }
        }
        finally
        {
            for (int i = disposables.Count - 1; i >= 0; i--) disposables[i]?.Dispose();
        }

        return successCount;
    }

    private static bool ProcessSplitItem(MetadataResult meta, Dictionary<string, IStorage> allFiles, KeySet keySet, string baseTitle, string outputDir, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct)
    {
        try
        {
            string typeTag = meta.GetTypeTag();
            string displayVer = meta.GetEffectiveDisplayVersion();

            log?.Invoke(string.Format(Res.Log_SplitPreparing, typeTag, meta.TitleId, displayVer), LogLevel.Info);

            string versionPart = typeTag != "DLC" ? $" [v{displayVer}]" : string.Empty;
            string outName = $"{baseTitle} [{meta.TitleId}] ({typeTag}){versionPart}.nsp";

            var invalidChars = Path.GetInvalidFileNameChars()
                .Concat(['\\', '/', ':'])
                .Distinct()
                .ToArray();

            foreach (var c in invalidChars)
                outName = outName.Replace(c.ToString(), "");

            outName = Regex.Replace(outName, @"\s+", " ").Trim();

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
                string targetId = BitConverter.ToString(record.NcaId).Replace("-", string.Empty).ToLower();
                string matchName = allFiles.Keys.FirstOrDefault(k => k.StartsWith(targetId, StringComparison.OrdinalIgnoreCase));

                if (matchName != null)
                {
                    var file = allFiles[matchName].AsFile(OpenMode.Read);

                    string displayText = $"{baseTitle}/{record.Type}";

                    if (matchName.EndsWith(".ncz", StringComparison.OrdinalIgnoreCase))
                        displayText = string.Format(Res.Log_SplitDecompressing, displayText);
                    else
                        displayText = string.Format(Res.Log_SplitExtracting, displayText);

                    log?.Invoke(displayText, LogLevel.Info);

                    var stream = NspHelper.GetDecodedStream(file, matchName, keySet);
                    builder.AddFile(Path.ChangeExtension(matchName, ".nca"), stream.AsStorage().AsFile(OpenMode.Read));
                }
            }

            WriteNsp(builder, Path.Combine(outputDir, outName), meta, typeTag, progress, ct);

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

    private static void WriteNsp(PartitionFileSystemBuilder builder, string outPath, MetadataResult meta, string typeTag, IProgress<(int pct, string label)> progress, CancellationToken ct)
    {
        bool isCompleted = false;
        string displayName = NspNameBuilder.DisplayNameBuild(meta.EnTitle, meta.TitleId, meta.DisplayVersion);

        const int bufferSize = 0x800000;
        byte[] buffer = ArrayPool<byte>.Shared.Rent(bufferSize);

        try
        {
            using var nspStorage = builder.Build(PartitionFileSystemType.Standard);
            nspStorage.GetSize(out long size);

            using var fout = File.Open(outPath, FileMode.Create, FileAccess.Write);
            using var nspStream = nspStorage.AsStream();

            long totalRead = 0;

            while (totalRead < size)
            {
                ct.ThrowIfCancellationRequested();

                int toRead = (int)Math.Min(bufferSize, size - totalRead);
                int read = nspStream.Read(buffer, 0, toRead);

                if (read <= 0) break;

                fout.Write(buffer, 0, read);
                totalRead += read;

                var (pct, label, _, _) = Common.CalculateProgress(totalRead, size, displayName);
                progress?.Report((pct, string.Format(Res.Progress_Splitting, label, typeTag)));
            }

            fout.Flush();
            isCompleted = true;
        }
        catch (Exception ex)
        {
            throw new Exception(string.Format(Res.Log_WriteNspFailed, ex.Message), ex);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);

            if (!isCompleted && File.Exists(outPath))
                try { File.Delete(outPath); } catch { }
        }
    }
}