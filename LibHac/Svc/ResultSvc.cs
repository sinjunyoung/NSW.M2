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

namespace LibHac.Svc;

public static class ResultSvc
{
    public const int ModuleSvc = 1;

    /// <summary>Error code: 2001-0007; Inner value: 0xe01</summary>
    public static Result.Base OutOfSessions => new(ModuleSvc, 7);
    /// <summary>Error code: 2001-0014; Inner value: 0x1c01</summary>
    public static Result.Base InvalidArgument => new(ModuleSvc, 14);
    /// <summary>Error code: 2001-0033; Inner value: 0x4201</summary>
    public static Result.Base NotImplemented => new(ModuleSvc, 33);
    /// <summary>Error code: 2001-0054; Inner value: 0x6c01</summary>
    public static Result.Base StopProcessingException => new(ModuleSvc, 54);
    /// <summary>Error code: 2001-0057; Inner value: 0x7201</summary>
    public static Result.Base NoSynchronizationObject => new(ModuleSvc, 57);
    /// <summary>Error code: 2001-0059; Inner value: 0x7601</summary>
    public static Result.Base TerminationRequested => new(ModuleSvc, 59);
    /// <summary>Error code: 2001-0070; Inner value: 0x8c01</summary>
    public static Result.Base NoEvent => new(ModuleSvc, 70);
    /// <summary>Error code: 2001-0101; Inner value: 0xca01</summary>
    public static Result.Base InvalidSize => new(ModuleSvc, 101);
    /// <summary>Error code: 2001-0102; Inner value: 0xcc01</summary>
    public static Result.Base InvalidAddress => new(ModuleSvc, 102);
    /// <summary>Error code: 2001-0103; Inner value: 0xce01</summary>
    public static Result.Base OutOfResource => new(ModuleSvc, 103);
    /// <summary>Error code: 2001-0104; Inner value: 0xd001</summary>
    public static Result.Base OutOfMemory => new(ModuleSvc, 104);
    /// <summary>Error code: 2001-0105; Inner value: 0xd201</summary>
    public static Result.Base OutOfHandles => new(ModuleSvc, 105);
    /// <summary>Error code: 2001-0106; Inner value: 0xd401</summary>
    public static Result.Base InvalidCurrentMemory => new(ModuleSvc, 106);
    /// <summary>Error code: 2001-0108; Inner value: 0xd801</summary>
    public static Result.Base InvalidNewMemoryPermission => new(ModuleSvc, 108);
    /// <summary>Error code: 2001-0110; Inner value: 0xdc01</summary>
    public static Result.Base InvalidMemoryRegion => new(ModuleSvc, 110);
    /// <summary>Error code: 2001-0112; Inner value: 0xe001</summary>
    public static Result.Base InvalidPriority => new(ModuleSvc, 112);
    /// <summary>Error code: 2001-0113; Inner value: 0xe201</summary>
    public static Result.Base InvalidCoreId => new(ModuleSvc, 113);
    /// <summary>Error code: 2001-0114; Inner value: 0xe401</summary>
    public static Result.Base InvalidHandle => new(ModuleSvc, 114);
    /// <summary>Error code: 2001-0115; Inner value: 0xe601</summary>
    public static Result.Base InvalidPointer => new(ModuleSvc, 115);
    /// <summary>Error code: 2001-0116; Inner value: 0xe801</summary>
    public static Result.Base InvalidCombination => new(ModuleSvc, 116);
    /// <summary>Error code: 2001-0117; Inner value: 0xea01</summary>
    public static Result.Base TimedOut => new(ModuleSvc, 117);
    /// <summary>Error code: 2001-0118; Inner value: 0xec01</summary>
    public static Result.Base Cancelled => new(ModuleSvc, 118);
    /// <summary>Error code: 2001-0119; Inner value: 0xee01</summary>
    public static Result.Base OutOfRange => new(ModuleSvc, 119);
    /// <summary>Error code: 2001-0120; Inner value: 0xf001</summary>
    public static Result.Base InvalidEnumValue => new(ModuleSvc, 120);
    /// <summary>Error code: 2001-0121; Inner value: 0xf201</summary>
    public static Result.Base NotFound => new(ModuleSvc, 121);
    /// <summary>Error code: 2001-0122; Inner value: 0xf401</summary>
    public static Result.Base Busy => new(ModuleSvc, 122);
    /// <summary>Error code: 2001-0123; Inner value: 0xf601</summary>
    public static Result.Base SessionClosed => new(ModuleSvc, 123);
    /// <summary>Error code: 2001-0124; Inner value: 0xf801</summary>
    public static Result.Base NotHandled => new(ModuleSvc, 124);
    /// <summary>Error code: 2001-0125; Inner value: 0xfa01</summary>
    public static Result.Base InvalidState => new(ModuleSvc, 125);
    /// <summary>Error code: 2001-0126; Inner value: 0xfc01</summary>
    public static Result.Base ReservedUsed => new(ModuleSvc, 126);
    /// <summary>Error code: 2001-0127; Inner value: 0xfe01</summary>
    public static Result.Base NotSupported => new(ModuleSvc, 127);
    /// <summary>Error code: 2001-0128; Inner value: 0x10001</summary>
    public static Result.Base Debug => new(ModuleSvc, 128);
    /// <summary>Error code: 2001-0129; Inner value: 0x10201</summary>
    public static Result.Base NoThread => new(ModuleSvc, 129);
    /// <summary>Error code: 2001-0130; Inner value: 0x10401</summary>
    public static Result.Base UnknownThread => new(ModuleSvc, 130);
    /// <summary>Error code: 2001-0131; Inner value: 0x10601</summary>
    public static Result.Base PortClosed => new(ModuleSvc, 131);
    /// <summary>Error code: 2001-0132; Inner value: 0x10801</summary>
    public static Result.Base LimitReached => new(ModuleSvc, 132);
    /// <summary>Error code: 2001-0133; Inner value: 0x10a01</summary>
    public static Result.Base InvalidMemoryPool => new(ModuleSvc, 133);
    /// <summary>Error code: 2001-0258; Inner value: 0x20401</summary>
    public static Result.Base ReceiveListBroken => new(ModuleSvc, 258);
    /// <summary>Error code: 2001-0259; Inner value: 0x20601</summary>
    public static Result.Base OutOfAddressSpace => new(ModuleSvc, 259);
    /// <summary>Error code: 2001-0260; Inner value: 0x20801</summary>
    public static Result.Base MessageTooLarge => new(ModuleSvc, 260);
    /// <summary>Error code: 2001-0517; Inner value: 0x40a01</summary>
    public static Result.Base InvalidProcessId => new(ModuleSvc, 517);
    /// <summary>Error code: 2001-0518; Inner value: 0x40c01</summary>
    public static Result.Base InvalidThreadId => new(ModuleSvc, 518);
    /// <summary>Error code: 2001-0519; Inner value: 0x40e01</summary>
    public static Result.Base InvalidId => new(ModuleSvc, 519);
    /// <summary>Error code: 2001-0520; Inner value: 0x41001</summary>
    public static Result.Base ProcessTerminated => new(ModuleSvc, 520);
}