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

namespace LibHac.Sf.Cmif;

public static class ResultCmif
{
    public const int ModuleSf = 10;

    /// <summary>Error code: 2010-0011; Inner value: 0x160a</summary>
    public static Result.Base CmifProxyAllocationFailed => new(ModuleSf, 11);
    /// <summary>Error code: 2010-0202; Inner value: 0x1940a</summary>
    public static Result.Base InvalidCmifHeaderSize => new(ModuleSf, 202);
    /// <summary>Error code: 2010-0211; Inner value: 0x1a60a</summary>
    public static Result.Base InvalidCmifInHeader => new(ModuleSf, 211);
    /// <summary>Error code: 2010-0212; Inner value: 0x1a80a</summary>
    public static Result.Base InvalidCmifOutHeader => new(ModuleSf, 212);
    /// <summary>Error code: 2010-0221; Inner value: 0x1ba0a</summary>
    public static Result.Base UnknownMethodId => new(ModuleSf, 221);
    /// <summary>Error code: 2010-0231; Inner value: 0x1ce0a</summary>
    public static Result.Base InvalidInRawSize => new(ModuleSf, 231);
    /// <summary>Error code: 2010-0232; Inner value: 0x1d00a</summary>
    public static Result.Base InvalidOutRawSize => new(ModuleSf, 232);
    /// <summary>Error code: 2010-0235; Inner value: 0x1d60a</summary>
    public static Result.Base InvalidInObjectCount => new(ModuleSf, 235);
    /// <summary>Error code: 2010-0236; Inner value: 0x1d80a</summary>
    public static Result.Base InvalidOutObjectCount => new(ModuleSf, 236);
    /// <summary>Error code: 2010-0239; Inner value: 0x1de0a</summary>
    public static Result.Base InvalidInObject => new(ModuleSf, 239);
    /// <summary>Error code: 2010-0261; Inner value: 0x20a0a</summary>
    public static Result.Base TargetObjectNotFound => new(ModuleSf, 261);
    /// <summary>Error code: 2010-0301; Inner value: 0x25a0a</summary>
    public static Result.Base OutOfDomainEntry => new(ModuleSf, 301);
}