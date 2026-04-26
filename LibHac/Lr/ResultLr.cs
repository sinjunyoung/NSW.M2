//-----------------------------------------------------------------------------
// This file was automatically generated.
// Changes to this file will be lost when the file is regenerated.
//
// To change this file, modify /build/CodeGen/results.csv at the root of this
// repo and run the build script.
//
// The script can be run with the "codegen" option to run only the
// code generation portion of the build.
//-----------------------------------------------------------------------------

namespace LibHac.Lr;

public static class ResultLr
{
    public const int ModuleLr = 8;

    /// <summary>Error code: 2008-0001; Inner value: 0x208</summary>
    public static Result.Base ResolverNotFound => new(ModuleLr, 1);
    /// <summary>Error code: 2008-0002; Inner value: 0x408</summary>
    public static Result.Base ProgramNotFound => new(ModuleLr, 2);
    /// <summary>Error code: 2008-0003; Inner value: 0x608</summary>
    public static Result.Base DataNotFound => new(ModuleLr, 3);
    /// <summary>Error code: 2008-0004; Inner value: 0x808</summary>
    public static Result.Base UnknownResolver => new(ModuleLr, 4);
    /// <summary>Error code: 2008-0005; Inner value: 0xa08</summary>
    public static Result.Base ApplicationNotFound => new(ModuleLr, 5);
    /// <summary>Error code: 2008-0006; Inner value: 0xc08</summary>
    public static Result.Base HtmlDocumentNotFound => new(ModuleLr, 6);
    /// <summary>Error code: 2008-0007; Inner value: 0xe08</summary>
    public static Result.Base AddOnContentNotFound => new(ModuleLr, 7);
    /// <summary>Error code: 2008-0008; Inner value: 0x1008</summary>
    public static Result.Base ControlNotFound => new(ModuleLr, 8);
    /// <summary>Error code: 2008-0009; Inner value: 0x1208</summary>
    public static Result.Base LegalInformationNotFound => new(ModuleLr, 9);
    /// <summary>Error code: 2008-0010; Inner value: 0x1408</summary>
    public static Result.Base DebugProgramNotFound => new(ModuleLr, 10);
    /// <summary>Error code: 2008-0090; Inner value: 0xb408</summary>
    public static Result.Base TooManyRegisteredPaths => new(ModuleLr, 90);
}