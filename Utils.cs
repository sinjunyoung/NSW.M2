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

namespace NSW.M2;

public static class Utils
{
    private static readonly string[] sourceArray = ["B", "U", "D"];

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
