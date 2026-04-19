using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.NSZ;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using System.IO;
using Path = System.IO.Path;

namespace NSW.M2.Services;

public static class NspHelper
{
    public static IFileSystem OpenFileSystem(string path, IStorage storage, KeySet keySet)
    {
        string ext = Path.GetExtension(path).ToLower();
        if (ext is ".xci" or ".xcz")
        {
            var xci = new Xci(keySet, storage);
            return xci.OpenPartition(XciPartitionType.Secure);
        }
        var pfs = new PartitionFileSystem();
        pfs.Initialize(storage).IgnoreResult();
        return pfs;
    }

    public static Stream GetDecodedStream(IFile file, string fileName, KeySet keySet)
    {
        var stream = file.AsStream();
        if (Path.GetExtension(fileName).Equals(".ncz", StringComparison.CurrentCultureIgnoreCase))
        {
            var ncz = new Ncz(keySet, stream, NczReadMode.Original);
            return ncz.BaseStorage.AsStream();
        }
        return stream;
    }

    public static Stream GetEncodedStream(IFile file, KeySet keySet, int level)
    {
        var nca = new Nca(keySet, file.AsStorage());
        if (nca.Header.ContentType is NcaContentType.Program or NcaContentType.PublicData)
        {
            var ms = new MemoryStream();
            NcaToNczConverter.Convert(file.AsStream(), ms, keySet, level);
            ms.Position = 0;
            return ms;
        }
        return file.AsStream();
    }
}