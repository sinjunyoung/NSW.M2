using DynamicData;
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
using NSW.Avalonia.Models;
using NSW.Avalonia.Services;
using NSW.Core;
using NSW.Core.Enums;
using NSW.Core.Models;
using NSW.Utils;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Path = System.IO.Path;
using Res = NSW.Core.Properties.Resources;

namespace NSW.M2.Avalonia.Services;

public static class NspMergeService
{
    public static List<string> Merge(IReadOnlyList<string> inputPaths, string outputDir, int nczCompressionLevel, bool verify, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        return RunMergeAll(inputPaths, outputDir, nczCompressionLevel > 0, nczCompressionLevel, verify, KeySetProvider.Instance.KeySet.Clone(), progress, log, ct);
    }

    public static List<string> RunMergeAll(IReadOnlyList<string> inputPaths, string outputDir, bool compressToNcz, int nczCompressionLevel, bool verify, KeySet ks, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        log?.Invoke(Res.Log_AnalyzeMetadata, LogLevel.Info);

        var allMeta = new List<MetadataResult>();
        foreach (var path in inputPaths)
        {
            ct.ThrowIfCancellationRequested();
            allMeta.AddRange(Core.Utils.GetMetadataFromContainer(ks, path));
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
                results.Add(RunMergeProcess(req, ks, verify, progress, log, ct));
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

    public static string RunMergeProcess(BuildRequest req, KeySet libHacKeySet, bool verify, IProgress<(int pct, string label)> progress, Action<string, LogLevel> log, CancellationToken ct = default)
    {
        var disposables = new List<IDisposable>();
        var converters = new Dictionary<string, NcaToNczConverter>(StringComparer.OrdinalIgnoreCase);
        string? finalPath = null;
        bool isCompleted = false;
        var fileRegistry = new Dictionary<string, (string Path, string EntryName, string Ext)>(StringComparer.OrdinalIgnoreCase);
        var fsCache = new Dictionary<string, IFileSystem>(StringComparer.OrdinalIgnoreCase);

        try
        {
            var allPaths = GetAllPaths(req);

            var allMetaCache = allPaths
                .SelectMany(p => Core.Utils.GetMetadataFromContainer(libHacKeySet, p))
                .ToList();

            var ncaIdToMeta = allMetaCache
                .Where(m => m.ContentNcaIds != null)
                .SelectMany(m => m.ContentNcaIds!.Select(id => (id, m)))
                .GroupBy(x => x.id, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First().m, StringComparer.OrdinalIgnoreCase);

            log?.Invoke(Res.Log_MergeStart, LogLevel.Info);

            foreach (var path in allPaths)
            {
                ct.ThrowIfCancellationRequested();

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
                fsCache[path] = fs;

                foreach (var entry in fs.EnumerateEntries("/", "*.tik"))
                {
                    using var tikFile = new UniqueRef<IFile>();
                    if (fs.OpenFile(ref tikFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
                    {
                        var ticket = new Ticket(tikFile.Get.AsStream());
                        var rightsId = new RightsId(ticket.RightsId);
                        if (!libHacKeySet.ExternalKeySet.Contains(rightsId))
                            libHacKeySet.ExternalKeySet.Add(rightsId, new LibHac.Spl.AccessKey(ticket.GetTitleKey(libHacKeySet)));
                    }
                }

                foreach (var entry in fs.EnumerateEntries("/", "*"))
                {
                    string entryName = entry.Name.ToString();
                    string entryExt = Path.GetExtension(entryName).ToLowerInvariant();

                    if (req.AllowedNcaIds != null && entryExt is ".nca" or ".ncz")
                    {
                        string ncaId = ExtractNcaId(entryName);
                        if (!string.IsNullOrEmpty(ncaId) && !req.AllowedNcaIds.Contains(ncaId)) continue;
                    }

                    string finalName = entryExt == ".ncz" ? Path.ChangeExtension(entryName, ".nca") : entryName;
                    if (!fileRegistry.TryGetValue(finalName, out var value) || (value.Ext == ".ncz" && entryExt == ".nca"))
                        fileRegistry[finalName] = (path, entryName, entryExt);
                }
            }

            var fileEntries = new List<(string Name, Action<Stream, Action<long>> Writer, long EstimatedSize, string Label)>();
            var addedFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var kvp in fileRegistry)
            {
                ct.ThrowIfCancellationRequested();
                var (sourcePath, entryName, originalExt) = kvp.Value;

                if (!fsCache.TryGetValue(sourcePath, out var fs)) continue;

                var fileRef = new UniqueRef<IFile>();
                if (!fs.OpenFile(ref fileRef.Ref, ("/" + entryName).ToU8Span(), OpenMode.Read).IsSuccess()) continue;

                fileRef.Get.GetSize(out long size).ThrowIfFailure();
                if (size == 0) { fileRef.Destroy(); continue; }

                IFile rawFile = fileRef.Release();
                disposables.Add(rawFile);
                IStorage currentStorage = new FileStorage(rawFile);
                disposables.Add(currentStorage);

                if (originalExt is not (".nca" or ".ncz"))
                {
                    if (!addedFileNames.Add(kvp.Key)) continue;
                    var capturedStorage = currentStorage;
                    fileEntries.Add((kvp.Key, (s, onRead) => CopyStream(capturedStorage.AsStream(), s, ct, onRead), size, kvp.Key));
                    continue;
                }

                var nca = new Nca(libHacKeySet, currentStorage);
                string tid = nca.Header.TitleId.ToString("X16");

                ncaIdToMeta.TryGetValue(ExtractNcaId(entryName), out var metaInfo);

                string typeTag = metaInfo != null ? Core.Utils.GetContentMetaTypeTag(metaInfo.Type) : "Unknown";
                string ncaContentType = nca.Header.ContentType.ToString();
                string titleName = !string.IsNullOrEmpty(metaInfo?.KrTitle) ? metaInfo.KrTitle
                                 : !string.IsNullOrEmpty(metaInfo?.EnTitle) ? metaInfo.EnTitle
                                 : tid;

                if (originalExt == ".ncz")
                {
                    if (req.CompressToNcz)
                    {
                        if (!addedFileNames.Add(kvp.Key)) continue;
                        string finalName = entryName;
                        log?.Invoke($"   └ [{tid}] [{typeTag}] [{ncaContentType}] {Res.Log_Merging}", LogLevel.Info);
                        var capturedStorage = currentStorage;
                        string label = $"{titleName} [{typeTag}] [{ncaContentType}] {Res.Log_Merging}";
                        fileEntries.Add((finalName, (s, onRead) => CopyStream(capturedStorage.AsStream(), s, ct, onRead), size, label));
                    }
                    else
                    {
                        if (!addedFileNames.Add(kvp.Key)) continue;
                        string finalName = Path.ChangeExtension(entryName, ".nca");
                        log?.Invoke($"   └ [{tid}] [{typeTag}] [{ncaContentType}] {Res.Log_DecompressAndMerge}", LogLevel.Info);
                        var ncz = new Ncz(libHacKeySet, currentStorage.AsStream(), NczReadMode.Original);
                        var decStorage = ncz.BaseStorage;
                        decStorage.GetSize(out long decSize).ThrowIfFailure();
                        string label = $"{titleName} [{typeTag}] [{ncaContentType}] {Res.Log_DecompressAndMerge}";
                        fileEntries.Add((finalName, (s, onRead) => CopyStream(decStorage.AsStream(), s, ct, onRead), decSize, label));
                    }
                    continue;
                }

                if (req.CompressToNcz && nca.Header.ContentType is NcaContentType.Program or NcaContentType.PublicData)
                {
                    string finalName = Path.ChangeExtension(entryName, ".ncz");
                    if (!addedFileNames.Add(finalName)) continue;

                    log?.Invoke($"   └ [{tid}] [{typeTag}] [{ncaContentType}] {Res.Log_CompressAndMerge}", LogLevel.Info);
                    var capturedStorage = currentStorage;
                    string label = $"{titleName} [{typeTag}] [{ncaContentType}] {Res.Log_CompressAndMerge}";
                    string capturedName = entryName;
                    var converter = new NcaToNczConverter(libHacKeySet);
                    converters[capturedName] = converter;

                    fileEntries.Add((finalName, (s, onRead) =>
                    {
                        converter.Convert(capturedStorage.AsStream(), s, req.NczCompressionLevel, false, onRead, ct);
                    }, size, label));
                }
                else
                {
                    if (!addedFileNames.Add(entryName)) continue;

                    log?.Invoke($"   └ [{tid}] [{typeTag}] [{ncaContentType}] {Res.Log_Merging}", LogLevel.Info);
                    var capturedStorage = currentStorage;
                    string label = $"{titleName} [{typeTag}] [{ncaContentType}] {Res.Log_Merging}";

                    fileEntries.Add((entryName, (s, onRead) => CopyStream(capturedStorage.AsStream(), s, ct, onRead), size, label));
                }
            }

            var meta = req.ResolvedMeta ?? ExtractFinalMetadata(libHacKeySet, allPaths, req.TargetBaseTitleId);
            log?.Invoke(string.Format(Res.Log_FinalId, meta.TitleId, meta.DisplayVersion), LogLevel.Ok);

            string finalFileName = NspNameBuilder.FileNameBuild("Merged", meta.KrTitle, meta.EnTitle, meta.TitleId, meta.DisplayVersion, meta.TitleVersion, meta.DlcCount, req.CompressToNcz);
            finalPath = Path.Combine(req.OutputDir, finalFileName);

            while (allPaths.Any(p => string.Equals(p, finalPath, StringComparison.OrdinalIgnoreCase)) || File.Exists(finalPath))
            {
                string nameWithoutExt = Path.GetFileNameWithoutExtension(finalPath);
                string ext = Path.GetExtension(finalPath);
                finalPath = Path.Combine(req.OutputDir, nameWithoutExt + "_" + ext);
            }

            string displayName = NspNameBuilder.DisplayNameBuild(meta.EnTitle, meta.TitleId, meta.DisplayVersion, meta.DlcCount, req.CompressToNcz);
            using var fout = File.Open(finalPath, FileMode.Create, FileAccess.ReadWrite);
            Pfs0Builder.BuildStreaming(displayName, fileEntries, fout, progress, ct);

            if (req.CompressToNcz && converters.Count > 0 && verify)
            {
                log?.Invoke(Res.Log_ValidationStart, LogLevel.Info);
                fout.Position = 0;
                var verifyPfs = new PartitionFileSystem();
                verifyPfs.Initialize(fout.AsStorage()).ThrowIfFailure();

                var nczEntries = verifyPfs.EnumerateEntries("/", "*.ncz")
                    .Where(e => converters.ContainsKey(Path.ChangeExtension(e.Name, ".nca")))
                    .ToList();

                long totalVerifySize = nczEntries.Sum(e => e.Size);
                long currentVerifyPos = 0;

                foreach (var entry in nczEntries)
                {
                    ct.ThrowIfCancellationRequested();
                    string origName = Path.ChangeExtension(entry.Name, ".nca");
                    if (!converters.TryGetValue(origName, out var converter)) continue;

                    using var nczFile = new UniqueRef<IFile>();
                    verifyPfs.OpenFile(ref nczFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();

                    ncaIdToMeta.TryGetValue(ExtractNcaId(entry.Name), out var nczMetaInfo);
                    string nczTypeTag = nczMetaInfo != null ? Core.Utils.GetContentMetaTypeTag(nczMetaInfo.Type) : "Unknown";
                    string label = $"{(nczMetaInfo?.KrTitle ?? nczMetaInfo?.EnTitle ?? entry.Name)} [{nczTypeTag}]";

                    log?.Invoke($"   └ {label} {Res.Log_StatusVerifying}", LogLevel.Info);
                    converter.Verify(nczFile.Get.AsStream(), totalVerifySize, ref currentVerifyPos, label, progress, ct);
                    log?.Invoke($"   └ {label} OK", LogLevel.Ok);
                }
                log?.Invoke(Res.Log_ValidationComplete, LogLevel.Ok);
            }

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

            if (!isCompleted && !string.IsNullOrEmpty(finalPath) && File.Exists(finalPath))
            {
                try { File.Delete(finalPath); log?.Invoke(Res.Log_DeleteIncompleteFile, LogLevel.Info); }
                catch { }
            }
        }
    }

    private static void CopyStream(Stream src, Stream dst, CancellationToken ct, Action<long>? onRead = null)
    {
        const int bufferSize = 81920;
        byte[] buf = ArrayPool<byte>.Shared.Rent(bufferSize);
        try
        {
            int read;
            while ((read = src.Read(buf, 0, bufferSize)) > 0)
            {
                ct.ThrowIfCancellationRequested();
                dst.Write(buf, 0, read);
                onRead?.Invoke(read);
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buf);
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
            .SelectMany(p => Core.Utils.GetMetadataFromContainer(ks, p))
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