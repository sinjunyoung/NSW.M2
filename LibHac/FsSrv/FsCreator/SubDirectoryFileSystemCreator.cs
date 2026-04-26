using LibHac.Common;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;

namespace LibHac.FsSrv.FsCreator;

public class SubDirectoryFileSystemCreator : ISubDirectoryFileSystemCreator
{
    public Result Create(ref SharedRef<IFileSystem> outSubDirFileSystem, ref readonly SharedRef<IFileSystem> baseFileSystem,
        ref readonly Path path)
    {
        using UniqueRef<IDirectory> directory = new();

        Result res = baseFileSystem.Get.OpenDirectory(ref directory.Ref, in path, OpenDirectoryMode.Directory);
        if (res.IsFailure()) return res.Miss();

        directory.Reset();

        using SharedRef<SubdirectoryFileSystem> subFs = new(new SubdirectoryFileSystem(in baseFileSystem));

        if (!subFs.HasValue)
            return ResultFs.AllocationMemoryFailedInSubDirectoryFileSystemCreatorA.Log();

        res = subFs.Get.Initialize(in path);
        if (res.IsFailure()) return res.Miss();

        outSubDirFileSystem.SetByMove(ref subFs.Ref);
        return Result.Success;
    }
}