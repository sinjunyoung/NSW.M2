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
using NSW.Core.Models;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using static LibHac.Ns.ApplicationControlProperty;

namespace NSW.M2;

public static class Utils
{
    private static readonly string[] sourceArray = ["B", "U", "D"];

    public static (int pct, string label, double currentMiB, double totalMiB) CalculateProgress(long readBytes, long totalBytes, string label)
    {
        double currentMiB = (double)readBytes / 1024 / 1024;
        double totalMiB = (double)totalBytes / 1024 / 1024;

        int pct = totalBytes > 0 ? Math.Min(100, (int)((double)readBytes / totalBytes * 100)) : 0;
        string formattedLabel = $"{label}... {currentMiB:N2}MiB / {totalMiB:N2}MiB";

        return (pct, formattedLabel, currentMiB, totalMiB);
    }

    public static string ToAppVersionString()
    {
        string processPath = Environment.ProcessPath ?? string.Empty;
        var info = FileVersionInfo.GetVersionInfo(processPath);
        DateTime buildDate = File.GetLastWriteTime(processPath);

        return $"{info.ProductMajorPart}.{info.ProductMinorPart}.{info.ProductPrivatePart} (Build: {buildDate:yyyy'/'MM'/'dd})";
    }

    public static List<MetadataResult> GetMetadataFromContainer(KeySet ks, string path)
    {
        var results = new List<MetadataResult>();
        if (string.IsNullOrEmpty(path) || !File.Exists(path)) return results;

        using var storage = new LocalStorage(path, FileAccess.Read);
        IFileSystem fs;

        string ext = System.IO.Path.GetExtension(path).ToLower();
        if (ext is ".xci" or ".xcz")
        {
            var xci = new Xci(ks, storage);
            fs = xci.OpenPartition(XciPartitionType.Secure);
        }
        else
        {
            var pfs = new PartitionFileSystem();
            pfs.Initialize(storage).ThrowIfFailure();
            fs = pfs;
        }

        var allFiles = new Dictionary<string, IStorage>();
        foreach (var entry in fs.EnumerateEntries("/", "*"))
        {
            var file = new UniqueRef<IFile>();
            if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
            {
                allFiles.Add(entry.Name, file.Release().AsStream().AsStorage());
            }
        }

        var cnmtNcaNames = allFiles.Keys.Where(k => k.EndsWith(".cnmt.nca")).ToList();
        foreach (var cnmtName in cnmtNcaNames)
        {
            try
            {
                using var ncaStorage = new FileStorage(allFiles[cnmtName].AsFile(OpenMode.Read));
                var nca = new Nca(ks, ncaStorage);
                using var cnmtFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);

                var cnmtEntry = cnmtFs.EnumerateEntries("/", "*.cnmt").FirstOrDefault();
                if (cnmtEntry == null) continue;

                using var cFile = new UniqueRef<IFile>();
                cnmtFs.OpenFile(ref cFile.Ref, cnmtEntry.FullPath.ToU8Span(), OpenMode.Read).ThrowIfFailure();
                var cnmt = new Cnmt(cFile.Get.AsStream());

                string titleId = cnmt.TitleId.ToString("X16");
                uint version = cnmt.TitleVersion.Version;
                ContentMetaType type = cnmt.Type;

                string krTitle = string.Empty;
                string enTitle = string.Empty;
                string displayVer = "1.0.0";

                var ctrlRecord = cnmt.ContentEntries.FirstOrDefault(x => x.Type == LibHac.Ncm.ContentType.Control);
                if (ctrlRecord != null)
                {
                    string ctrlId = BitConverter.ToString(ctrlRecord.NcaId).Replace("-", "").ToLower();
                    string ctrlName = allFiles.Keys.FirstOrDefault(k => k.StartsWith(ctrlId));

                    if (ctrlName != null)
                    {
                        using var cs = new FileStorage(allFiles[ctrlName].AsFile(OpenMode.Read));
                        var cNca = new Nca(ks, cs);
                        using var ctrlFs = cNca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);

                        if (ctrlFs.FileExists("/control.nacp"))
                        {
                            using var nFile = new UniqueRef<IFile>();
                            ctrlFs.OpenFile(ref nFile.Ref, "/control.nacp".ToU8Span(), OpenMode.Read).ThrowIfFailure();
                            var nData = new byte[Marshal.SizeOf<ApplicationControlProperty>()];
                            nFile.Get.Read(out _, 0, nData).ThrowIfFailure();
                            var control = MemoryMarshal.Read<ApplicationControlProperty>(nData);

                            krTitle = control.Title[(int)Language.Korean].NameString.ToString().Trim('\0', ' ');
                            enTitle = control.Title[(int)Language.AmericanEnglish].NameString.ToString().Trim('\0', ' ');

                            if (string.IsNullOrWhiteSpace(krTitle))
                            {
                                foreach (var t in control.Title.Items)
                                {
                                    var name = t.NameString.ToString().Trim('\0', ' ');
                                    if (!string.IsNullOrWhiteSpace(name)) { krTitle = name; break; }
                                }
                            }
                            if (string.IsNullOrWhiteSpace(enTitle)) enTitle = krTitle;

                            displayVer = control.DisplayVersionString.ToString().Trim('\0', ' ');
                        }
                    }
                }

                results.Add(new MetadataResult(titleId, version, displayVer, krTitle, enTitle, 0, type, cnmtName));
            }
            catch { /* 개별 CNMT 분석 실패 시 스킵 */ }
        }

        foreach (var s in allFiles.Values) s.Dispose();
        if (fs is IDisposable d) d.Dispose();

        return results;
    }


    public static MetadataResult ExtractAggregateMetadata(KeySet ks, IEnumerable<string> paths, string updatePath)
    {
        string id = "";
        uint ver = 0;
        string kr = "";
        string en = "";
        string dVer = "1.0.0";
        int dlcCount = 0;

        foreach (var path in paths)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) continue;

            bool isUpdateFile = !string.IsNullOrEmpty(updatePath) && string.Equals(System.IO.Path.GetFullPath(path), System.IO.Path.GetFullPath(updatePath), StringComparison.OrdinalIgnoreCase);
            using var storage = new LocalStorage(path, FileAccess.Read);
            string ext = System.IO.Path.GetExtension(path).ToLower();

            IFileSystem fs = ext is ".xci" or ".xcz" ? new Xci(ks, storage).OpenPartition(XciPartitionType.Secure) : GetPfs(storage);

            foreach (var entry in fs.EnumerateEntries("/", "*"))
            {
                string fileExt = System.IO.Path.GetExtension(entry.Name).ToLower();
                if (fileExt is not (".nca" or ".ncz" or ".cnmt")) continue;

                using var file = new UniqueRef<IFile>();
                if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsFailure()) continue;

                using var stream = file.Get.AsStream();

                ProcessStreamMetadata(ks, stream, isUpdateFile, ref id, ref ver, ref kr, ref en, ref dVer, ref dlcCount);
            }
        }

        return new MetadataResult(id, ver, dVer, kr, en, dlcCount);
    }

    private static PartitionFileSystem GetPfs(IStorage storage)
    {
        var pfs = new PartitionFileSystem();
        pfs.Initialize(storage).IgnoreResult();
        return pfs;
    }

    private static void ProcessStreamMetadata(KeySet ks, Stream stream, bool isUpdate, ref string id, ref uint ver, ref string kr, ref string en, ref string dVer, ref int dlcCount)
    {
        try
        {
            var nca = new Nca(ks, stream.AsStorage());

            if (nca.Header.ContentType == NcaContentType.Meta)
            {
                using var ncaFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);
                foreach (var cnmtEntry in ncaFs.EnumerateEntries("/", "*.cnmt"))
                {
                    using var cnmtFile = new UniqueRef<IFile>();
                    if (ncaFs.OpenFile(ref cnmtFile.Ref, cnmtEntry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
                    {
                        var cnmt = new Cnmt(cnmtFile.Get.AsStream());
                        if (cnmt.Type == ContentMetaType.AddOnContent) dlcCount++;
                        else if (cnmt.Type == ContentMetaType.Application)
                        {
                            id = cnmt.TitleId.ToString("X16");
                            if (cnmt.TitleVersion.Version > ver) ver = cnmt.TitleVersion.Version;
                        }
                        else if (cnmt.Type == ContentMetaType.Patch)
                        {
                            if (cnmt.TitleVersion.Version > ver) ver = cnmt.TitleVersion.Version;
                        }
                    }
                }
            }
            else if (nca.Header.ContentType == NcaContentType.Control)
            {
                using var ncaFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);
                using var nacpFile = new UniqueRef<IFile>();
                if (ncaFs.OpenFile(ref nacpFile.Ref, "/control.nacp".ToU8Span(), OpenMode.Read).IsSuccess())
                {
                    var nacpData = new byte[System.Runtime.InteropServices.Marshal.SizeOf<ApplicationControlProperty>()];
                    nacpFile.Get.Read(out _, 0, nacpData).ThrowIfFailure();
                    var control = System.Runtime.InteropServices.MemoryMarshal.Read<ApplicationControlProperty>(nacpData);

                    string currentDisplayVer = control.DisplayVersionString.ToString().Trim('\0', ' ');
                    if (!string.IsNullOrWhiteSpace(currentDisplayVer))
                    {
                        if (isUpdate || string.IsNullOrEmpty(dVer) || dVer == "1.0.0")
                            dVer = currentDisplayVer;

                        string? foundKr = control.Title[12].NameString.ToString().Trim('\0', ' ');
                        if (string.IsNullOrWhiteSpace(foundKr))
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                string candidate = control.Title[i].NameString.ToString().Trim('\0', ' ');
                                if (!string.IsNullOrWhiteSpace(candidate)) { foundKr = candidate; break; }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(foundKr)) kr = foundKr;
                        string foundEn = control.Title[0].NameString.ToString().Trim('\0', ' ');
                        en = !string.IsNullOrWhiteSpace(foundEn) ? foundEn : foundKr ?? en;
                    }
                }
            }
        }
        catch { /* 분석 실패 시 기존 데이터 유지 */ }
    }

    public static string DetectFileType(string path, KeySet? keySet)
    {
        if (keySet == null) return "키없음";

        try
        {
            using var storage = new LocalStorage(path, FileAccess.Read);
            string ext = System.IO.Path.GetExtension(path).ToLowerInvariant();

            IFileSystem fs = ext switch
            {
                ".xci" or ".xcz" => new Xci(keySet, storage).OpenPartition(XciPartitionType.Secure),
                ".nsp" or ".nsz" => InitPfs(storage),
                _ => null!
            };
            if (fs == null) return "?";

            var foundTypes = new List<string>();

            var entries = fs.EnumerateEntries("/", "*.nca")
                .Concat(fs.EnumerateEntries("/", "*.ncz"))
                .Where(e => e.Type == DirectoryEntryType.File);

            foreach (var entry in entries)
            {
                using var ncaFile = new UniqueRef<IFile>();
                if (fs.OpenFile(ref ncaFile.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsFailure()) continue;

                try
                {
                    var nca = new Nca(keySet, ncaFile.Release().AsStorage());
                    if (nca.Header.ContentType != NcaContentType.Meta) continue;

                    using var metaFs = nca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);
                    foreach (var cnmtEntry in metaFs.EnumerateEntries("/", "*.cnmt"))
                    {
                        using var cnmtFile = new UniqueRef<IFile>();
                        if (metaFs.OpenFile(ref cnmtFile.Ref, cnmtEntry.FullPath.ToU8Span(), OpenMode.Read).IsFailure()) continue;

                        var cnmt = new LibHac.Tools.Ncm.Cnmt(cnmtFile.Get.AsStream());
                        string? t = cnmt.Type switch
                        {
                            LibHac.Ncm.ContentMetaType.Application => "B",
                            LibHac.Ncm.ContentMetaType.Patch => "U",
                            LibHac.Ncm.ContentMetaType.AddOnContent => "D",
                            _ => null,
                        };
                        if (t != null && !foundTypes.Contains(t)) foundTypes.Add(t);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"DetectFileType NCA 파싱 실패 ({entry.FullPath}): {ex.Message}");
                }
            }

            if (foundTypes.Count == 0) return "?";
            return string.Join("+", sourceArray.Where(foundTypes.Contains));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"DetectFileType 실패 ({path}): {ex.Message}");
            return "?";
        }
    }

    private static PartitionFileSystem InitPfs(LocalStorage storage)
    {
        var pfs = new PartitionFileSystem();
        pfs.Initialize(storage).ThrowIfFailure();
        return pfs;
    }

}
