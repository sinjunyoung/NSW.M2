using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Ncm;
using LibHac.NSZ;
using LibHac.Tools.Es;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using NSW.M2.Avalonia.Models;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using NSW.Core;
using NSW.Core.Enums;
using NSW.Core.Models;
using NSW.Core.Services;

using Path = System.IO.Path;
using Res = NSW.Core.Properties.Resources;

namespace NSW.M2.Avalonia.Services;

public static class NspMergeService
{
    public static List<string> Merge(IReadOnlyList<string> inputPaths, string outputDir, bool compressToNcz, int nczCompressionLevel, byte nczBlockSizeExponent, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        return RunMergeAll(inputPaths, outputDir, compressToNcz, nczCompressionLevel, nczBlockSizeExponent, KeySetProvider.Instance.KeySet, progress, log, ct);
    }

    public static List<string> RunMergeAll(IReadOnlyList<string> inputPaths, string outputDir, bool compressToNcz, int nczCompressionLevel, byte nczBlockSizeExponent, KeySet ks, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        log?.Invoke(Res.Log_AnalyzeMetadata, LogLevel.Info);

        var allMeta = new List<MetadataResult>();
        foreach (var path in inputPaths)
        {
            ct.ThrowIfCancellationRequested();
            allMeta.AddRange(Utils.GetMetadataFromContainer(ks, path));
        }

        if (allMeta.Count == 0)
            throw new InvalidOperationException(Res.Error_NoMetadata);

        var groups = BuildTitleGroups(allMeta);
        log?.Invoke(string.Format(Res.Log_TitleGroupDetected, groups.Count), LogLevel.Info);

        var results = new List<string>();
        int idx = 0;

        foreach (var group in groups.Values)
        {
            ct.ThrowIfCancellationRequested();
            idx++;

            if (group.BaseMetas.Count == 0)
            {
                log?.Invoke(string.Format(Res.Log_BaseMissingSkip, group.BaseTitleId), LogLevel.Info);
                continue;
            }

            var allSources = group.BaseMetas
                .Concat(group.PatchMetas)
                .Concat(group.DlcMetas)
                .Select(m => m.SourcePath)
                .Where(p => !string.IsNullOrEmpty(p) && File.Exists(p))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            var latestPatch = group.PatchMetas
                .OrderByDescending(m => m.TitleVersion)
                .FirstOrDefault();

            var allowedNcaIds = BuildAllowedNcaIds(group, latestPatch);

            var baseMeta = group.BaseMetas.First();
            var req = new BuildRequest(
                baseMeta.SourcePath, latestPatch?.SourcePath ?? string.Empty, [.. group.DlcMetas
                .Select(m => m.SourcePath)
                .Distinct(StringComparer.OrdinalIgnoreCase)], outputDir)
            {
                CompressToNcz = compressToNcz,
                NczCompressionLevel = nczCompressionLevel,
                NczBlockSizeExponent = nczBlockSizeExponent,
                AllSourcePaths = allSources,
                TargetBaseTitleId = group.BaseTitleId,
                AllowedNcaIds = allowedNcaIds,
                ResolvedMeta = new MetadataResult(baseMeta.TitleId, (latestPatch ?? baseMeta).TitleVersion, (latestPatch ?? baseMeta).DisplayVersion, baseMeta.KrTitle, baseMeta.EnTitle, group.DlcMetas
                        .GroupBy(m => m.TitleId, StringComparer.OrdinalIgnoreCase)
                        .Count(),
                        Type: ContentMetaType.Application),
            };

            log?.Invoke($"[{group.BaseTitleId}] {Res.Button_MergeStart} ({idx}/{groups.Count})", LogLevel.Info);

            try
            {
                results.Add(RunMergeProcess(req, ks, progress, log, ct));
            }
            catch (Exception ex)
            {
                log?.Invoke(string.Format(Res.Log_MergeFailed, group.BaseTitleId, ex.Message), LogLevel.Error);
            }
        }

        return results;
    }

    private static Dictionary<string, TitleGroup> BuildTitleGroups(List<MetadataResult> allMeta)
    {
        var groups = new Dictionary<string, TitleGroup>(StringComparer.OrdinalIgnoreCase);

        foreach (var meta in allMeta)
        {
            if (string.IsNullOrEmpty(meta.TitleId)) continue;
            if (!ulong.TryParse(meta.TitleId,
                System.Globalization.NumberStyles.HexNumber, null, out ulong tid)) continue;

            string baseTid = (tid & 0xFFFFFFFFFFFF0000UL).ToString("X16");

            if (!groups.TryGetValue(baseTid, out var group))
            {
                group = new TitleGroup(baseTid);
                groups[baseTid] = group;
            }

            switch (meta.Type)
            {
                case ContentMetaType.Application: group.BaseMetas.Add(meta); break;
                case ContentMetaType.Patch: group.PatchMetas.Add(meta); break;
                case ContentMetaType.AddOnContent: group.DlcMetas.Add(meta); break;
            }
        }

        return groups;
    }

    private static HashSet<string>? BuildAllowedNcaIds(TitleGroup group, MetadataResult? latestPatch)
    {
        var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var meta in group.BaseMetas
            .GroupBy(m => m.TitleId, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First()))
        {
            AddNcaIds(allowed, meta);
        }

        if (latestPatch != null)
            AddNcaIds(allowed, latestPatch);

        foreach (var meta in group.DlcMetas
            .GroupBy(m => m.TitleId, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First()))
        {
            AddNcaIds(allowed, meta);
        }

        return allowed.Count > 0 ? allowed : null;
    }

    private static void AddNcaIds(HashSet<string> set, MetadataResult meta)
    {
        if (meta.ContentNcaIds == null) return;
        foreach (var id in meta.ContentNcaIds) set.Add(id);
    }

    public static string RunMergeProcess(BuildRequest req, KeySet libHacKeySet, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var builder = new PartitionFileSystemBuilder();
        var disposables = new List<IDisposable>();
        var tempFiles = new List<string>();
        string? finalPath = null;
        bool isCompleted = false;

        var fileRegistry = new Dictionary<string, (string Path, string EntryName, string Ext)>(StringComparer.OrdinalIgnoreCase);

        try
        {
            var allPaths = GetAllPaths(req);

            var allMetaCache = allPaths
                .SelectMany(p => Utils.GetMetadataFromContainer(libHacKeySet, p))
                .ToList();

            log?.Invoke(Res.Log_MergeStart, LogLevel.Info);

            foreach (var path in allPaths)
            {
                ct.ThrowIfCancellationRequested();
                using var storage = new LocalStorage(path, FileAccess.Read);
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

                foreach (var entry in fs.EnumerateEntries("/", "*.tik"))
                {
                    using var tikFile = new UniqueRef<IFile>();
                    if (fs.OpenFile(ref tikFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
                    {
                        var ticket = new Ticket(tikFile.Get.AsStream());

                        byte[] rightsIdBytes = ticket.RightsId;
                        var rightsId = new RightsId(rightsIdBytes);

                        if (!libHacKeySet.ExternalKeySet.Contains(rightsId))
                            libHacKeySet.ExternalKeySet.Add(rightsId, new LibHac.Spl.AccessKey(ticket.GetTitleKey(libHacKeySet)));
                    }
                }

                foreach (var entry in fs.EnumerateEntries("/", "*"))
                {
                    string entryName = entry.Name.ToString();
                    string entryExt = Path.GetExtension(entryName).ToLowerInvariant();

                    if (req.AllowedNcaIds != null)
                    {
                        if (entryExt is ".nca" or ".ncz")
                        {
                            string ncaId = ExtractNcaId(entryName);
                            if (!string.IsNullOrEmpty(ncaId) && !req.AllowedNcaIds.Contains(ncaId)) continue;
                        }
                    }

                    string finalName = entryExt == ".ncz" ? Path.ChangeExtension(entryName, ".nca") : entryName;

                    if (!fileRegistry.TryGetValue(finalName, out (string Path, string EntryName, string Ext) value) || value.Ext == ".ncz" && entryExt == ".nca")
                    {
                        value = (path, entryName, entryExt);
                        fileRegistry[finalName] = value;
                    }
                }
            }

            var addedFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var kvp in fileRegistry)
            {
                ct.ThrowIfCancellationRequested();
                var (sourcePath, entryName, originalExt) = kvp.Value;

                var storage = new LocalStorage(sourcePath, FileAccess.Read);
                disposables.Add(storage);

                IFileSystem fs;
                string ext = Path.GetExtension(sourcePath).ToLower();
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

                var file = new UniqueRef<IFile>();

                if (!fs.OpenFile(ref file.Ref, ("/" + entryName).ToU8Span(), OpenMode.Read).IsSuccess()) continue;

                file.Get.GetSize(out long size).ThrowIfFailure();
                if (size == 0) { file.Destroy(); continue; }

                IFile rawFile = file.Release();
                disposables.Add(rawFile);
                IStorage currentStorage = new FileStorage(rawFile);
                disposables.Add(currentStorage);

                if (originalExt is not (".nca" or ".ncz"))
                {
                    if (addedFileNames.Add(kvp.Key))
                        builder.AddFile(kvp.Key, currentStorage.AsFile(OpenMode.Read));
                    continue;
                }

                var nca = new Nca(libHacKeySet, currentStorage);
                string tid = nca.Header.TitleId.ToString("X16");
                var metaInfo = allMetaCache.FirstOrDefault(m => m.ContentNcaIds?.Contains(ExtractNcaId(entryName)) == true);
                string contentMetaType = metaInfo != null ? Utils.GetContentMetaTypeTag(metaInfo.Type) : "Unknown";
                string ncaContentType = nca.Header.ContentType.ToString();
                string displayText = originalExt == ".ncz" ? Res.Log_DecompressAndMerge : Res.Log_Merging;

                log?.Invoke($"   └ [{tid}] [{contentMetaType}] [{ncaContentType}] {displayText}", LogLevel.Info);

                string finalName = entryName;

                if (originalExt == ".ncz")
                {
                    var ncz = new Ncz(libHacKeySet, currentStorage.AsStream(), NczReadMode.Original);
                    currentStorage = ncz.BaseStorage;
                    finalName = Path.ChangeExtension(entryName, ".nca");
                }
                else if (originalExt == ".nca" && req.CompressToNcz)
                {
                    if (nca.Header.ContentType is NcaContentType.Program or NcaContentType.PublicData)
                    {
                        string tempPath = Path.Combine(req.OutputDir, $"{Guid.NewGuid()}.tmp");
                        var fsTemp = File.Open(tempPath, FileMode.Create, FileAccess.ReadWrite);
                        NcaToNczConverter.Convert(currentStorage.AsStream(), fsTemp, libHacKeySet, req.NczCompressionLevel);
                        fsTemp.Position = 0;
                        currentStorage = fsTemp.AsStorage();
                        disposables.Add(fsTemp);
                        tempFiles.Add(tempPath);
                        finalName = Path.ChangeExtension(entryName, ".ncz");
                    }
                }

                if (!addedFileNames.Add(finalName)) continue;
                builder.AddFile(finalName, currentStorage.AsFile(OpenMode.Read));
            }

            var meta = req.ResolvedMeta ?? ExtractFinalMetadata(libHacKeySet, allPaths, req.TargetBaseTitleId);
            log?.Invoke(string.Format(Res.Log_FinalId, meta.TitleId, meta.DisplayVersion), LogLevel.Ok);

            string finalFileName = NspFileNameBuilder.Build("Merged", meta.KrTitle, meta.EnTitle, meta.TitleId, meta.DisplayVersion, meta.TitleVersion, meta.DlcCount);
            finalPath = Path.Combine(req.OutputDir, finalFileName);

            using var nspStorage = builder.Build(PartitionFileSystemType.Standard);
            using var fout = File.Open(finalPath, FileMode.Create, FileAccess.Write);

            nspStorage.GetSize(out long totalSize).ThrowIfFailure();
            using var nspStream = nspStorage.AsStream();

            byte[] buffer = new byte[0x800000];
            long totalRead = 0;

            while (totalRead < totalSize)
            {
                ct.ThrowIfCancellationRequested();
                int toRead = (int)Math.Min(buffer.Length, totalSize - totalRead);
                int read = nspStream.Read(buffer, 0, toRead);
                if (read <= 0) break;

                fout.Write(buffer, 0, read);
                totalRead += read;

                var (pct, label, _, _) = Utils.CalculateProgress(totalRead, totalSize, finalFileName);
                progress?.Report((pct, label));
            }
            fout.Flush();
            isCompleted = true;
            log?.Invoke(string.Format(Res.Log_MergeComplete, finalFileName), LogLevel.Ok);
            return finalPath;
        }
        catch (Exception ex)
        {
            log?.Invoke(string.Format(Res.Log_Error, ex.Message), LogLevel.Error);
            throw;
        }
        finally
        {
            for (int i = disposables.Count - 1; i >= 0; i--) disposables[i]?.Dispose();
            foreach (var temp in tempFiles)
                if (File.Exists(temp)) try { File.Delete(temp); } catch { }

            if (!isCompleted && !string.IsNullOrEmpty(finalPath) && File.Exists(finalPath))
            {
                try
                {
                    File.Delete(finalPath);
                    log?.Invoke(Res.Log_DeleteIncompleteFile, LogLevel.Info);
                }
                catch {}
            }
        }
    }

    private static string ExtractNcaId(string fileName)
    {
        string stem = Path.GetFileNameWithoutExtension(fileName);
        if (stem.EndsWith(".cnmt", StringComparison.OrdinalIgnoreCase))
            stem = Path.GetFileNameWithoutExtension(stem);

        return stem.Length >= 32 ? stem[..32].ToLowerInvariant() : string.Empty;
    }

    private static List<string> GetAllPaths(BuildRequest req)
    {
        if (req.AllSourcePaths is { Count: > 0 })
            return [.. req.AllSourcePaths.Where(p => !string.IsNullOrEmpty(p) && File.Exists(p))];

        var list = new List<string>();
        if (!string.IsNullOrEmpty(req.UpdateFilePath) && File.Exists(req.UpdateFilePath))
            list.Add(req.UpdateFilePath);
        foreach (var p in req.DlcFilePaths)
            if (!string.IsNullOrEmpty(p) && File.Exists(p) && !list.Contains(p))
                list.Add(p);
        if (!string.IsNullOrEmpty(req.BaseFilePath) && !list.Contains(req.BaseFilePath))
            list.Add(req.BaseFilePath);
        return list;
    }

    private static MetadataResult ExtractFinalMetadata(KeySet ks, List<string> paths, string? targetBaseTitleId = null)
    {
        var allMetas = paths
            .SelectMany(p => Utils.GetMetadataFromContainer(ks, p))
            .GroupBy(m => new { m.TitleId, m.TitleVersion, m.Type })
            .Select(g => g.First())
            .ToList();

        if (!string.IsNullOrEmpty(targetBaseTitleId))
        {
            allMetas = [.. allMetas.Where(m =>
            {
                if (!ulong.TryParse(m.TitleId, System.Globalization.NumberStyles.HexNumber, null, out ulong tid))
                    return false;
                return (tid & 0xFFFFFFFFFFFF0000UL).ToString("X16")
                    .Equals(targetBaseTitleId, StringComparison.OrdinalIgnoreCase);
            })];
        }

        if (allMetas.Count == 0) return new MetadataResult(string.Empty, 0, "1.0.0", string.Empty, string.Empty, 0, ContentMetaType.Application);

        int dlcCount = allMetas.Count(m => m.Type == ContentMetaType.AddOnContent);

        var latestPatch = allMetas
            .Where(m => m.Type == ContentMetaType.Patch)
            .OrderByDescending(m => m.TitleVersion)
            .FirstOrDefault();

        var baseGame = allMetas.FirstOrDefault(m => m.Type == ContentMetaType.Application) ?? allMetas.First();

        var versionSource = latestPatch ?? baseGame;

        return new MetadataResult(baseGame.TitleId, versionSource.TitleVersion, versionSource.DisplayVersion, baseGame.KrTitle, baseGame.EnTitle, dlcCount, ContentMetaType.Application);
    }
}