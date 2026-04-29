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
using System.Runtime.InteropServices;

using static LibHac.Ns.ApplicationControlProperty;

namespace NSW.Core;

public static class Utils
{
    public static string GetContentMetaTypeTag(ContentMetaType type) => type switch
    {
        ContentMetaType.Application => "BASE",
        ContentMetaType.Patch => "UPDATE",
        ContentMetaType.AddOnContent => "DLC",
        ContentMetaType.Delta => "DLC",
        _ => type.ToString().ToUpper()
    };

    private static readonly string[] sourceArray = ["B", "U", "D"];

    public static string DetectFileType(string path, KeySet? keySet)
    {
        if (keySet == null) return "Not Key";

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

                        var cnmt = new Cnmt(cnmtFile.Get.AsStream());
                        string? t = cnmt.Type switch
                        {
                            ContentMetaType.Application => "B",
                            ContentMetaType.Patch => "U",
                            ContentMetaType.AddOnContent => "D",
                            _ => null,
                        };
                        if (t != null && !foundTypes.Contains(t)) foundTypes.Add(t);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"DetectFileType NCA parsing fail ({entry.FullPath}): {ex.Message}");
                }
            }

            if (foundTypes.Count == 0) return "?";
            return string.Join("+", sourceArray.Where(foundTypes.Contains));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"DetectFileType fail ({path}): {ex.Message}");
            return "?";
        }
    }

    private static PartitionFileSystem InitPfs(LocalStorage storage)
    {
        var pfs = new PartitionFileSystem();
        pfs.Initialize(storage).ThrowIfFailure();
        return pfs;
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

        var allFiles = new Dictionary<string, IStorage>(StringComparer.OrdinalIgnoreCase);
        foreach (var entry in fs.EnumerateEntries("/", "*"))
        {
            var file = new UniqueRef<IFile>();
            if (fs.OpenFile(ref file.Ref, entry.FullPath.ToU8Span(), OpenMode.Read).IsSuccess())
                allFiles[entry.Name] = file.Release().AsStream().AsStorage();
        }

        foreach (var cnmtNcaName in allFiles.Keys.Where(k =>
            k.EndsWith(".cnmt.nca", StringComparison.OrdinalIgnoreCase)))
        {
            try
            {
                using var ncaStorage = new FileStorage(allFiles[cnmtNcaName].AsFile(OpenMode.Read));
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

                var contentNcaIds = cnmt.ContentEntries
                    .Select(e => BitConverter.ToString(e.NcaId).Replace("-", "").ToLowerInvariant())
                    .ToList();

                string selfNcaId = System.IO.Path.GetFileNameWithoutExtension(
                    System.IO.Path.GetFileNameWithoutExtension(cnmtNcaName));
                if (!string.IsNullOrEmpty(selfNcaId))
                    contentNcaIds.Add(selfNcaId.ToLowerInvariant());

                string krTitle = string.Empty;
                string enTitle = string.Empty;
                string displayVer = "1.0.0";

                var ctrlRecord = cnmt.ContentEntries
                    .FirstOrDefault(x => x.Type == LibHac.Ncm.ContentType.Control);

                if (ctrlRecord != null)
                {
                    string ctrlId = BitConverter.ToString(ctrlRecord.NcaId)
                        .Replace("-", "").ToLowerInvariant();

                    string? ctrlName = allFiles.Keys.FirstOrDefault(k =>
                        k.StartsWith(ctrlId, StringComparison.OrdinalIgnoreCase));

                    if (ctrlName != null)
                    {
                        using var cs = new FileStorage(allFiles[ctrlName].AsFile(OpenMode.Read));
                        var cNca = new Nca(ks, cs);
                        using var ctrlFs = cNca.OpenFileSystem(NcaSectionType.Data, IntegrityCheckLevel.None);

                        if (ctrlFs.FileExists("/control.nacp"))
                        {
                            using var nFile = new UniqueRef<IFile>();
                            ctrlFs.OpenFile(ref nFile.Ref, "/control.nacp".ToU8Span(), OpenMode.Read)
                                .ThrowIfFailure();

                            var nData = new byte[Marshal.SizeOf<ApplicationControlProperty>()];
                            nFile.Get.Read(out _, 0, nData);

                            var control = MemoryMarshal.Read<ApplicationControlProperty>(nData);

                            krTitle = control.Title[(int)Language.Korean].NameString
                                .ToString().Trim('\0', ' ');
                            enTitle = control.Title[(int)Language.AmericanEnglish].NameString
                                .ToString().Trim('\0', ' ');

                            if (string.IsNullOrWhiteSpace(krTitle))
                            {
                                foreach (ApplicationTitle t in control.Title)
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

                results.Add(new MetadataResult(titleId, version, displayVer, krTitle, enTitle, 0, type, cnmtNcaName, path, contentNcaIds
                ));
            }
            catch
            { throw; }
        }

        foreach (var s in allFiles.Values) s.Dispose();
        if (fs is IDisposable d) d.Dispose();

        return results;
    }
}