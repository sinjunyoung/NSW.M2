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

using System.Runtime.CompilerServices;

namespace LibHac.Fs;

public static class ResultFs
{
    public const int ModuleFs = 2;

    /// <summary>Error code: 2002-0000; Range: 0-999; Inner value: 0x2</summary>
    public static Result.Base HandledByAllProcess => new(ModuleFs, 0, 999);
        /// <summary>Specified path does not exist<br/>Error code: 2002-0001; Inner value: 0x202</summary>
        public static Result.Base PathNotFound => new(ModuleFs, 1);
        /// <summary>Specified path already exists<br/>Error code: 2002-0002; Inner value: 0x402</summary>
        public static Result.Base PathAlreadyExists => new(ModuleFs, 2);
        /// <summary>Resource already in use (file already opened, savedata filesystem already mounted)<br/>Error code: 2002-0007; Inner value: 0xe02</summary>
        public static Result.Base TargetLocked => new(ModuleFs, 7);
        /// <summary>Specified directory is not empty when trying to delete it<br/>Error code: 2002-0008; Inner value: 0x1002</summary>
        public static Result.Base DirectoryNotEmpty => new(ModuleFs, 8);
        /// <summary>Error code: 2002-0013; Inner value: 0x1a02</summary>
        public static Result.Base DirectoryStatusChanged => new(ModuleFs, 13);

        /// <summary>Error code: 2002-0030; Range: 30-45; Inner value: 0x3c02</summary>
        public static Result.Base UsableSpaceNotEnough => new(ModuleFs, 30, 45);
            /// <summary>Error code: 2002-0031; Inner value: 0x3e02</summary>
            public static Result.Base UsableSpaceNotEnoughForSaveData => new(ModuleFs, 31);
            /// <summary>Error code: 2002-0032; Inner value: 0x4002</summary>
            public static Result.Base UsableSpaceNotEnoughForSaveDataEvenAssistanceSuccess => new(ModuleFs, 32);
            /// <summary>Error code: 2002-0033; Inner value: 0x4202</summary>
            public static Result.Base UsableSpaceNotEnoughForCacheStorage => new(ModuleFs, 33);

            /// <summary>Error code: 2002-0034; Range: 34-38; Inner value: 0x4402</summary>
            public static Result.Base UsableSpaceNotEnoughMmc => new(ModuleFs, 34, 38);
                /// <summary>Error code: 2002-0035; Inner value: 0x4602</summary>
                public static Result.Base UsableSpaceNotEnoughMmcCalibration => new(ModuleFs, 35);
                /// <summary>Error code: 2002-0036; Inner value: 0x4802</summary>
                public static Result.Base UsableSpaceNotEnoughMmcSafe => new(ModuleFs, 36);
                /// <summary>Error code: 2002-0037; Inner value: 0x4a02</summary>
                public static Result.Base UsableSpaceNotEnoughMmcUser => new(ModuleFs, 37);
                /// <summary>Error code: 2002-0038; Inner value: 0x4c02</summary>
                public static Result.Base UsableSpaceNotEnoughMmcSystem => new(ModuleFs, 38);

            /// <summary>Error code: 2002-0039; Inner value: 0x4e02</summary>
            public static Result.Base UsableSpaceNotEnoughSdCard => new(ModuleFs, 39);

        /// <summary>Error code: 2002-0050; Inner value: 0x6402</summary>
        public static Result.Base UnsupportedSdkVersion => new(ModuleFs, 50);
        /// <summary>Error code: 2002-0060; Inner value: 0x7802</summary>
        public static Result.Base MountNameAlreadyExists => new(ModuleFs, 60);
        /// <summary>Error code: 2002-0070; Inner value: 0x8c02</summary>
        public static Result.Base IndividualFileDataCacheAlreadyEnabled => new(ModuleFs, 70);

    /// <summary>Error code: 2002-1000; Range: 1000-2999; Inner value: 0x7d002</summary>
    public static Result.Base HandledBySystemProcess { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 1000, 2999); }
        /// <summary>Error code: 2002-1001; Inner value: 0x7d202</summary>
        public static Result.Base PartitionNotFound => new(ModuleFs, 1001);
        /// <summary>Error code: 2002-1002; Inner value: 0x7d402</summary>
        public static Result.Base TargetNotFound => new(ModuleFs, 1002);
        /// <summary>Error code: 2002-1003; Inner value: 0x7d602</summary>
        public static Result.Base HasNotGottenPatrolCount => new(ModuleFs, 1003);
        /// <summary>The requested external key was not found<br/>Error code: 2002-1004; Inner value: 0x7d802</summary>
        public static Result.Base NcaExternalKeyUnregistered => new(ModuleFs, 1004);

        /// <summary>Error code: 2002-2000; Range: 2000-2499; Inner value: 0xfa002</summary>
        public static Result.Base SdCardAccessFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2000, 2499); }
            /// <summary>Error code: 2002-2001; Inner value: 0xfa202</summary>
            public static Result.Base PortSdCardNoDevice => new(ModuleFs, 2001);
            /// <summary>Error code: 2002-2002; Inner value: 0xfa402</summary>
            public static Result.Base PortSdCardNotActivated => new(ModuleFs, 2002);
            /// <summary>Error code: 2002-2003; Inner value: 0xfa602</summary>
            public static Result.Base PortSdCardDeviceRemoved => new(ModuleFs, 2003);
            /// <summary>Error code: 2002-2004; Inner value: 0xfa802</summary>
            public static Result.Base PortSdCardNotAwakened => new(ModuleFs, 2004);

            /// <summary>Error code: 2002-2032; Range: 2032-2126; Inner value: 0xfe002</summary>
            public static Result.Base PortSdCardCommunicationError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2032, 2126); }
                /// <summary>Error code: 2002-2033; Range: 2033-2046; Inner value: 0xfe202</summary>
                public static Result.Base PortSdCardCommunicationNotAttained { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2033, 2046); }
                    /// <summary>Error code: 2002-2034; Inner value: 0xfe402</summary>
                    public static Result.Base PortSdCardResponseIndexError => new(ModuleFs, 2034);
                    /// <summary>Error code: 2002-2035; Inner value: 0xfe602</summary>
                    public static Result.Base PortSdCardResponseEndBitError => new(ModuleFs, 2035);
                    /// <summary>Error code: 2002-2036; Inner value: 0xfe802</summary>
                    public static Result.Base PortSdCardResponseCrcError => new(ModuleFs, 2036);
                    /// <summary>Error code: 2002-2037; Inner value: 0xfea02</summary>
                    public static Result.Base PortSdCardResponseTimeoutError => new(ModuleFs, 2037);
                    /// <summary>Error code: 2002-2038; Inner value: 0xfec02</summary>
                    public static Result.Base PortSdCardDataEndBitError => new(ModuleFs, 2038);
                    /// <summary>Error code: 2002-2039; Inner value: 0xfee02</summary>
                    public static Result.Base PortSdCardDataCrcError => new(ModuleFs, 2039);
                    /// <summary>Error code: 2002-2040; Inner value: 0xff002</summary>
                    public static Result.Base PortSdCardDataTimeoutError => new(ModuleFs, 2040);
                    /// <summary>Error code: 2002-2041; Inner value: 0xff202</summary>
                    public static Result.Base PortSdCardAutoCommandResponseIndexError => new(ModuleFs, 2041);
                    /// <summary>Error code: 2002-2042; Inner value: 0xff402</summary>
                    public static Result.Base PortSdCardAutoCommandResponseEndBitError => new(ModuleFs, 2042);
                    /// <summary>Error code: 2002-2043; Inner value: 0xff602</summary>
                    public static Result.Base PortSdCardAutoCommandResponseCrcError => new(ModuleFs, 2043);
                    /// <summary>Error code: 2002-2044; Inner value: 0xff802</summary>
                    public static Result.Base PortSdCardAutoCommandResponseTimeoutError => new(ModuleFs, 2044);
                    /// <summary>Error code: 2002-2045; Inner value: 0xffa02</summary>
                    public static Result.Base PortSdCardCommandCompleteSwTimeout => new(ModuleFs, 2045);
                    /// <summary>Error code: 2002-2046; Inner value: 0xffc02</summary>
                    public static Result.Base PortSdCardTransferCompleteSwTimeout => new(ModuleFs, 2046);

                /// <summary>Error code: 2002-2048; Range: 2048-2070; Inner value: 0x100002</summary>
                public static Result.Base PortSdCardDeviceStatusHasError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2048, 2070); }
                    /// <summary>Error code: 2002-2049; Inner value: 0x100202</summary>
                    public static Result.Base PortSdCardDeviceStatusAddressOutOfRange => new(ModuleFs, 2049);
                    /// <summary>Error code: 2002-2050; Inner value: 0x100402</summary>
                    public static Result.Base PortSdCardDeviceStatusAddressMisalign => new(ModuleFs, 2050);
                    /// <summary>Error code: 2002-2051; Inner value: 0x100602</summary>
                    public static Result.Base PortSdCardDeviceStatusBlockLenError => new(ModuleFs, 2051);
                    /// <summary>Error code: 2002-2052; Inner value: 0x100802</summary>
                    public static Result.Base PortSdCardDeviceStatusEraseSeqError => new(ModuleFs, 2052);
                    /// <summary>Error code: 2002-2053; Inner value: 0x100a02</summary>
                    public static Result.Base PortSdCardDeviceStatusEraseParam => new(ModuleFs, 2053);
                    /// <summary>Error code: 2002-2054; Inner value: 0x100c02</summary>
                    public static Result.Base PortSdCardDeviceStatusWpViolation => new(ModuleFs, 2054);
                    /// <summary>Error code: 2002-2055; Inner value: 0x100e02</summary>
                    public static Result.Base PortSdCardDeviceStatusLockUnlockFailed => new(ModuleFs, 2055);
                    /// <summary>Error code: 2002-2056; Inner value: 0x101002</summary>
                    public static Result.Base PortSdCardDeviceStatusComCrcError => new(ModuleFs, 2056);
                    /// <summary>Error code: 2002-2057; Inner value: 0x101202</summary>
                    public static Result.Base PortSdCardDeviceStatusIllegalCommand => new(ModuleFs, 2057);
                    /// <summary>Error code: 2002-2058; Inner value: 0x101402</summary>
                    public static Result.Base PortSdCardDeviceStatusDeviceEccFailed => new(ModuleFs, 2058);
                    /// <summary>Error code: 2002-2059; Inner value: 0x101602</summary>
                    public static Result.Base PortSdCardDeviceStatusCcError => new(ModuleFs, 2059);
                    /// <summary>Error code: 2002-2060; Inner value: 0x101802</summary>
                    public static Result.Base PortSdCardDeviceStatusError => new(ModuleFs, 2060);
                    /// <summary>Error code: 2002-2061; Inner value: 0x101a02</summary>
                    public static Result.Base PortSdCardDeviceStatusCidCsdOverwrite => new(ModuleFs, 2061);
                    /// <summary>Error code: 2002-2062; Inner value: 0x101c02</summary>
                    public static Result.Base PortSdCardDeviceStatusWpEraseSkip => new(ModuleFs, 2062);
                    /// <summary>Error code: 2002-2063; Inner value: 0x101e02</summary>
                    public static Result.Base PortSdCardDeviceStatusEraseReset => new(ModuleFs, 2063);
                    /// <summary>Error code: 2002-2064; Inner value: 0x102002</summary>
                    public static Result.Base PortSdCardDeviceStatusSwitchError => new(ModuleFs, 2064);

                /// <summary>Error code: 2002-2072; Inner value: 0x103002</summary>
                public static Result.Base PortSdCardUnexpectedDeviceState => new(ModuleFs, 2072);
                /// <summary>Error code: 2002-2073; Inner value: 0x103202</summary>
                public static Result.Base PortSdCardUnexpectedDeviceCsdValue => new(ModuleFs, 2073);
                /// <summary>Error code: 2002-2074; Inner value: 0x103402</summary>
                public static Result.Base PortSdCardAbortTransactionSwTimeout => new(ModuleFs, 2074);
                /// <summary>Error code: 2002-2075; Inner value: 0x103602</summary>
                public static Result.Base PortSdCardCommandInhibitCmdSwTimeout => new(ModuleFs, 2075);
                /// <summary>Error code: 2002-2076; Inner value: 0x103802</summary>
                public static Result.Base PortSdCardCommandInhibitDatSwTimeout => new(ModuleFs, 2076);
                /// <summary>Error code: 2002-2077; Inner value: 0x103a02</summary>
                public static Result.Base PortSdCardBusySwTimeout => new(ModuleFs, 2077);
                /// <summary>Error code: 2002-2078; Inner value: 0x103c02</summary>
                public static Result.Base PortSdCardIssueTuningCommandSwTimeout => new(ModuleFs, 2078);
                /// <summary>Error code: 2002-2079; Inner value: 0x103e02</summary>
                public static Result.Base PortSdCardTuningFailed => new(ModuleFs, 2079);
                /// <summary>Error code: 2002-2080; Inner value: 0x104002</summary>
                public static Result.Base PortSdCardMmcInitializationSwTimeout => new(ModuleFs, 2080);
                /// <summary>Error code: 2002-2081; Inner value: 0x104202</summary>
                public static Result.Base PortSdCardMmcNotSupportExtendedCsd => new(ModuleFs, 2081);
                /// <summary>Error code: 2002-2082; Inner value: 0x104402</summary>
                public static Result.Base PortSdCardUnexpectedMmcExtendedCsdValue => new(ModuleFs, 2082);
                /// <summary>Error code: 2002-2083; Inner value: 0x104602</summary>
                public static Result.Base PortSdCardMmcEraseSwTimeout => new(ModuleFs, 2083);
                /// <summary>Error code: 2002-2084; Inner value: 0x104802</summary>
                public static Result.Base PortSdCardSdCardValidationError => new(ModuleFs, 2084);
                /// <summary>Error code: 2002-2085; Inner value: 0x104a02</summary>
                public static Result.Base PortSdCardSdCardInitializationSwTimeout => new(ModuleFs, 2085);
                /// <summary>Error code: 2002-2086; Inner value: 0x104c02</summary>
                public static Result.Base PortSdCardSdCardGetValidRcaSwTimeout => new(ModuleFs, 2086);
                /// <summary>Error code: 2002-2087; Inner value: 0x104e02</summary>
                public static Result.Base PortSdCardUnexpectedSdCardAcmdDisabled => new(ModuleFs, 2087);
                /// <summary>Error code: 2002-2088; Inner value: 0x105002</summary>
                public static Result.Base PortSdCardSdCardNotSupportSwitchFunctionStatus => new(ModuleFs, 2088);
                /// <summary>Error code: 2002-2089; Inner value: 0x105202</summary>
                public static Result.Base PortSdCardUnexpectedSdCardSwitchFunctionStatus => new(ModuleFs, 2089);
                /// <summary>Error code: 2002-2090; Inner value: 0x105402</summary>
                public static Result.Base PortSdCardSdCardNotSupportAccessMode => new(ModuleFs, 2090);
                /// <summary>Error code: 2002-2091; Inner value: 0x105602</summary>
                public static Result.Base PortSdCardSdCardNot4BitBusWidthAtUhsIMode => new(ModuleFs, 2091);
                /// <summary>Error code: 2002-2092; Inner value: 0x105802</summary>
                public static Result.Base PortSdCardSdCardNotSupportSdr104AndSdr50 => new(ModuleFs, 2092);
                /// <summary>Error code: 2002-2093; Inner value: 0x105a02</summary>
                public static Result.Base PortSdCardSdCardCannotSwitchedAccessMode => new(ModuleFs, 2093);
                /// <summary>Error code: 2002-2094; Inner value: 0x105c02</summary>
                public static Result.Base PortSdCardSdCardFailedSwitchedAccessMode => new(ModuleFs, 2094);
                /// <summary>Error code: 2002-2095; Inner value: 0x105e02</summary>
                public static Result.Base PortSdCardSdCardUnacceptableCurrentConsumption => new(ModuleFs, 2095);
                /// <summary>Error code: 2002-2096; Inner value: 0x106002</summary>
                public static Result.Base PortSdCardSdCardNotReadyToVoltageSwitch => new(ModuleFs, 2096);
                /// <summary>Error code: 2002-2097; Inner value: 0x106202</summary>
                public static Result.Base PortSdCardSdCardNotCompleteVoltageSwitch => new(ModuleFs, 2097);

            /// <summary>Error code: 2002-2128; Range: 2128-2158; Inner value: 0x10a002</summary>
            public static Result.Base PortSdCardHostControllerUnexpected { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2128, 2158); }
                /// <summary>Error code: 2002-2129; Inner value: 0x10a202</summary>
                public static Result.Base PortSdCardInternalClockStableSwTimeout => new(ModuleFs, 2129);
                /// <summary>Error code: 2002-2130; Inner value: 0x10a402</summary>
                public static Result.Base PortSdCardSdHostStandardUnknownAutoCmdError => new(ModuleFs, 2130);
                /// <summary>Error code: 2002-2131; Inner value: 0x10a602</summary>
                public static Result.Base PortSdCardSdHostStandardUnknownError => new(ModuleFs, 2131);
                /// <summary>Error code: 2002-2132; Inner value: 0x10a802</summary>
                public static Result.Base PortSdCardSdmmcDllCalibrationSwTimeout => new(ModuleFs, 2132);
                /// <summary>Error code: 2002-2133; Inner value: 0x10aa02</summary>
                public static Result.Base PortSdCardSdmmcDllApplicationSwTimeout => new(ModuleFs, 2133);
                /// <summary>Error code: 2002-2134; Inner value: 0x10ac02</summary>
                public static Result.Base PortSdCardSdHostStandardFailSwitchTo18V => new(ModuleFs, 2134);

            /// <summary>Error code: 2002-2160; Range: 2160-2190; Inner value: 0x10e002</summary>
            public static Result.Base PortSdCardInternalError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2160, 2190); }
                /// <summary>Error code: 2002-2161; Inner value: 0x10e202</summary>
                public static Result.Base PortSdCardNoWaitedInterrupt => new(ModuleFs, 2161);
                /// <summary>Error code: 2002-2162; Inner value: 0x10e402</summary>
                public static Result.Base PortSdCardWaitInterruptSwTimeout => new(ModuleFs, 2162);

            /// <summary>Error code: 2002-2192; Inner value: 0x112002</summary>
            public static Result.Base PortSdCardAbortCommandIssued => new(ModuleFs, 2192);
            /// <summary>Error code: 2002-2200; Inner value: 0x113002</summary>
            public static Result.Base PortSdCardNotSupported => new(ModuleFs, 2200);
            /// <summary>Error code: 2002-2201; Inner value: 0x113202</summary>
            public static Result.Base PortSdCardNotImplemented => new(ModuleFs, 2201);
            /// <summary>Error code: 2002-2496; Inner value: 0x138002</summary>
            public static Result.Base PortSdCardStorageDeviceInvalidated => new(ModuleFs, 2496);
            /// <summary>Error code: 2002-2497; Inner value: 0x138202</summary>
            public static Result.Base PortSdCardWriteVerifyError => new(ModuleFs, 2497);
            /// <summary>Error code: 2002-2498; Inner value: 0x138402</summary>
            public static Result.Base PortSdCardFileSystemInvalidatedByRemoved => new(ModuleFs, 2498);
            /// <summary>Error code: 2002-2499; Inner value: 0x138602</summary>
            public static Result.Base PortSdCardUnexpected => new(ModuleFs, 2499);

        /// <summary>Error code: 2002-2500; Range: 2500-2999; Inner value: 0x138802</summary>
        public static Result.Base GameCardAccessFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2500, 2999); }
            /// <summary>Error code: 2002-2501; Inner value: 0x138a02</summary>
            public static Result.Base GameCardUnknown => new(ModuleFs, 2501);
            /// <summary>Error code: 2002-2502; Inner value: 0x138c02</summary>
            public static Result.Base GameCardUnexpectedDeadCode => new(ModuleFs, 2502);
            /// <summary>Error code: 2002-2503; Inner value: 0x138e02</summary>
            public static Result.Base GameCardPreconditionViolation => new(ModuleFs, 2503);
            /// <summary>Error code: 2002-2504; Inner value: 0x139002</summary>
            public static Result.Base GameCardNotImplemented => new(ModuleFs, 2504);
            /// <summary>Error code: 2002-2510; Inner value: 0x139c02</summary>
            public static Result.Base GameCardQueueFullFailure => new(ModuleFs, 2510);
            /// <summary>Error code: 2002-2511; Inner value: 0x139e02</summary>
            public static Result.Base GameCardLockerOutOfRange => new(ModuleFs, 2511);
            /// <summary>Error code: 2002-2516; Inner value: 0x13a802</summary>
            public static Result.Base GameCardFailedIoMappingForGpio => new(ModuleFs, 2516);
            /// <summary>Error code: 2002-2520; Inner value: 0x13b002</summary>
            public static Result.Base GameCardCardNotInserted => new(ModuleFs, 2520);
            /// <summary>Error code: 2002-2521; Inner value: 0x13b202</summary>
            public static Result.Base GameCardCardIdMismatch => new(ModuleFs, 2521);
            /// <summary>Error code: 2002-2522; Inner value: 0x13b402</summary>
            public static Result.Base GameCardCardNotActivated => new(ModuleFs, 2522);
            /// <summary>Error code: 2002-2523; Inner value: 0x13b602</summary>
            public static Result.Base GameCardNotAwakened => new(ModuleFs, 2523);

            /// <summary>Error code: 2002-2530; Range: 2530-2559; Inner value: 0x13c402</summary>
            public static Result.Base GameCardCardAccessFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2530, 2559); }
                /// <summary>Error code: 2002-2531; Inner value: 0x13c602</summary>
                public static Result.Base GameCardCardAccessTimeout => new(ModuleFs, 2531);
                /// <summary>Error code: 2002-2532; Inner value: 0x13c802</summary>
                public static Result.Base GameCardCardFatal => new(ModuleFs, 2532);
                /// <summary>Error code: 2002-2533; Inner value: 0x13ca02</summary>
                public static Result.Base GameCardCardNeedRetry => new(ModuleFs, 2533);
                /// <summary>Error code: 2002-2534; Inner value: 0x13cc02</summary>
                public static Result.Base GameCardCardRetryFailure => new(ModuleFs, 2534);
                /// <summary>Error code: 2002-2536; Inner value: 0x13d002</summary>
                public static Result.Base GameCardRetryLimitOut => new(ModuleFs, 2536);

                /// <summary>Error code: 2002-2537; Range: 2537-2538; Inner value: 0x13d202</summary>
                public static Result.Base GameCardNeedRefresh { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2537, 2538); }
                    /// <summary>Error code: 2002-2538; Inner value: 0x13d402</summary>
                    public static Result.Base GameCardNeedRefreshAndCardNeedRetry => new(ModuleFs, 2538);

                /// <summary>Error code: 2002-2540; Inner value: 0x13d802</summary>
                public static Result.Base GameCardInvalidSecureAccess => new(ModuleFs, 2540);
                /// <summary>Error code: 2002-2541; Inner value: 0x13da02</summary>
                public static Result.Base GameCardInvalidNormalAccess => new(ModuleFs, 2541);
                /// <summary>Error code: 2002-2542; Inner value: 0x13dc02</summary>
                public static Result.Base GameCardInvalidAccessAcrossMode => new(ModuleFs, 2542);

                /// <summary>Error code: 2002-2543; Range: 2543-2546; Inner value: 0x13de02</summary>
                public static Result.Base GameCardWrongCard { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2543, 2546); }
                    /// <summary>Error code: 2002-2544; Inner value: 0x13e002</summary>
                    public static Result.Base GameCardInitialDataMismatch => new(ModuleFs, 2544);
                    /// <summary>Error code: 2002-2545; Inner value: 0x13e202</summary>
                    public static Result.Base GameCardInitialNotFilledWithZero => new(ModuleFs, 2545);
                    /// <summary>Error code: 2002-2546; Inner value: 0x13e402</summary>
                    public static Result.Base GameCardKekIndexMismatch => new(ModuleFs, 2546);

                /// <summary>Error code: 2002-2548; Inner value: 0x13e802</summary>
                public static Result.Base GameCardInvalidGetCardDeviceCertificate => new(ModuleFs, 2548);
                /// <summary>Error code: 2002-2549; Inner value: 0x13ea02</summary>
                public static Result.Base GameCardUnregisteredCardSecureMethod => new(ModuleFs, 2549);
                /// <summary>Error code: 2002-2550; Inner value: 0x13ec02</summary>
                public static Result.Base GameCardCardNeedRetryAfterAsicReinitialize => new(ModuleFs, 2550);
                /// <summary>Error code: 2002-2551; Inner value: 0x13ee02</summary>
                public static Result.Base GameCardCardHeaderReadFailure => new(ModuleFs, 2551);
                /// <summary>Error code: 2002-2552; Inner value: 0x13f002</summary>
                public static Result.Base GameCardCardReinitializeFailure => new(ModuleFs, 2552);
                /// <summary>Error code: 2002-2553; Inner value: 0x13f202</summary>
                public static Result.Base GameCardInvalidChallengeCardExistenceMode => new(ModuleFs, 2553);
                /// <summary>Error code: 2002-2554; Inner value: 0x13f402</summary>
                public static Result.Base GameCardInvalidCardHeader => new(ModuleFs, 2554);
                /// <summary>Error code: 2002-2555; Inner value: 0x13f602</summary>
                public static Result.Base GameCardInvalidT1CardCertificate => new(ModuleFs, 2555);
                /// <summary>Error code: 2002-2557; Inner value: 0x13fa02</summary>
                public static Result.Base GameCardInvalidCa10Certificate => new(ModuleFs, 2557);
                /// <summary>Error code: 2002-2558; Inner value: 0x13fc02</summary>
                public static Result.Base GameCardInvalidResponseVerificationValue => new(ModuleFs, 2558);

            /// <summary>Error code: 2002-2565; Range: 2565-2595; Inner value: 0x140a02</summary>
            public static Result.Base GameCardCommunicationFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2565, 2595); }
                /// <summary>Error code: 2002-2566; Inner value: 0x140c02</summary>
                public static Result.Base GameCardFinishOperationFailed => new(ModuleFs, 2566);

            /// <summary>Error code: 2002-2597; Range: 2597-2627; Inner value: 0x144a02</summary>
            public static Result.Base GameCardStateTransitionFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2597, 2627); }
                /// <summary>Error code: 2002-2598; Inner value: 0x144c02</summary>
                public static Result.Base GameCardAlreadyTransitionedState => new(ModuleFs, 2598);
                /// <summary>Error code: 2002-2599; Inner value: 0x144e02</summary>
                public static Result.Base GameCardShouldTransitFromAsicInitialToSecure => new(ModuleFs, 2599);
                /// <summary>Error code: 2002-2600; Inner value: 0x145002</summary>
                public static Result.Base GameCardShouldTransitFromInitialToNormal => new(ModuleFs, 2600);
                /// <summary>Error code: 2002-2601; Inner value: 0x145202</summary>
                public static Result.Base GameCardShouldTransitFromNormalModeToSecure => new(ModuleFs, 2601);
                /// <summary>Error code: 2002-2602; Inner value: 0x145402</summary>
                public static Result.Base GameCardShouldTransitFromNormalModeToDebug => new(ModuleFs, 2602);

            /// <summary>Error code: 2002-2629; Range: 2629-2669; Inner value: 0x148a02</summary>
            public static Result.Base GameCardInitializeAsicFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2629, 2669); }
                /// <summary>Error code: 2002-2630; Inner value: 0x148c02</summary>
                public static Result.Base GameCardAlreadyInitializedAsic => new(ModuleFs, 2630);

                /// <summary>Error code: 2002-2631; Range: 2631-2632; Inner value: 0x148e02</summary>
                public static Result.Base GameCardActivateAsicFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2631, 2632); }
                    /// <summary>Error code: 2002-2632; Inner value: 0x149002</summary>
                    public static Result.Base GameCardAsicBootFailure => new(ModuleFs, 2632);

                /// <summary>Error code: 2002-2634; Inner value: 0x149402</summary>
                public static Result.Base GameCardSendFirmwareFailure => new(ModuleFs, 2634);

                /// <summary>Error code: 2002-2636; Range: 2636-2641; Inner value: 0x149802</summary>
                public static Result.Base GameCardVerifyCertificateFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2636, 2641); }
                    /// <summary>Error code: 2002-2637; Inner value: 0x149a02</summary>
                    public static Result.Base GameCardReceiveCertificateFailure => new(ModuleFs, 2637);
                    /// <summary>Error code: 2002-2638; Inner value: 0x149c02</summary>
                    public static Result.Base GameCardParseCertificateFailure => new(ModuleFs, 2638);
                    /// <summary>Error code: 2002-2639; Inner value: 0x149e02</summary>
                    public static Result.Base GameCardInvalidCertificate => new(ModuleFs, 2639);
                    /// <summary>Error code: 2002-2640; Inner value: 0x14a002</summary>
                    public static Result.Base GameCardSendSocCertificateFailure => new(ModuleFs, 2640);

                /// <summary>Error code: 2002-2644; Range: 2644-2647; Inner value: 0x14a802</summary>
                public static Result.Base GameCardGenerateCommonKeyFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2644, 2647); }
                    /// <summary>Error code: 2002-2645; Inner value: 0x14aa02</summary>
                    public static Result.Base GameCardReceiveRandomValueFailure => new(ModuleFs, 2645);
                    /// <summary>Error code: 2002-2646; Inner value: 0x14ac02</summary>
                    public static Result.Base GameCardSendRandomValueFailure => new(ModuleFs, 2646);
                    /// <summary>Error code: 2002-2647; Inner value: 0x14ae02</summary>
                    public static Result.Base GameCardDecryptRandomValueFailure => new(ModuleFs, 2647);

                /// <summary>Error code: 2002-2650; Range: 2650-2655; Inner value: 0x14b402</summary>
                public static Result.Base GameCardAuthenticateMutuallyFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2650, 2655); }
                    /// <summary>Error code: 2002-2651; Inner value: 0x14b602</summary>
                    public static Result.Base GameCardReceiveDeviceChallengeFailure => new(ModuleFs, 2651);
                    /// <summary>Error code: 2002-2652; Inner value: 0x14b802</summary>
                    public static Result.Base GameCardRespondDeviceChallengeFailure => new(ModuleFs, 2652);
                    /// <summary>Error code: 2002-2653; Inner value: 0x14ba02</summary>
                    public static Result.Base GameCardSendHostChallengeFailure => new(ModuleFs, 2653);
                    /// <summary>Error code: 2002-2654; Inner value: 0x14bc02</summary>
                    public static Result.Base GameCardReceiveChallengeResponseFailure => new(ModuleFs, 2654);
                    /// <summary>Error code: 2002-2655; Inner value: 0x14be02</summary>
                    public static Result.Base GameCardChallengeAndResponseFailure => new(ModuleFs, 2655);

                /// <summary>Error code: 2002-2658; Inner value: 0x14c402</summary>
                public static Result.Base GameCardChangeModeToSecureFailure => new(ModuleFs, 2658);
                /// <summary>Error code: 2002-2659; Inner value: 0x14c602</summary>
                public static Result.Base GameCardExchangeRandomValuesFailure => new(ModuleFs, 2659);
                /// <summary>Error code: 2002-2660; Inner value: 0x14c802</summary>
                public static Result.Base GameCardChallengeCardExistenceFailure => new(ModuleFs, 2660);
                /// <summary>Error code: 2002-2663; Inner value: 0x14ce02</summary>
                public static Result.Base GameCardInitializeAsicTimeOut => new(ModuleFs, 2663);

                /// <summary>Error code: 2002-2665; Range: 2665-2669; Inner value: 0x14d202</summary>
                public static Result.Base GameCardSplFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2665, 2669); }
                    /// <summary>Error code: 2002-2666; Inner value: 0x14d402</summary>
                    public static Result.Base GameCardSplDecryptAesKeyFailure => new(ModuleFs, 2666);
                    /// <summary>Error code: 2002-2667; Inner value: 0x14d602</summary>
                    public static Result.Base GameCardSplDecryptAndStoreGcKeyFailure => new(ModuleFs, 2667);
                    /// <summary>Error code: 2002-2668; Inner value: 0x14d802</summary>
                    public static Result.Base GameCardSplGenerateRandomBytesFailure => new(ModuleFs, 2668);
                    /// <summary>Error code: 2002-2669; Inner value: 0x14da02</summary>
                    public static Result.Base GameCardSplDecryptGcMessageFailure => new(ModuleFs, 2669);

            /// <summary>Error code: 2002-2671; Inner value: 0x14de02</summary>
            public static Result.Base GameCardReadRegisterFailure => new(ModuleFs, 2671);
            /// <summary>Error code: 2002-2672; Inner value: 0x14e002</summary>
            public static Result.Base GameCardWriteRegisterFailure => new(ModuleFs, 2672);
            /// <summary>Error code: 2002-2673; Inner value: 0x14e202</summary>
            public static Result.Base GameCardEnableCardBusFailure => new(ModuleFs, 2673);
            /// <summary>Error code: 2002-2674; Inner value: 0x14e402</summary>
            public static Result.Base GameCardGetCardHeaderFailure => new(ModuleFs, 2674);
            /// <summary>Error code: 2002-2675; Inner value: 0x14e602</summary>
            public static Result.Base GameCardAsicStatusError => new(ModuleFs, 2675);
            /// <summary>Error code: 2002-2676; Inner value: 0x14e802</summary>
            public static Result.Base GameCardChangeGcModeToSecureFailure => new(ModuleFs, 2676);
            /// <summary>Error code: 2002-2677; Inner value: 0x14ea02</summary>
            public static Result.Base GameCardChangeGcModeToDebugFailure => new(ModuleFs, 2677);
            /// <summary>Error code: 2002-2678; Inner value: 0x14ec02</summary>
            public static Result.Base GameCardReadRmaInfoFailure => new(ModuleFs, 2678);

            /// <summary>Error code: 2002-2680; Range: 2680-2683; Inner value: 0x14f002</summary>
            public static Result.Base GameCardUpdateKeyFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2680, 2683); }
                /// <summary>Error code: 2002-2681; Inner value: 0x14f202</summary>
                public static Result.Base GameCardKeySourceNotFound => new(ModuleFs, 2681);

            /// <summary>Error code: 2002-2690; Range: 2690-2695; Inner value: 0x150402</summary>
            public static Result.Base GameCardStateFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2690, 2695); }
                /// <summary>Error code: 2002-2691; Inner value: 0x150602</summary>
                public static Result.Base GameCardStateCardNormalModeRequired => new(ModuleFs, 2691);
                /// <summary>Error code: 2002-2692; Inner value: 0x150802</summary>
                public static Result.Base GameCardStateCardSecureModeRequired => new(ModuleFs, 2692);
                /// <summary>Error code: 2002-2693; Inner value: 0x150a02</summary>
                public static Result.Base GameCardStateCardDebugModeRequired => new(ModuleFs, 2693);
                /// <summary>Error code: 2002-2694; Inner value: 0x150c02</summary>
                public static Result.Base GameCardStateAsicInitialRequired => new(ModuleFs, 2694);
                /// <summary>Error code: 2002-2695; Inner value: 0x150e02</summary>
                public static Result.Base GameCardStateAsicSecureRequired => new(ModuleFs, 2695);

            /// <summary>Error code: 2002-2700; Range: 2700-2708; Inner value: 0x151802</summary>
            public static Result.Base GameCardGeneralIoFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2700, 2708); }
                /// <summary>Error code: 2002-2701; Inner value: 0x151a02</summary>
                public static Result.Base GameCardGeneralIoReleaseAsicResetFailure => new(ModuleFs, 2701);
                /// <summary>Error code: 2002-2702; Inner value: 0x151c02</summary>
                public static Result.Base GameCardGeneralIoHoldAsicResetFailure => new(ModuleFs, 2702);
                /// <summary>Error code: 2002-2703; Inner value: 0x151e02</summary>
                public static Result.Base GameCardSetVoltageFailure => new(ModuleFs, 2703);

            /// <summary>Error code: 2002-2710; Range: 2710-2718; Inner value: 0x152c02</summary>
            public static Result.Base GameCardDataIoFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2710, 2718); }
                /// <summary>Error code: 2002-2711; Inner value: 0x152e02</summary>
                public static Result.Base GameCardDataIoActivateFailure => new(ModuleFs, 2711);

            /// <summary>Error code: 2002-2730; Range: 2730-2749; Inner value: 0x155402</summary>
            public static Result.Base GameCardCardCommandFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2730, 2749); }
                /// <summary>Error code: 2002-2731; Inner value: 0x155602</summary>
                public static Result.Base GameCardCommandReadId1Failure => new(ModuleFs, 2731);
                /// <summary>Error code: 2002-2732; Inner value: 0x155802</summary>
                public static Result.Base GameCardCommandReadId2Failure => new(ModuleFs, 2732);
                /// <summary>Error code: 2002-2733; Inner value: 0x155a02</summary>
                public static Result.Base GameCardCommandReadId3Failure => new(ModuleFs, 2733);
                /// <summary>Error code: 2002-2734; Inner value: 0x155c02</summary>
                public static Result.Base GameCardSendCardReadUidFailure => new(ModuleFs, 2734);
                /// <summary>Error code: 2002-2735; Inner value: 0x155e02</summary>
                public static Result.Base GameCardCommandReadPageFailure => new(ModuleFs, 2735);
                /// <summary>Error code: 2002-2736; Inner value: 0x156002</summary>
                public static Result.Base GameCardCommandReadPageUnalignedFailure => new(ModuleFs, 2736);
                /// <summary>Error code: 2002-2737; Inner value: 0x156202</summary>
                public static Result.Base GameCardCommandWritePageFailure => new(ModuleFs, 2737);
                /// <summary>Error code: 2002-2738; Inner value: 0x156402</summary>
                public static Result.Base GameCardCommandRefreshFailure => new(ModuleFs, 2738);
                /// <summary>Error code: 2002-2739; Inner value: 0x156602</summary>
                public static Result.Base GameCardCommandUpdateKeyFailure => new(ModuleFs, 2739);
                /// <summary>Error code: 2002-2740; Inner value: 0x156802</summary>
                public static Result.Base GameCardSendCardSelfRefreshFailure => new(ModuleFs, 2740);
                /// <summary>Error code: 2002-2741; Inner value: 0x156a02</summary>
                public static Result.Base GameCardSendCardReadRefreshStatusFailure => new(ModuleFs, 2741);
                /// <summary>Error code: 2002-2742; Inner value: 0x156c02</summary>
                public static Result.Base GameCardCommandReadCrcFailure => new(ModuleFs, 2742);
                /// <summary>Error code: 2002-2743; Inner value: 0x156e02</summary>
                public static Result.Base GameCardCommandEraseFailure => new(ModuleFs, 2743);
                /// <summary>Error code: 2002-2744; Inner value: 0x157002</summary>
                public static Result.Base GameCardCommandReadDevParamFailure => new(ModuleFs, 2744);
                /// <summary>Error code: 2002-2745; Inner value: 0x157202</summary>
                public static Result.Base GameCardCommandWriteDevParamFailure => new(ModuleFs, 2745);
                /// <summary>Error code: 2002-2746; Inner value: 0x157402</summary>
                public static Result.Base GameCardSendCardReadErrorCountFailure => new(ModuleFs, 2746);

            /// <summary>Error code: 2002-2900; Range: 2900-2919; Inner value: 0x16a802</summary>
            public static Result.Base GameCardDevCardUnexpectedFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2900, 2919); }
                /// <summary>Error code: 2002-2901; Inner value: 0x16aa02</summary>
                public static Result.Base GameCardDebugParameterMismatch => new(ModuleFs, 2901);
                /// <summary>Error code: 2002-2902; Inner value: 0x16ac02</summary>
                public static Result.Base GameCardDebugEraseFailure => new(ModuleFs, 2902);
                /// <summary>Error code: 2002-2903; Inner value: 0x16ae02</summary>
                public static Result.Base GameCardDebugWriteCrcMismatch => new(ModuleFs, 2903);
                /// <summary>Error code: 2002-2904; Inner value: 0x16b002</summary>
                public static Result.Base GameCardDebugCardReceivedIdMismatch => new(ModuleFs, 2904);
                /// <summary>Error code: 2002-2905; Inner value: 0x16b202</summary>
                public static Result.Base GameCardDebugCardId1Mismatch => new(ModuleFs, 2905);
                /// <summary>Error code: 2002-2906; Inner value: 0x16b402</summary>
                public static Result.Base GameCardDebugCardId2Mismatch => new(ModuleFs, 2906);

            /// <summary>Error code: 2002-2950; Range: 2950-2998; Inner value: 0x170c02</summary>
            public static Result.Base GameCardFsFailure { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 2950, 2998); }
                /// <summary>Error code: 2002-2951; Inner value: 0x170e02</summary>
                public static Result.Base GameCardFsGetHandleFailure => new(ModuleFs, 2951);
                /// <summary>Error code: 2002-2952; Inner value: 0x171002</summary>
                public static Result.Base GameCardFsCheckHandleInReadFailure => new(ModuleFs, 2952);
                /// <summary>Error code: 2002-2953; Inner value: 0x171202</summary>
                public static Result.Base GameCardFsCheckHandleInWriteFailure => new(ModuleFs, 2953);
                /// <summary>Error code: 2002-2954; Inner value: 0x171402</summary>
                public static Result.Base GameCardFsCheckHandleInGetStatusFailure => new(ModuleFs, 2954);
                /// <summary>Error code: 2002-2955; Inner value: 0x171602</summary>
                public static Result.Base GameCardFsCheckHandleInGetDeviceCertFailure => new(ModuleFs, 2955);
                /// <summary>Error code: 2002-2956; Inner value: 0x171802</summary>
                public static Result.Base GameCardFsCheckHandleInGetCardImageHashFailure => new(ModuleFs, 2956);
                /// <summary>Error code: 2002-2957; Inner value: 0x171a02</summary>
                public static Result.Base GameCardFsCheckHandleInChallengeCardExistence => new(ModuleFs, 2957);
                /// <summary>Error code: 2002-2958; Inner value: 0x171c02</summary>
                public static Result.Base GameCardFsCheckHandleInAcquireReadLock => new(ModuleFs, 2958);
                /// <summary>Error code: 2002-2959; Inner value: 0x171e02</summary>
                public static Result.Base GameCardFsCheckModeInAcquireSecureLock => new(ModuleFs, 2959);
                /// <summary>Error code: 2002-2960; Inner value: 0x172002</summary>
                public static Result.Base GameCardFsCheckHandleInCreateReadOnlyFailure => new(ModuleFs, 2960);
                /// <summary>Error code: 2002-2961; Inner value: 0x172202</summary>
                public static Result.Base GameCardFsCheckHandleInCreateSecureReadOnlyFailure => new(ModuleFs, 2961);
                /// <summary>Error code: 2002-2962; Inner value: 0x172402</summary>
                public static Result.Base GameCardFsInvalidCompatibilityType => new(ModuleFs, 2962);
                /// <summary>Error code: 2002-2963; Inner value: 0x172602</summary>
                public static Result.Base GameCardNotSupportedOnDeviceModel => new(ModuleFs, 2963);

    /// <summary>Error code: 2002-3000; Range: 3000-7999; Inner value: 0x177002</summary>
    public static Result.Base Internal { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3000, 7999); }
        /// <summary>Error code: 2002-3001; Inner value: 0x177202</summary>
        public static Result.Base NotImplemented => new(ModuleFs, 3001);
        /// <summary>Error code: 2002-3002; Inner value: 0x177402</summary>
        public static Result.Base UnsupportedVersion => new(ModuleFs, 3002);
        /// <summary>Error code: 2002-3003; Inner value: 0x177602</summary>
        public static Result.Base AlreadyExists => new(ModuleFs, 3003);
        /// <summary>Error code: 2002-3005; Inner value: 0x177a02</summary>
        public static Result.Base OutOfRange => new(ModuleFs, 3005);
        /// <summary>Error code: 2002-3099; Inner value: 0x183602</summary>
        public static Result.Base StorageDeviceInvalidOperation => new(ModuleFs, 3099);
        /// <summary>Error code: 2002-3100; Inner value: 0x183802</summary>
        public static Result.Base SystemPartitionNotReady => new(ModuleFs, 3100);
        /// <summary>Error code: 2002-3101; Inner value: 0x183a02</summary>
        public static Result.Base StorageDeviceNotReady => new(ModuleFs, 3101);

        /// <summary>Error code: 2002-3200; Range: 3200-3499; Inner value: 0x190002</summary>
        public static Result.Base AllocationMemoryFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3200, 3499); }
            /// <summary>Error code: 2002-3201; Inner value: 0x190202</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemA => new(ModuleFs, 3201);
            /// <summary>Error code: 2002-3203; Inner value: 0x190602</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemC => new(ModuleFs, 3203);
            /// <summary>Error code: 2002-3204; Inner value: 0x190802</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemD => new(ModuleFs, 3204);
            /// <summary>Error code: 2002-3205; Inner value: 0x190a02</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemE => new(ModuleFs, 3205);
            /// <summary>Error code: 2002-3206; Inner value: 0x190c02</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemF => new(ModuleFs, 3206);
            /// <summary>Error code: 2002-3208; Inner value: 0x191002</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemH => new(ModuleFs, 3208);
            /// <summary>Error code: 2002-3211; Inner value: 0x191602</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemAccessorA => new(ModuleFs, 3211);
            /// <summary>Error code: 2002-3212; Inner value: 0x191802</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemAccessorB => new(ModuleFs, 3212);
            /// <summary>Error code: 2002-3213; Inner value: 0x191a02</summary>
            public static Result.Base AllocationMemoryFailedInApplicationA => new(ModuleFs, 3213);
            /// <summary>Error code: 2002-3214; Inner value: 0x191c02</summary>
            public static Result.Base AllocationMemoryFailedInBcatSaveDataA => new(ModuleFs, 3214);
            /// <summary>Error code: 2002-3215; Inner value: 0x191e02</summary>
            public static Result.Base AllocationMemoryFailedInBisA => new(ModuleFs, 3215);
            /// <summary>Error code: 2002-3216; Inner value: 0x192002</summary>
            public static Result.Base AllocationMemoryFailedInBisB => new(ModuleFs, 3216);
            /// <summary>Error code: 2002-3217; Inner value: 0x192202</summary>
            public static Result.Base AllocationMemoryFailedInBisC => new(ModuleFs, 3217);
            /// <summary>Error code: 2002-3218; Inner value: 0x192402</summary>
            public static Result.Base AllocationMemoryFailedInCodeA => new(ModuleFs, 3218);
            /// <summary>Error code: 2002-3219; Inner value: 0x192602</summary>
            public static Result.Base AllocationMemoryFailedInContentA => new(ModuleFs, 3219);
            /// <summary>Error code: 2002-3220; Inner value: 0x192802</summary>
            public static Result.Base AllocationMemoryFailedInContentStorageA => new(ModuleFs, 3220);
            /// <summary>Error code: 2002-3221; Inner value: 0x192a02</summary>
            public static Result.Base AllocationMemoryFailedInContentStorageB => new(ModuleFs, 3221);
            /// <summary>Error code: 2002-3222; Inner value: 0x192c02</summary>
            public static Result.Base AllocationMemoryFailedInDataA => new(ModuleFs, 3222);
            /// <summary>Error code: 2002-3223; Inner value: 0x192e02</summary>
            public static Result.Base AllocationMemoryFailedInDataB => new(ModuleFs, 3223);
            /// <summary>Error code: 2002-3224; Inner value: 0x193002</summary>
            public static Result.Base AllocationMemoryFailedInDeviceSaveDataA => new(ModuleFs, 3224);
            /// <summary>Error code: 2002-3225; Inner value: 0x193202</summary>
            public static Result.Base AllocationMemoryFailedInGameCardA => new(ModuleFs, 3225);
            /// <summary>Error code: 2002-3226; Inner value: 0x193402</summary>
            public static Result.Base AllocationMemoryFailedInGameCardB => new(ModuleFs, 3226);
            /// <summary>Error code: 2002-3227; Inner value: 0x193602</summary>
            public static Result.Base AllocationMemoryFailedInGameCardC => new(ModuleFs, 3227);
            /// <summary>Error code: 2002-3228; Inner value: 0x193802</summary>
            public static Result.Base AllocationMemoryFailedInGameCardD => new(ModuleFs, 3228);
            /// <summary>Error code: 2002-3229; Inner value: 0x193a02</summary>
            public static Result.Base AllocationMemoryFailedInHostA => new(ModuleFs, 3229);
            /// <summary>Error code: 2002-3230; Inner value: 0x193c02</summary>
            public static Result.Base AllocationMemoryFailedInHostB => new(ModuleFs, 3230);
            /// <summary>Error code: 2002-3231; Inner value: 0x193e02</summary>
            public static Result.Base AllocationMemoryFailedInHostC => new(ModuleFs, 3231);
            /// <summary>Error code: 2002-3232; Inner value: 0x194002</summary>
            public static Result.Base AllocationMemoryFailedInImageDirectoryA => new(ModuleFs, 3232);
            /// <summary>Error code: 2002-3233; Inner value: 0x194202</summary>
            public static Result.Base AllocationMemoryFailedInLogoA => new(ModuleFs, 3233);
            /// <summary>Error code: 2002-3234; Inner value: 0x194402</summary>
            public static Result.Base AllocationMemoryFailedInRomA => new(ModuleFs, 3234);
            /// <summary>Error code: 2002-3235; Inner value: 0x194602</summary>
            public static Result.Base AllocationMemoryFailedInRomB => new(ModuleFs, 3235);
            /// <summary>Error code: 2002-3236; Inner value: 0x194802</summary>
            public static Result.Base AllocationMemoryFailedInRomC => new(ModuleFs, 3236);
            /// <summary>Error code: 2002-3237; Inner value: 0x194a02</summary>
            public static Result.Base AllocationMemoryFailedInRomD => new(ModuleFs, 3237);
            /// <summary>Error code: 2002-3238; Inner value: 0x194c02</summary>
            public static Result.Base AllocationMemoryFailedInRomE => new(ModuleFs, 3238);
            /// <summary>Error code: 2002-3239; Inner value: 0x194e02</summary>
            public static Result.Base AllocationMemoryFailedInRomF => new(ModuleFs, 3239);
            /// <summary>Error code: 2002-3242; Inner value: 0x195402</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataManagementA => new(ModuleFs, 3242);
            /// <summary>Error code: 2002-3243; Inner value: 0x195602</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataThumbnailA => new(ModuleFs, 3243);
            /// <summary>Error code: 2002-3244; Inner value: 0x195802</summary>
            public static Result.Base AllocationMemoryFailedInSdCardA => new(ModuleFs, 3244);
            /// <summary>Error code: 2002-3245; Inner value: 0x195a02</summary>
            public static Result.Base AllocationMemoryFailedInSdCardB => new(ModuleFs, 3245);
            /// <summary>Error code: 2002-3246; Inner value: 0x195c02</summary>
            public static Result.Base AllocationMemoryFailedInSystemSaveDataA => new(ModuleFs, 3246);
            /// <summary>Error code: 2002-3247; Inner value: 0x195e02</summary>
            public static Result.Base AllocationMemoryFailedInRomFsFileSystemA => new(ModuleFs, 3247);
            /// <summary>Error code: 2002-3248; Inner value: 0x196002</summary>
            public static Result.Base AllocationMemoryFailedInRomFsFileSystemB => new(ModuleFs, 3248);
            /// <summary>Error code: 2002-3249; Inner value: 0x196202</summary>
            public static Result.Base AllocationMemoryFailedInRomFsFileSystemC => new(ModuleFs, 3249);
            /// <summary>Error code: 2002-3251; Inner value: 0x196602</summary>
            public static Result.Base AllocationMemoryFailedInGuidPartitionTableA => new(ModuleFs, 3251);
            /// <summary>Error code: 2002-3252; Inner value: 0x196802</summary>
            public static Result.Base AllocationMemoryFailedInDeviceDetectionEventManagerA => new(ModuleFs, 3252);
            /// <summary>Error code: 2002-3253; Inner value: 0x196a02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemServiceImplA => new(ModuleFs, 3253);
            /// <summary>Error code: 2002-3254; Inner value: 0x196c02</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemProxyCoreImplB => new(ModuleFs, 3254);
            /// <summary>Error code: 2002-3255; Inner value: 0x196e02</summary>
            public static Result.Base AllocationMemoryFailedInSdCardProxyFileSystemCreatorA => new(ModuleFs, 3255);
            /// <summary>In ParseNsp allocating FileStorageBasedFileSystem<br/>Error code: 2002-3256; Inner value: 0x197002</summary>
            public static Result.Base AllocationMemoryFailedInNcaFileSystemServiceImplA => new(ModuleFs, 3256);
            /// <summary>In ParseNca allocating FileStorageBasedFileSystem<br/>Error code: 2002-3257; Inner value: 0x197202</summary>
            public static Result.Base AllocationMemoryFailedInNcaFileSystemServiceImplB => new(ModuleFs, 3257);
            /// <summary>In RegisterProgram allocating ProgramInfoNode<br/>Error code: 2002-3258; Inner value: 0x197402</summary>
            public static Result.Base AllocationMemoryFailedInProgramRegistryManagerA => new(ModuleFs, 3258);
            /// <summary>Error code: 2002-3259; Inner value: 0x197602</summary>
            public static Result.Base AllocationMemoryFailedInSdmmcStorageServiceA => new(ModuleFs, 3259);
            /// <summary>Error code: 2002-3260; Inner value: 0x197802</summary>
            public static Result.Base AllocationMemoryFailedInBuiltInStorageCreatorA => new(ModuleFs, 3260);
            /// <summary>Error code: 2002-3261; Inner value: 0x197a02</summary>
            public static Result.Base AllocationMemoryFailedInBuiltInStorageCreatorB => new(ModuleFs, 3261);
            /// <summary>Error code: 2002-3262; Inner value: 0x197c02</summary>
            public static Result.Base AllocationMemoryFailedInBuiltInStorageCreatorC => new(ModuleFs, 3262);
            /// <summary>In Initialize allocating ProgramInfoNode<br/>Error code: 2002-3264; Inner value: 0x198002</summary>
            public static Result.Base AllocationMemoryFailedFatFileSystemWithBufferA => new(ModuleFs, 3264);
            /// <summary>Error code: 2002-3265; Inner value: 0x198202</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemCreatorA => new(ModuleFs, 3265);
            /// <summary>Error code: 2002-3266; Inner value: 0x198402</summary>
            public static Result.Base AllocationMemoryFailedInFatFileSystemCreatorB => new(ModuleFs, 3266);
            /// <summary>Error code: 2002-3267; Inner value: 0x198602</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorA => new(ModuleFs, 3267);
            /// <summary>Error code: 2002-3268; Inner value: 0x198802</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorB => new(ModuleFs, 3268);
            /// <summary>Error code: 2002-3269; Inner value: 0x198a02</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorC => new(ModuleFs, 3269);
            /// <summary>Error code: 2002-3270; Inner value: 0x198c02</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorD => new(ModuleFs, 3270);
            /// <summary>Error code: 2002-3271; Inner value: 0x198e02</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorE => new(ModuleFs, 3271);
            /// <summary>Error code: 2002-3272; Inner value: 0x199002</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorF => new(ModuleFs, 3272);
            /// <summary>Error code: 2002-3273; Inner value: 0x199202</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerA => new(ModuleFs, 3273);
            /// <summary>Error code: 2002-3274; Inner value: 0x199402</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerB => new(ModuleFs, 3274);
            /// <summary>Error code: 2002-3275; Inner value: 0x199602</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerC => new(ModuleFs, 3275);
            /// <summary>Error code: 2002-3276; Inner value: 0x199802</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerD => new(ModuleFs, 3276);
            /// <summary>Error code: 2002-3277; Inner value: 0x199a02</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerE => new(ModuleFs, 3277);
            /// <summary>Error code: 2002-3278; Inner value: 0x199c02</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerF => new(ModuleFs, 3278);
            /// <summary>Error code: 2002-3279; Inner value: 0x199e02</summary>
            public static Result.Base AllocationMemoryFailedInLocalFileSystemCreatorA => new(ModuleFs, 3279);
            /// <summary>In Create allocating PartitionFileSystemCore<br/>Error code: 2002-3280; Inner value: 0x19a002</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemCreatorA => new(ModuleFs, 3280);
            /// <summary>Error code: 2002-3281; Inner value: 0x19a202</summary>
            public static Result.Base AllocationMemoryFailedInRomFileSystemCreatorA => new(ModuleFs, 3281);
            /// <summary>Error code: 2002-3282; Inner value: 0x19a402</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCreatorA => new(ModuleFs, 3282);
            /// <summary>Error code: 2002-3283; Inner value: 0x19a602</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCreatorB => new(ModuleFs, 3283);
            /// <summary>Error code: 2002-3284; Inner value: 0x19a802</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCreatorC => new(ModuleFs, 3284);
            /// <summary>Error code: 2002-3285; Inner value: 0x19aa02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCreatorD => new(ModuleFs, 3285);
            /// <summary>Error code: 2002-3286; Inner value: 0x19ac02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCreatorE => new(ModuleFs, 3286);
            /// <summary>Error code: 2002-3288; Inner value: 0x19b002</summary>
            public static Result.Base AllocationMemoryFailedInStorageOnNcaCreatorA => new(ModuleFs, 3288);
            /// <summary>Error code: 2002-3289; Inner value: 0x19b202</summary>
            public static Result.Base AllocationMemoryFailedInStorageOnNcaCreatorB => new(ModuleFs, 3289);
            /// <summary>Error code: 2002-3290; Inner value: 0x19b402</summary>
            public static Result.Base AllocationMemoryFailedInSubDirectoryFileSystemCreatorA => new(ModuleFs, 3290);
            /// <summary>Error code: 2002-3291; Inner value: 0x19b602</summary>
            public static Result.Base AllocationMemoryFailedInTargetManagerFileSystemCreatorA => new(ModuleFs, 3291);
            /// <summary>Error code: 2002-3292; Inner value: 0x19b802</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataIndexerA => new(ModuleFs, 3292);
            /// <summary>Error code: 2002-3293; Inner value: 0x19ba02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataIndexerB => new(ModuleFs, 3293);
            /// <summary>Error code: 2002-3294; Inner value: 0x19bc02</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemBuddyHeapA => new(ModuleFs, 3294);
            /// <summary>Error code: 2002-3295; Inner value: 0x19be02</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemBufferManagerA => new(ModuleFs, 3295);
            /// <summary>Error code: 2002-3296; Inner value: 0x19c002</summary>
            public static Result.Base AllocationMemoryFailedInBlockCacheBufferedStorageA => new(ModuleFs, 3296);
            /// <summary>Error code: 2002-3297; Inner value: 0x19c202</summary>
            public static Result.Base AllocationMemoryFailedInBlockCacheBufferedStorageB => new(ModuleFs, 3297);
            /// <summary>Error code: 2002-3298; Inner value: 0x19c402</summary>
            public static Result.Base AllocationMemoryFailedInDuplexStorageA => new(ModuleFs, 3298);
            /// <summary>Error code: 2002-3304; Inner value: 0x19d002</summary>
            public static Result.Base AllocationMemoryFailedInIntegrityVerificationStorageA => new(ModuleFs, 3304);
            /// <summary>Error code: 2002-3305; Inner value: 0x19d202</summary>
            public static Result.Base AllocationMemoryFailedInIntegrityVerificationStorageB => new(ModuleFs, 3305);
            /// <summary>Error code: 2002-3306; Inner value: 0x19d402</summary>
            public static Result.Base AllocationMemoryFailedInJournalStorageA => new(ModuleFs, 3306);
            /// <summary>Error code: 2002-3307; Inner value: 0x19d602</summary>
            public static Result.Base AllocationMemoryFailedInJournalStorageB => new(ModuleFs, 3307);
            /// <summary>Error code: 2002-3310; Inner value: 0x19dc02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCoreA => new(ModuleFs, 3310);
            /// <summary>Error code: 2002-3311; Inner value: 0x19de02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemCoreB => new(ModuleFs, 3311);
            /// <summary>In Initialize allocating FileStorage<br/>Error code: 2002-3312; Inner value: 0x19e002</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileA => new(ModuleFs, 3312);
            /// <summary>In Initialize allocating AesXtsStorage<br/>Error code: 2002-3313; Inner value: 0x19e202</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileB => new(ModuleFs, 3313);
            /// <summary>In Initialize allocating AlignmentMatchingStoragePooledBuffer<br/>Error code: 2002-3314; Inner value: 0x19e402</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileC => new(ModuleFs, 3314);
            /// <summary>In Initialize allocating StorageFile<br/>Error code: 2002-3315; Inner value: 0x19e602</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileD => new(ModuleFs, 3315);
            /// <summary>Error code: 2002-3316; Inner value: 0x19e802</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileSystemA => new(ModuleFs, 3316);
            /// <summary>Error code: 2002-3319; Inner value: 0x19ee02</summary>
            public static Result.Base AllocationMemoryFailedInConcatenationFileSystemA => new(ModuleFs, 3319);
            /// <summary>Error code: 2002-3320; Inner value: 0x19f002</summary>
            public static Result.Base AllocationMemoryFailedInConcatenationFileSystemB => new(ModuleFs, 3320);
            /// <summary>Error code: 2002-3321; Inner value: 0x19f202</summary>
            public static Result.Base AllocationMemoryFailedInDirectorySaveDataFileSystemA => new(ModuleFs, 3321);
            /// <summary>Error code: 2002-3322; Inner value: 0x19f402</summary>
            public static Result.Base AllocationMemoryFailedInLocalFileSystemA => new(ModuleFs, 3322);
            /// <summary>Error code: 2002-3323; Inner value: 0x19f602</summary>
            public static Result.Base AllocationMemoryFailedInLocalFileSystemB => new(ModuleFs, 3323);
            /// <summary>Error code: 2002-3341; Inner value: 0x1a1a02</summary>
            public static Result.Base AllocationMemoryFailedInNcaFileSystemDriverI => new(ModuleFs, 3341);
            /// <summary>In Initialize allocating PartitionFileSystemMetaCore<br/>Error code: 2002-3347; Inner value: 0x1a2602</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemA => new(ModuleFs, 3347);
            /// <summary>In DoOpenFile allocating PartitionFile<br/>Error code: 2002-3348; Inner value: 0x1a2802</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemB => new(ModuleFs, 3348);
            /// <summary>In DoOpenDirectory allocating PartitionDirectory<br/>Error code: 2002-3349; Inner value: 0x1a2a02</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemC => new(ModuleFs, 3349);
            /// <summary>In Initialize allocating metadata buffer<br/>Error code: 2002-3350; Inner value: 0x1a2c02</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemMetaA => new(ModuleFs, 3350);
            /// <summary>In Sha256 Initialize allocating metadata buffer<br/>Error code: 2002-3351; Inner value: 0x1a2e02</summary>
            public static Result.Base AllocationMemoryFailedInPartitionFileSystemMetaB => new(ModuleFs, 3351);
            /// <summary>Error code: 2002-3352; Inner value: 0x1a3002</summary>
            public static Result.Base AllocationMemoryFailedInRomFsFileSystemD => new(ModuleFs, 3352);
            /// <summary>In Initialize allocating RootPathBuffer<br/>Error code: 2002-3355; Inner value: 0x1a3602</summary>
            public static Result.Base AllocationMemoryFailedInSubdirectoryFileSystemA => new(ModuleFs, 3355);
            /// <summary>Error code: 2002-3356; Inner value: 0x1a3802</summary>
            public static Result.Base AllocationMemoryFailedInTmFileSystemA => new(ModuleFs, 3356);
            /// <summary>Error code: 2002-3357; Inner value: 0x1a3a02</summary>
            public static Result.Base AllocationMemoryFailedInTmFileSystemB => new(ModuleFs, 3357);
            /// <summary>Error code: 2002-3359; Inner value: 0x1a3e02</summary>
            public static Result.Base AllocationMemoryFailedInProxyFileSystemA => new(ModuleFs, 3359);
            /// <summary>Error code: 2002-3360; Inner value: 0x1a4002</summary>
            public static Result.Base AllocationMemoryFailedInProxyFileSystemB => new(ModuleFs, 3360);
            /// <summary>Error code: 2002-3362; Inner value: 0x1a4402</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataExtraDataAccessorCacheManagerA => new(ModuleFs, 3362);
            /// <summary>Error code: 2002-3363; Inner value: 0x1a4602</summary>
            public static Result.Base AllocationMemoryFailedInNcaReaderA => new(ModuleFs, 3363);
            /// <summary>Error code: 2002-3365; Inner value: 0x1a4a02</summary>
            public static Result.Base AllocationMemoryFailedInRegisterA => new(ModuleFs, 3365);
            /// <summary>Error code: 2002-3366; Inner value: 0x1a4c02</summary>
            public static Result.Base AllocationMemoryFailedInRegisterB => new(ModuleFs, 3366);
            /// <summary>Error code: 2002-3367; Inner value: 0x1a4e02</summary>
            public static Result.Base AllocationMemoryFailedInPathNormalizer => new(ModuleFs, 3367);
            /// <summary>Error code: 2002-3375; Inner value: 0x1a5e02</summary>
            public static Result.Base AllocationMemoryFailedInDbmRomKeyValueStorage => new(ModuleFs, 3375);
            /// <summary>Error code: 2002-3376; Inner value: 0x1a6002</summary>
            public static Result.Base AllocationMemoryFailedInDbmHierarchicalRomFileTable => new(ModuleFs, 3376);
            /// <summary>Error code: 2002-3377; Inner value: 0x1a6202</summary>
            public static Result.Base AllocationMemoryFailedInRomFsFileSystemE => new(ModuleFs, 3377);
            /// <summary>Error code: 2002-3378; Inner value: 0x1a6402</summary>
            public static Result.Base AllocationMemoryFailedInISaveFileSystemA => new(ModuleFs, 3378);
            /// <summary>Error code: 2002-3379; Inner value: 0x1a6602</summary>
            public static Result.Base AllocationMemoryFailedInISaveFileSystemB => new(ModuleFs, 3379);
            /// <summary>Error code: 2002-3380; Inner value: 0x1a6802</summary>
            public static Result.Base AllocationMemoryFailedInRomOnFileA => new(ModuleFs, 3380);
            /// <summary>Error code: 2002-3381; Inner value: 0x1a6a02</summary>
            public static Result.Base AllocationMemoryFailedInRomOnFileB => new(ModuleFs, 3381);
            /// <summary>Error code: 2002-3382; Inner value: 0x1a6c02</summary>
            public static Result.Base AllocationMemoryFailedInRomOnFileC => new(ModuleFs, 3382);
            /// <summary>In Initialize<br/>Error code: 2002-3383; Inner value: 0x1a6e02</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileE => new(ModuleFs, 3383);
            /// <summary>Error code: 2002-3384; Inner value: 0x1a7002</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileF => new(ModuleFs, 3384);
            /// <summary>Error code: 2002-3385; Inner value: 0x1a7202</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileG => new(ModuleFs, 3385);
            /// <summary>Error code: 2002-3386; Inner value: 0x1a7402</summary>
            public static Result.Base AllocationMemoryFailedInReadOnlyFileSystemA => new(ModuleFs, 3386);
            /// <summary>In Create allocating AesXtsFileSystem<br/>Error code: 2002-3394; Inner value: 0x1a8402</summary>
            public static Result.Base AllocationMemoryFailedInEncryptedFileSystemCreatorA => new(ModuleFs, 3394);
            /// <summary>Error code: 2002-3399; Inner value: 0x1a8e02</summary>
            public static Result.Base AllocationMemoryFailedInAesCtrCounterExtendedStorageA => new(ModuleFs, 3399);
            /// <summary>Error code: 2002-3400; Inner value: 0x1a9002</summary>
            public static Result.Base AllocationMemoryFailedInAesCtrCounterExtendedStorageB => new(ModuleFs, 3400);
            /// <summary>Error code: 2002-3406; Inner value: 0x1a9c02</summary>
            public static Result.Base AllocationMemoryFailedInSdmmcStorageServiceB => new(ModuleFs, 3406);
            /// <summary>In OpenFile or OpenDirectory<br/>Error code: 2002-3407; Inner value: 0x1a9e02</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemInterfaceAdapterA => new(ModuleFs, 3407);
            /// <summary>Error code: 2002-3408; Inner value: 0x1aa002</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorG => new(ModuleFs, 3408);
            /// <summary>Error code: 2002-3409; Inner value: 0x1aa202</summary>
            public static Result.Base AllocationMemoryFailedInGameCardFileSystemCreatorH => new(ModuleFs, 3409);
            /// <summary>Error code: 2002-3410; Inner value: 0x1aa402</summary>
            public static Result.Base AllocationMemoryFailedInAesXtsFileSystemB => new(ModuleFs, 3410);
            /// <summary>Error code: 2002-3411; Inner value: 0x1aa602</summary>
            public static Result.Base AllocationMemoryFailedInBufferedStorageA => new(ModuleFs, 3411);
            /// <summary>Error code: 2002-3412; Inner value: 0x1aa802</summary>
            public static Result.Base AllocationMemoryFailedInIntegrityRomFsStorageA => new(ModuleFs, 3412);
            /// <summary>Error code: 2002-3416; Inner value: 0x1ab002</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataFileSystemServiceImplB => new(ModuleFs, 3416);
            /// <summary>Error code: 2002-3420; Inner value: 0x1ab802</summary>
            public static Result.Base AllocationMemoryFailedNew => new(ModuleFs, 3420);
            /// <summary>Error code: 2002-3421; Inner value: 0x1aba02</summary>
            public static Result.Base AllocationMemoryFailedInFileSystemProxyImplA => new(ModuleFs, 3421);
            /// <summary>Error code: 2002-3422; Inner value: 0x1abc02</summary>
            public static Result.Base AllocationMemoryFailedMakeUnique => new(ModuleFs, 3422);
            /// <summary>Error code: 2002-3423; Inner value: 0x1abe02</summary>
            public static Result.Base AllocationMemoryFailedAllocateShared => new(ModuleFs, 3423);
            /// <summary>Error code: 2002-3424; Inner value: 0x1ac002</summary>
            public static Result.Base AllocationPooledBufferNotEnoughSize => new(ModuleFs, 3424);
            /// <summary>Error code: 2002-3428; Inner value: 0x1ac802</summary>
            public static Result.Base AllocationMemoryFailedInWriteThroughCacheStorageA => new(ModuleFs, 3428);
            /// <summary>Error code: 2002-3429; Inner value: 0x1aca02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataTransferManagerA => new(ModuleFs, 3429);
            /// <summary>Error code: 2002-3430; Inner value: 0x1acc02</summary>
            public static Result.Base AllocationMemoryFailedInSaveDataTransferManagerB => new(ModuleFs, 3430);
            /// <summary>Error code: 2002-3431; Inner value: 0x1ace02</summary>
            public static Result.Base AllocationMemoryFailedInHtcFileSystemA => new(ModuleFs, 3431);
            /// <summary>Error code: 2002-3432; Inner value: 0x1ad002</summary>
            public static Result.Base AllocationMemoryFailedInHtcFileSystemB => new(ModuleFs, 3432);
            /// <summary>Error code: 2002-3433; Inner value: 0x1ad202</summary>
            public static Result.Base AllocationMemoryFailedInGameCardManagerG => new(ModuleFs, 3433);

        /// <summary>Error code: 2002-3500; Range: 3500-3999; Inner value: 0x1b5802</summary>
        public static Result.Base MmcAccessFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3500, 3999); }
            /// <summary>Error code: 2002-3501; Inner value: 0x1b5a02</summary>
            public static Result.Base PortMmcNoDevice => new(ModuleFs, 3501);
            /// <summary>Error code: 2002-3502; Inner value: 0x1b5c02</summary>
            public static Result.Base PortMmcNotActivated => new(ModuleFs, 3502);
            /// <summary>Error code: 2002-3503; Inner value: 0x1b5e02</summary>
            public static Result.Base PortMmcDeviceRemoved => new(ModuleFs, 3503);
            /// <summary>Error code: 2002-3504; Inner value: 0x1b6002</summary>
            public static Result.Base PortMmcNotAwakened => new(ModuleFs, 3504);

            /// <summary>Error code: 2002-3532; Range: 3532-3626; Inner value: 0x1b9802</summary>
            public static Result.Base PortMmcCommunicationError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3532, 3626); }
                /// <summary>Error code: 2002-3533; Range: 3533-3546; Inner value: 0x1b9a02</summary>
                public static Result.Base PortMmcCommunicationNotAttained { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3533, 3546); }
                    /// <summary>Error code: 2002-3534; Inner value: 0x1b9c02</summary>
                    public static Result.Base PortMmcResponseIndexError => new(ModuleFs, 3534);
                    /// <summary>Error code: 2002-3535; Inner value: 0x1b9e02</summary>
                    public static Result.Base PortMmcResponseEndBitError => new(ModuleFs, 3535);
                    /// <summary>Error code: 2002-3536; Inner value: 0x1ba002</summary>
                    public static Result.Base PortMmcResponseCrcError => new(ModuleFs, 3536);
                    /// <summary>Error code: 2002-3537; Inner value: 0x1ba202</summary>
                    public static Result.Base PortMmcResponseTimeoutError => new(ModuleFs, 3537);
                    /// <summary>Error code: 2002-3538; Inner value: 0x1ba402</summary>
                    public static Result.Base PortMmcDataEndBitError => new(ModuleFs, 3538);
                    /// <summary>Error code: 2002-3539; Inner value: 0x1ba602</summary>
                    public static Result.Base PortMmcDataCrcError => new(ModuleFs, 3539);
                    /// <summary>Error code: 2002-3540; Inner value: 0x1ba802</summary>
                    public static Result.Base PortMmcDataTimeoutError => new(ModuleFs, 3540);
                    /// <summary>Error code: 2002-3541; Inner value: 0x1baa02</summary>
                    public static Result.Base PortMmcAutoCommandResponseIndexError => new(ModuleFs, 3541);
                    /// <summary>Error code: 2002-3542; Inner value: 0x1bac02</summary>
                    public static Result.Base PortMmcAutoCommandResponseEndBitError => new(ModuleFs, 3542);
                    /// <summary>Error code: 2002-3543; Inner value: 0x1bae02</summary>
                    public static Result.Base PortMmcAutoCommandResponseCrcError => new(ModuleFs, 3543);
                    /// <summary>Error code: 2002-3544; Inner value: 0x1bb002</summary>
                    public static Result.Base PortMmcAutoCommandResponseTimeoutError => new(ModuleFs, 3544);
                    /// <summary>Error code: 2002-3545; Inner value: 0x1bb202</summary>
                    public static Result.Base PortMmcCommandCompleteSwTimeout => new(ModuleFs, 3545);
                    /// <summary>Error code: 2002-3546; Inner value: 0x1bb402</summary>
                    public static Result.Base PortMmcTransferCompleteSwTimeout => new(ModuleFs, 3546);

                /// <summary>Error code: 2002-3548; Range: 3548-3570; Inner value: 0x1bb802</summary>
                public static Result.Base PortMmcDeviceStatusHasError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3548, 3570); }
                    /// <summary>Error code: 2002-3549; Inner value: 0x1bba02</summary>
                    public static Result.Base PortMmcDeviceStatusAddressOutOfRange => new(ModuleFs, 3549);
                    /// <summary>Error code: 2002-3550; Inner value: 0x1bbc02</summary>
                    public static Result.Base PortMmcDeviceStatusAddressMisalign => new(ModuleFs, 3550);
                    /// <summary>Error code: 2002-3551; Inner value: 0x1bbe02</summary>
                    public static Result.Base PortMmcDeviceStatusBlockLenError => new(ModuleFs, 3551);
                    /// <summary>Error code: 2002-3552; Inner value: 0x1bc002</summary>
                    public static Result.Base PortMmcDeviceStatusEraseSeqError => new(ModuleFs, 3552);
                    /// <summary>Error code: 2002-3553; Inner value: 0x1bc202</summary>
                    public static Result.Base PortMmcDeviceStatusEraseParam => new(ModuleFs, 3553);
                    /// <summary>Error code: 2002-3554; Inner value: 0x1bc402</summary>
                    public static Result.Base PortMmcDeviceStatusWpViolation => new(ModuleFs, 3554);
                    /// <summary>Error code: 2002-3555; Inner value: 0x1bc602</summary>
                    public static Result.Base PortMmcDeviceStatusLockUnlockFailed => new(ModuleFs, 3555);
                    /// <summary>Error code: 2002-3556; Inner value: 0x1bc802</summary>
                    public static Result.Base PortMmcDeviceStatusComCrcError => new(ModuleFs, 3556);
                    /// <summary>Error code: 2002-3557; Inner value: 0x1bca02</summary>
                    public static Result.Base PortMmcDeviceStatusIllegalCommand => new(ModuleFs, 3557);
                    /// <summary>Error code: 2002-3558; Inner value: 0x1bcc02</summary>
                    public static Result.Base PortMmcDeviceStatusDeviceEccFailed => new(ModuleFs, 3558);
                    /// <summary>Error code: 2002-3559; Inner value: 0x1bce02</summary>
                    public static Result.Base PortMmcDeviceStatusCcError => new(ModuleFs, 3559);
                    /// <summary>Error code: 2002-3560; Inner value: 0x1bd002</summary>
                    public static Result.Base PortMmcDeviceStatusError => new(ModuleFs, 3560);
                    /// <summary>Error code: 2002-3561; Inner value: 0x1bd202</summary>
                    public static Result.Base PortMmcDeviceStatusCidCsdOverwrite => new(ModuleFs, 3561);
                    /// <summary>Error code: 2002-3562; Inner value: 0x1bd402</summary>
                    public static Result.Base PortMmcDeviceStatusWpEraseSkip => new(ModuleFs, 3562);
                    /// <summary>Error code: 2002-3563; Inner value: 0x1bd602</summary>
                    public static Result.Base PortMmcDeviceStatusEraseReset => new(ModuleFs, 3563);
                    /// <summary>Error code: 2002-3564; Inner value: 0x1bd802</summary>
                    public static Result.Base PortMmcDeviceStatusSwitchError => new(ModuleFs, 3564);

                /// <summary>Error code: 2002-3572; Inner value: 0x1be802</summary>
                public static Result.Base PortMmcUnexpectedDeviceState => new(ModuleFs, 3572);
                /// <summary>Error code: 2002-3573; Inner value: 0x1bea02</summary>
                public static Result.Base PortMmcUnexpectedDeviceCsdValue => new(ModuleFs, 3573);
                /// <summary>Error code: 2002-3574; Inner value: 0x1bec02</summary>
                public static Result.Base PortMmcAbortTransactionSwTimeout => new(ModuleFs, 3574);
                /// <summary>Error code: 2002-3575; Inner value: 0x1bee02</summary>
                public static Result.Base PortMmcCommandInhibitCmdSwTimeout => new(ModuleFs, 3575);
                /// <summary>Error code: 2002-3576; Inner value: 0x1bf002</summary>
                public static Result.Base PortMmcCommandInhibitDatSwTimeout => new(ModuleFs, 3576);
                /// <summary>Error code: 2002-3577; Inner value: 0x1bf202</summary>
                public static Result.Base PortMmcBusySwTimeout => new(ModuleFs, 3577);
                /// <summary>Error code: 2002-3578; Inner value: 0x1bf402</summary>
                public static Result.Base PortMmcIssueTuningCommandSwTimeout => new(ModuleFs, 3578);
                /// <summary>Error code: 2002-3579; Inner value: 0x1bf602</summary>
                public static Result.Base PortMmcTuningFailed => new(ModuleFs, 3579);
                /// <summary>Error code: 2002-3580; Inner value: 0x1bf802</summary>
                public static Result.Base PortMmcMmcInitializationSwTimeout => new(ModuleFs, 3580);
                /// <summary>Error code: 2002-3581; Inner value: 0x1bfa02</summary>
                public static Result.Base PortMmcMmcNotSupportExtendedCsd => new(ModuleFs, 3581);
                /// <summary>Error code: 2002-3582; Inner value: 0x1bfc02</summary>
                public static Result.Base PortMmcUnexpectedMmcExtendedCsdValue => new(ModuleFs, 3582);
                /// <summary>Error code: 2002-3583; Inner value: 0x1bfe02</summary>
                public static Result.Base PortMmcMmcEraseSwTimeout => new(ModuleFs, 3583);
                /// <summary>Error code: 2002-3584; Inner value: 0x1c0002</summary>
                public static Result.Base PortMmcSdCardValidationError => new(ModuleFs, 3584);
                /// <summary>Error code: 2002-3585; Inner value: 0x1c0202</summary>
                public static Result.Base PortMmcSdCardInitializationSwTimeout => new(ModuleFs, 3585);
                /// <summary>Error code: 2002-3586; Inner value: 0x1c0402</summary>
                public static Result.Base PortMmcSdCardGetValidRcaSwTimeout => new(ModuleFs, 3586);
                /// <summary>Error code: 2002-3587; Inner value: 0x1c0602</summary>
                public static Result.Base PortMmcUnexpectedSdCardAcmdDisabled => new(ModuleFs, 3587);
                /// <summary>Error code: 2002-3588; Inner value: 0x1c0802</summary>
                public static Result.Base PortMmcSdCardNotSupportSwitchFunctionStatus => new(ModuleFs, 3588);
                /// <summary>Error code: 2002-3589; Inner value: 0x1c0a02</summary>
                public static Result.Base PortMmcUnexpectedSdCardSwitchFunctionStatus => new(ModuleFs, 3589);
                /// <summary>Error code: 2002-3590; Inner value: 0x1c0c02</summary>
                public static Result.Base PortMmcSdCardNotSupportAccessMode => new(ModuleFs, 3590);
                /// <summary>Error code: 2002-3591; Inner value: 0x1c0e02</summary>
                public static Result.Base PortMmcSdCardNot4BitBusWidthAtUhsIMode => new(ModuleFs, 3591);
                /// <summary>Error code: 2002-3592; Inner value: 0x1c1002</summary>
                public static Result.Base PortMmcSdCardNotSupportSdr104AndSdr50 => new(ModuleFs, 3592);
                /// <summary>Error code: 2002-3593; Inner value: 0x1c1202</summary>
                public static Result.Base PortMmcSdCardCannotSwitchedAccessMode => new(ModuleFs, 3593);
                /// <summary>Error code: 2002-3594; Inner value: 0x1c1402</summary>
                public static Result.Base PortMmcSdCardFailedSwitchedAccessMode => new(ModuleFs, 3594);
                /// <summary>Error code: 2002-3595; Inner value: 0x1c1602</summary>
                public static Result.Base PortMmcSdCardUnacceptableCurrentConsumption => new(ModuleFs, 3595);
                /// <summary>Error code: 2002-3596; Inner value: 0x1c1802</summary>
                public static Result.Base PortMmcSdCardNotReadyToVoltageSwitch => new(ModuleFs, 3596);
                /// <summary>Error code: 2002-3597; Inner value: 0x1c1a02</summary>
                public static Result.Base PortMmcSdCardNotCompleteVoltageSwitch => new(ModuleFs, 3597);

            /// <summary>Error code: 2002-3628; Range: 3628-3658; Inner value: 0x1c5802</summary>
            public static Result.Base PortMmcHostControllerUnexpected { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3628, 3658); }
                /// <summary>Error code: 2002-3629; Inner value: 0x1c5a02</summary>
                public static Result.Base PortMmcInternalClockStableSwTimeout => new(ModuleFs, 3629);
                /// <summary>Error code: 2002-3630; Inner value: 0x1c5c02</summary>
                public static Result.Base PortMmcSdHostStandardUnknownAutoCmdError => new(ModuleFs, 3630);
                /// <summary>Error code: 2002-3631; Inner value: 0x1c5e02</summary>
                public static Result.Base PortMmcSdHostStandardUnknownError => new(ModuleFs, 3631);
                /// <summary>Error code: 2002-3632; Inner value: 0x1c6002</summary>
                public static Result.Base PortMmcSdmmcDllCalibrationSwTimeout => new(ModuleFs, 3632);
                /// <summary>Error code: 2002-3633; Inner value: 0x1c6202</summary>
                public static Result.Base PortMmcSdmmcDllApplicationSwTimeout => new(ModuleFs, 3633);
                /// <summary>Error code: 2002-3634; Inner value: 0x1c6402</summary>
                public static Result.Base PortMmcSdHostStandardFailSwitchTo18V => new(ModuleFs, 3634);

            /// <summary>Error code: 2002-3660; Range: 3660-3690; Inner value: 0x1c9802</summary>
            public static Result.Base PortMmcInternalError { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 3660, 3690); }
                /// <summary>Error code: 2002-3661; Inner value: 0x1c9a02</summary>
                public static Result.Base PortMmcNoWaitedInterrupt => new(ModuleFs, 3661);
                /// <summary>Error code: 2002-3662; Inner value: 0x1c9c02</summary>
                public static Result.Base PortMmcWaitInterruptSwTimeout => new(ModuleFs, 3662);

            /// <summary>Error code: 2002-3692; Inner value: 0x1cd802</summary>
            public static Result.Base PortMmcAbortCommandIssued => new(ModuleFs, 3692);
            /// <summary>Error code: 2002-3700; Inner value: 0x1ce802</summary>
            public static Result.Base PortMmcNotSupported => new(ModuleFs, 3700);
            /// <summary>Error code: 2002-3701; Inner value: 0x1cea02</summary>
            public static Result.Base PortMmcNotImplemented => new(ModuleFs, 3701);
            /// <summary>Error code: 2002-3998; Inner value: 0x1f3c02</summary>
            public static Result.Base PortMmcStorageDeviceInvalidated => new(ModuleFs, 3998);
            /// <summary>Error code: 2002-3999; Inner value: 0x1f3e02</summary>
            public static Result.Base PortMmcUnexpected => new(ModuleFs, 3999);

        /// <summary>Error code: 2002-4000; Range: 4000-4999; Inner value: 0x1f4002</summary>
        public static Result.Base DataCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4000, 4999); }
            /// <summary>Error code: 2002-4001; Range: 4001-4299; Inner value: 0x1f4202</summary>
            public static Result.Base RomCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4001, 4299); }
                /// <summary>Error code: 2002-4002; Inner value: 0x1f4402</summary>
                public static Result.Base UnsupportedRomVersion => new(ModuleFs, 4002);

                /// <summary>Error code: 2002-4011; Range: 4011-4019; Inner value: 0x1f5602</summary>
                public static Result.Base AesCtrCounterExtendedStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4011, 4019); }
                    /// <summary>Error code: 2002-4012; Inner value: 0x1f5802</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedEntryOffset => new(ModuleFs, 4012);
                    /// <summary>Error code: 2002-4013; Inner value: 0x1f5a02</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedTableSize => new(ModuleFs, 4013);
                    /// <summary>Error code: 2002-4014; Inner value: 0x1f5c02</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedGeneration => new(ModuleFs, 4014);
                    /// <summary>Error code: 2002-4015; Inner value: 0x1f5e02</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedOffset => new(ModuleFs, 4015);
                    /// <summary>Error code: 2002-4016; Inner value: 0x1f6002</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedDataStorageSize => new(ModuleFs, 4016);
                    /// <summary>Error code: 2002-4017; Inner value: 0x1f6202</summary>
                    public static Result.Base InvalidAesCtrCounterExtendedMetaStorageSize => new(ModuleFs, 4017);

                /// <summary>Error code: 2002-4021; Range: 4021-4029; Inner value: 0x1f6a02</summary>
                public static Result.Base IndirectStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4021, 4029); }
                    /// <summary>Error code: 2002-4022; Inner value: 0x1f6c02</summary>
                    public static Result.Base InvalidIndirectEntryOffset => new(ModuleFs, 4022);
                    /// <summary>Error code: 2002-4023; Inner value: 0x1f6e02</summary>
                    public static Result.Base InvalidIndirectEntryStorageIndex => new(ModuleFs, 4023);
                    /// <summary>Error code: 2002-4024; Inner value: 0x1f7002</summary>
                    public static Result.Base InvalidIndirectStorageSize => new(ModuleFs, 4024);
                    /// <summary>Error code: 2002-4025; Inner value: 0x1f7202</summary>
                    public static Result.Base InvalidIndirectVirtualOffset => new(ModuleFs, 4025);
                    /// <summary>Error code: 2002-4026; Inner value: 0x1f7402</summary>
                    public static Result.Base InvalidIndirectPhysicalOffset => new(ModuleFs, 4026);
                    /// <summary>Error code: 2002-4027; Inner value: 0x1f7602</summary>
                    public static Result.Base InvalidIndirectStorageIndex => new(ModuleFs, 4027);
                    /// <summary>Error code: 2002-4028; Inner value: 0x1f7802</summary>
                    public static Result.Base InvalidIndirectStorageBucketTreeSize => new(ModuleFs, 4028);

                /// <summary>Error code: 2002-4031; Range: 4031-4039; Inner value: 0x1f7e02</summary>
                public static Result.Base BucketTreeCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4031, 4039); }
                    /// <summary>Error code: 2002-4032; Inner value: 0x1f8002</summary>
                    public static Result.Base InvalidBucketTreeSignature => new(ModuleFs, 4032);
                    /// <summary>Error code: 2002-4033; Inner value: 0x1f8202</summary>
                    public static Result.Base InvalidBucketTreeEntryCount => new(ModuleFs, 4033);
                    /// <summary>Error code: 2002-4034; Inner value: 0x1f8402</summary>
                    public static Result.Base InvalidBucketTreeNodeEntryCount => new(ModuleFs, 4034);
                    /// <summary>Error code: 2002-4035; Inner value: 0x1f8602</summary>
                    public static Result.Base InvalidBucketTreeNodeOffset => new(ModuleFs, 4035);
                    /// <summary>Error code: 2002-4036; Inner value: 0x1f8802</summary>
                    public static Result.Base InvalidBucketTreeEntryOffset => new(ModuleFs, 4036);
                    /// <summary>Error code: 2002-4037; Inner value: 0x1f8a02</summary>
                    public static Result.Base InvalidBucketTreeEntrySetOffset => new(ModuleFs, 4037);
                    /// <summary>Error code: 2002-4038; Inner value: 0x1f8c02</summary>
                    public static Result.Base InvalidBucketTreeNodeIndex => new(ModuleFs, 4038);
                    /// <summary>Error code: 2002-4039; Inner value: 0x1f8e02</summary>
                    public static Result.Base InvalidBucketTreeVirtualOffset => new(ModuleFs, 4039);

                /// <summary>Error code: 2002-4041; Range: 4041-4139; Inner value: 0x1f9202</summary>
                public static Result.Base RomNcaCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4041, 4139); }
                    /// <summary>Error code: 2002-4051; Range: 4051-4069; Inner value: 0x1fa602</summary>
                    public static Result.Base RomNcaFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4051, 4069); }
                        /// <summary>Error code: 2002-4052; Inner value: 0x1fa802</summary>
                        public static Result.Base InvalidRomNcaFileSystemType => new(ModuleFs, 4052);
                        /// <summary>Error code: 2002-4053; Inner value: 0x1faa02</summary>
                        public static Result.Base InvalidRomAcidFileSize => new(ModuleFs, 4053);
                        /// <summary>Error code: 2002-4054; Inner value: 0x1fac02</summary>
                        public static Result.Base InvalidRomAcidSize => new(ModuleFs, 4054);
                        /// <summary>Error code: 2002-4055; Inner value: 0x1fae02</summary>
                        public static Result.Base InvalidRomAcid => new(ModuleFs, 4055);
                        /// <summary>Error code: 2002-4056; Inner value: 0x1fb002</summary>
                        public static Result.Base RomAcidVerificationFailed => new(ModuleFs, 4056);
                        /// <summary>Error code: 2002-4057; Inner value: 0x1fb202</summary>
                        public static Result.Base InvalidRomNcaSignature => new(ModuleFs, 4057);
                        /// <summary>Error code: 2002-4058; Inner value: 0x1fb402</summary>
                        public static Result.Base RomNcaHeaderSignature1VerificationFailed => new(ModuleFs, 4058);
                        /// <summary>Error code: 2002-4059; Inner value: 0x1fb602</summary>
                        public static Result.Base RomNcaHeaderSignature2VerificationFailed => new(ModuleFs, 4059);
                        /// <summary>Error code: 2002-4060; Inner value: 0x1fb802</summary>
                        public static Result.Base RomNcaFsHeaderHashVerificationFailed => new(ModuleFs, 4060);
                        /// <summary>Error code: 2002-4061; Inner value: 0x1fba02</summary>
                        public static Result.Base InvalidRomNcaKeyIndex => new(ModuleFs, 4061);
                        /// <summary>Error code: 2002-4062; Inner value: 0x1fbc02</summary>
                        public static Result.Base InvalidRomNcaFsHeaderHashType => new(ModuleFs, 4062);
                        /// <summary>Error code: 2002-4063; Inner value: 0x1fbe02</summary>
                        public static Result.Base InvalidRomNcaFsHeaderEncryptionType => new(ModuleFs, 4063);
                        /// <summary>Error code: 2002-4064; Inner value: 0x1fc002</summary>
                        public static Result.Base InvalidRomNcaPatchInfoIndirectSize => new(ModuleFs, 4064);
                        /// <summary>Error code: 2002-4065; Inner value: 0x1fc202</summary>
                        public static Result.Base InvalidRomNcaPatchInfoAesCtrExSize => new(ModuleFs, 4065);
                        /// <summary>Error code: 2002-4066; Inner value: 0x1fc402</summary>
                        public static Result.Base InvalidRomNcaPatchInfoAesCtrExOffset => new(ModuleFs, 4066);
                        /// <summary>Error code: 2002-4067; Inner value: 0x1fc602</summary>
                        public static Result.Base InvalidRomNcaId => new(ModuleFs, 4067);
                        /// <summary>Error code: 2002-4068; Inner value: 0x1fc802</summary>
                        public static Result.Base InvalidRomNcaHeader => new(ModuleFs, 4068);
                        /// <summary>Error code: 2002-4069; Inner value: 0x1fca02</summary>
                        public static Result.Base InvalidRomNcaFsHeader => new(ModuleFs, 4069);

                    /// <summary>Error code: 2002-4070; Inner value: 0x1fcc02</summary>
                    public static Result.Base InvalidRomNcaPatchInfoIndirectOffset => new(ModuleFs, 4070);

                    /// <summary>Error code: 2002-4071; Range: 4071-4079; Inner value: 0x1fce02</summary>
                    public static Result.Base RomNcaHierarchicalSha256StorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4071, 4079); }
                        /// <summary>Error code: 2002-4072; Inner value: 0x1fd002</summary>
                        public static Result.Base InvalidRomHierarchicalSha256BlockSize => new(ModuleFs, 4072);
                        /// <summary>Error code: 2002-4073; Inner value: 0x1fd202</summary>
                        public static Result.Base InvalidRomHierarchicalSha256LayerCount => new(ModuleFs, 4073);
                        /// <summary>Error code: 2002-4074; Inner value: 0x1fd402</summary>
                        public static Result.Base RomHierarchicalSha256BaseStorageTooLarge => new(ModuleFs, 4074);
                        /// <summary>Error code: 2002-4075; Inner value: 0x1fd602</summary>
                        public static Result.Base RomHierarchicalSha256HashVerificationFailed => new(ModuleFs, 4075);

                    /// <summary>Error code: 2002-4081; Inner value: 0x1fe202</summary>
                    public static Result.Base InvalidRomHierarchicalIntegrityVerificationLayerCount => new(ModuleFs, 4081);
                    /// <summary>Error code: 2002-4082; Inner value: 0x1fe402</summary>
                    public static Result.Base RomNcaIndirectStorageOutOfRange => new(ModuleFs, 4082);
                    /// <summary>Error code: 2002-4083; Inner value: 0x1fe602</summary>
                    public static Result.Base RomNcaInvalidCompressionInfo => new(ModuleFs, 4083);

                /// <summary>Error code: 2002-4141; Range: 4141-4179; Inner value: 0x205a02</summary>
                public static Result.Base RomIntegrityVerificationStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4141, 4179); }
                    /// <summary>Error code: 2002-4142; Inner value: 0x205c02</summary>
                    public static Result.Base IncorrectRomIntegrityVerificationMagicCode => new(ModuleFs, 4142);
                    /// <summary>Error code: 2002-4143; Inner value: 0x205e02</summary>
                    public static Result.Base InvalidRomZeroSignature => new(ModuleFs, 4143);
                    /// <summary>Error code: 2002-4144; Inner value: 0x206002</summary>
                    public static Result.Base RomNonRealDataVerificationFailed => new(ModuleFs, 4144);

                    /// <summary>Error code: 2002-4151; Range: 4151-4159; Inner value: 0x206e02</summary>
                    public static Result.Base RomRealDataVerificationFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4151, 4159); }
                        /// <summary>Error code: 2002-4152; Inner value: 0x207002</summary>
                        public static Result.Base ClearedRomRealDataVerificationFailed => new(ModuleFs, 4152);
                        /// <summary>Error code: 2002-4153; Inner value: 0x207202</summary>
                        public static Result.Base UnclearedRomRealDataVerificationFailed => new(ModuleFs, 4153);

                /// <summary>Error code: 2002-4181; Range: 4181-4199; Inner value: 0x20aa02</summary>
                public static Result.Base RomPartitionFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4181, 4199); }
                    /// <summary>Error code: 2002-4182; Inner value: 0x20ac02</summary>
                    public static Result.Base InvalidRomSha256PartitionHashTarget => new(ModuleFs, 4182);
                    /// <summary>Error code: 2002-4183; Inner value: 0x20ae02</summary>
                    public static Result.Base RomSha256PartitionHashVerificationFailed => new(ModuleFs, 4183);
                    /// <summary>Error code: 2002-4184; Inner value: 0x20b002</summary>
                    public static Result.Base RomPartitionSignatureVerificationFailed => new(ModuleFs, 4184);
                    /// <summary>Error code: 2002-4185; Inner value: 0x20b202</summary>
                    public static Result.Base RomSha256PartitionSignatureVerificationFailed => new(ModuleFs, 4185);
                    /// <summary>Error code: 2002-4186; Inner value: 0x20b402</summary>
                    public static Result.Base InvalidRomPartitionEntryOffset => new(ModuleFs, 4186);
                    /// <summary>Error code: 2002-4187; Inner value: 0x20b602</summary>
                    public static Result.Base InvalidRomSha256PartitionMetaDataSize => new(ModuleFs, 4187);

                /// <summary>Error code: 2002-4201; Range: 4201-4219; Inner value: 0x20d202</summary>
                public static Result.Base RomBuiltInStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4201, 4219); }
                    /// <summary>Error code: 2002-4202; Inner value: 0x20d402</summary>
                    public static Result.Base RomGptHeaderSignatureVerificationFailed => new(ModuleFs, 4202);

                /// <summary>Error code: 2002-4241; Range: 4241-4259; Inner value: 0x212202</summary>
                public static Result.Base RomHostFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4241, 4259); }
                    /// <summary>Error code: 2002-4242; Inner value: 0x212402</summary>
                    public static Result.Base RomHostEntryCorrupted => new(ModuleFs, 4242);
                    /// <summary>Error code: 2002-4243; Inner value: 0x212602</summary>
                    public static Result.Base RomHostFileDataCorrupted => new(ModuleFs, 4243);
                    /// <summary>Error code: 2002-4244; Inner value: 0x212802</summary>
                    public static Result.Base RomHostFileCorrupted => new(ModuleFs, 4244);
                    /// <summary>Error code: 2002-4245; Inner value: 0x212a02</summary>
                    public static Result.Base InvalidRomHostHandle => new(ModuleFs, 4245);

                /// <summary>Error code: 2002-4261; Range: 4261-4279; Inner value: 0x214a02</summary>
                public static Result.Base RomDatabaseCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4261, 4279); }
                    /// <summary>Error code: 2002-4262; Inner value: 0x214c02</summary>
                    public static Result.Base InvalidRomAllocationTableBlock => new(ModuleFs, 4262);
                    /// <summary>Error code: 2002-4263; Inner value: 0x214e02</summary>
                    public static Result.Base InvalidRomKeyValueListElementIndex => new(ModuleFs, 4263);

                /// <summary>Returned directly when the header says the total size of the RomFs metadata is 0 bytes.<br/>Error code: 2002-4280; Range: 4280-4284; Inner value: 0x217002</summary>
                public static Result.Base RomStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4280, 4284); }
                    /// <summary>The RomFs metadata is located beyond the end of the provided storage.<br/>Error code: 2002-4281; Inner value: 0x217202</summary>
                    public static Result.Base InvalidRomStorageSize => new(ModuleFs, 4281);

            /// <summary>Error code: 2002-4301; Range: 4301-4499; Inner value: 0x219a02</summary>
            public static Result.Base SaveDataCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4301, 4499); }
                /// <summary>Error code: 2002-4302; Inner value: 0x219c02</summary>
                public static Result.Base UnsupportedSaveDataVersion => new(ModuleFs, 4302);
                /// <summary>Error code: 2002-4303; Inner value: 0x219e02</summary>
                public static Result.Base InvalidSaveDataEntryType => new(ModuleFs, 4303);
                /// <summary>Error code: 2002-4304; Inner value: 0x21a002</summary>
                public static Result.Base ReconstructibleSaveDataCorrupted => new(ModuleFs, 4304);

                /// <summary>Error code: 2002-4311; Range: 4311-4319; Inner value: 0x21ae02</summary>
                public static Result.Base SaveDataFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4311, 4319); }
                    /// <summary>Error code: 2002-4312; Inner value: 0x21b002</summary>
                    public static Result.Base InvalidJournalIntegritySaveDataHashSize => new(ModuleFs, 4312);
                    /// <summary>Error code: 2002-4313; Inner value: 0x21b202</summary>
                    public static Result.Base InvalidJournalIntegritySaveDataCommitState => new(ModuleFs, 4313);
                    /// <summary>Error code: 2002-4314; Inner value: 0x21b402</summary>
                    public static Result.Base InvalidJournalIntegritySaveDataControlAreaSize => new(ModuleFs, 4314);
                    /// <summary>Error code: 2002-4315; Inner value: 0x21b602</summary>
                    public static Result.Base JournalIntegritySaveDataControlAreaVerificationFailed => new(ModuleFs, 4315);
                    /// <summary>Error code: 2002-4316; Inner value: 0x21b802</summary>
                    public static Result.Base JournalIntegritySaveDataMasterSignatureVerificationFailed => new(ModuleFs, 4316);
                    /// <summary>Error code: 2002-4317; Inner value: 0x21ba02</summary>
                    public static Result.Base IncorrectJournalIntegritySaveDataMagicCode => new(ModuleFs, 4317);

                /// <summary>Error code: 2002-4321; Range: 4321-4329; Inner value: 0x21c202</summary>
                public static Result.Base SaveDataDuplexStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4321, 4329); }
                    /// <summary>Error code: 2002-4322; Inner value: 0x21c402</summary>
                    public static Result.Base IncorrectDuplexMagicCode => new(ModuleFs, 4322);
                    /// <summary>Error code: 2002-4323; Inner value: 0x21c602</summary>
                    public static Result.Base DuplexStorageAccessOutOfRange => new(ModuleFs, 4323);

                /// <summary>Error code: 2002-4331; Range: 4331-4339; Inner value: 0x21d602</summary>
                public static Result.Base SaveDataMapCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4331, 4339); }
                    /// <summary>Error code: 2002-4332; Inner value: 0x21d802</summary>
                    public static Result.Base InvalidMapEntryCount => new(ModuleFs, 4332);
                    /// <summary>Error code: 2002-4333; Inner value: 0x21da02</summary>
                    public static Result.Base InvalidMapOffset => new(ModuleFs, 4333);
                    /// <summary>Error code: 2002-4334; Inner value: 0x21dc02</summary>
                    public static Result.Base InvalidMapSize => new(ModuleFs, 4334);
                    /// <summary>Error code: 2002-4335; Inner value: 0x21de02</summary>
                    public static Result.Base InvalidMapAlignment => new(ModuleFs, 4335);
                    /// <summary>Error code: 2002-4336; Inner value: 0x21e002</summary>
                    public static Result.Base InvalidMapStorageType => new(ModuleFs, 4336);
                    /// <summary>The range of the new map entry overlaps with the range of an existing map entry.<br/>Error code: 2002-4337; Inner value: 0x21e202</summary>
                    public static Result.Base MapAddressAlreadyRegistered => new(ModuleFs, 4337);
                    /// <summary>The storage for the map entry's storage type hasn't been registered.<br/>Error code: 2002-4338; Inner value: 0x21e402</summary>
                    public static Result.Base MapStorageNotFound => new(ModuleFs, 4338);
                    /// <summary>The storage registered for the map entry's storage type is too short to contain the physical range specified in the map entry.<br/>Error code: 2002-4339; Inner value: 0x21e602</summary>
                    public static Result.Base InvalidMapStorageSize => new(ModuleFs, 4339);

                /// <summary>Error code: 2002-4341; Range: 4341-4349; Inner value: 0x21ea02</summary>
                public static Result.Base SaveDataLogCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4341, 4349); }
                    /// <summary>Error code: 2002-4342; Inner value: 0x21ec02</summary>
                    public static Result.Base InvalidLogBlockSize => new(ModuleFs, 4342);
                    /// <summary>Error code: 2002-4343; Inner value: 0x21ee02</summary>
                    public static Result.Base InvalidLogOffset => new(ModuleFs, 4343);
                    /// <summary>Error code: 2002-4344; Inner value: 0x21f002</summary>
                    public static Result.Base UnexpectedEndOfLog => new(ModuleFs, 4344);
                    /// <summary>Error code: 2002-4345; Inner value: 0x21f202</summary>
                    public static Result.Base LogNotFound => new(ModuleFs, 4345);

                /// <summary>Error code: 2002-4352; Inner value: 0x220002</summary>
                public static Result.Base ThumbnailHashVerificationFailed => new(ModuleFs, 4352);
                /// <summary>Error code: 2002-4357; Inner value: 0x220a02</summary>
                public static Result.Base InvalidSaveDataInternalStorageIntegritySeedSize => new(ModuleFs, 4357);
                /// <summary>The bitmap for the allocation table is too small when opening InternalStorageFileNameIntegrityWithZeroFree.<br/>Error code: 2002-4358; Inner value: 0x220c02</summary>
                public static Result.Base InvalidSaveDataInternalStorageAllocationTableFreeBitmapSizeA => new(ModuleFs, 4358);
                /// <summary>The bitmap for the allocation table is too small when opening AllocationTableDataWithZeroFree.<br/>Error code: 2002-4359; Inner value: 0x220e02</summary>
                public static Result.Base InvalidSaveDataInternalStorageAllocationTableFreeBitmapSizeB => new(ModuleFs, 4359);

                /// <summary>Error code: 2002-4361; Range: 4361-4399; Inner value: 0x221202</summary>
                public static Result.Base SaveDataIntegrityVerificationStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4361, 4399); }
                    /// <summary>Error code: 2002-4362; Inner value: 0x221402</summary>
                    public static Result.Base IncorrectSaveDataIntegrityVerificationMagicCode => new(ModuleFs, 4362);
                    /// <summary>Error code: 2002-4363; Inner value: 0x221602</summary>
                    public static Result.Base InvalidSaveDataZeroHash => new(ModuleFs, 4363);
                    /// <summary>Error code: 2002-4364; Inner value: 0x221802</summary>
                    public static Result.Base SaveDataNonRealDataVerificationFailed => new(ModuleFs, 4364);

                    /// <summary>Error code: 2002-4371; Range: 4371-4379; Inner value: 0x222602</summary>
                    public static Result.Base SaveDataRealDataVerificationFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4371, 4379); }
                        /// <summary>Error code: 2002-4372; Inner value: 0x222802</summary>
                        public static Result.Base ClearedSaveDataRealDataVerificationFailed => new(ModuleFs, 4372);
                        /// <summary>Error code: 2002-4373; Inner value: 0x222a02</summary>
                        public static Result.Base UnclearedSaveDataRealDataVerificationFailed => new(ModuleFs, 4373);

                /// <summary>Error code: 2002-4401; Range: 4401-4419; Inner value: 0x226202</summary>
                public static Result.Base SaveDataBuiltInStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4401, 4419); }
                    /// <summary>Error code: 2002-4402; Inner value: 0x226402</summary>
                    public static Result.Base SaveDataGptHeaderSignatureVerificationFailed => new(ModuleFs, 4402);

                    /// <summary>Error code: 2002-4411; Range: 4411-4419; Inner value: 0x227602</summary>
                    public static Result.Base SaveDataCoreFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4411, 4419); }
                        /// <summary>Error code: 2002-4412; Inner value: 0x227802</summary>
                        public static Result.Base IncorrectSaveDataFileSystemMagicCode => new(ModuleFs, 4412);
                        /// <summary>Error code: 2002-4413; Inner value: 0x227a02</summary>
                        public static Result.Base InvalidSaveDataFileReadOffset => new(ModuleFs, 4413);
                        /// <summary>Error code: 2002-4414; Inner value: 0x227c02</summary>
                        public static Result.Base InvalidSaveDataCoreDataStorageSize => new(ModuleFs, 4414);

                /// <summary>Error code: 2002-4427; Inner value: 0x229602</summary>
                public static Result.Base IncompleteBlockInZeroBitmapHashStorageFileSaveData => new(ModuleFs, 4427);

                /// <summary>Error code: 2002-4431; Range: 4431-4439; Inner value: 0x229e02</summary>
                public static Result.Base JournalStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4431, 4439); }
                    /// <summary>Error code: 2002-4432; Inner value: 0x22a002</summary>
                    public static Result.Base JournalStorageAccessOutOfRange => new(ModuleFs, 4432);
                    /// <summary>Error code: 2002-4433; Inner value: 0x22a202</summary>
                    public static Result.Base InvalidJournalStorageDataStorageSize => new(ModuleFs, 4433);

                /// <summary>Error code: 2002-4441; Range: 4441-4459; Inner value: 0x22b202</summary>
                public static Result.Base SaveDataHostFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4441, 4459); }
                    /// <summary>Error code: 2002-4442; Inner value: 0x22b402</summary>
                    public static Result.Base SaveDataHostEntryCorrupted => new(ModuleFs, 4442);
                    /// <summary>Error code: 2002-4443; Inner value: 0x22b602</summary>
                    public static Result.Base SaveDataHostFileDataCorrupted => new(ModuleFs, 4443);
                    /// <summary>Error code: 2002-4444; Inner value: 0x22b802</summary>
                    public static Result.Base SaveDataHostFileCorrupted => new(ModuleFs, 4444);
                    /// <summary>Error code: 2002-4445; Inner value: 0x22ba02</summary>
                    public static Result.Base InvalidSaveDataHostHandle => new(ModuleFs, 4445);

                    /// <summary>Error code: 2002-4451; Range: 4451-4459; Inner value: 0x22c602</summary>
                    public static Result.Base MappingTableCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4451, 4459); }
                        /// <summary>Error code: 2002-4452; Inner value: 0x22c802</summary>
                        public static Result.Base InvalidMappingTableEntryCount => new(ModuleFs, 4452);
                        /// <summary>Error code: 2002-4453; Inner value: 0x22ca02</summary>
                        public static Result.Base InvalidMappingTablePhysicalIndex => new(ModuleFs, 4453);
                        /// <summary>Error code: 2002-4454; Inner value: 0x22cc02</summary>
                        public static Result.Base InvalidMappingTableVirtualIndex => new(ModuleFs, 4454);

                /// <summary>Error code: 2002-4461; Range: 4461-4479; Inner value: 0x22da02</summary>
                public static Result.Base SaveDataDatabaseCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4461, 4479); }
                    /// <summary>Error code: 2002-4462; Inner value: 0x22dc02</summary>
                    public static Result.Base InvalidSaveDataAllocationTableBlock => new(ModuleFs, 4462);
                    /// <summary>Error code: 2002-4463; Inner value: 0x22de02</summary>
                    public static Result.Base InvalidSaveDataKeyValueListElementIndex => new(ModuleFs, 4463);
                    /// <summary>Error code: 2002-4464; Inner value: 0x22e002</summary>
                    public static Result.Base InvalidSaveDataAllocationTableChainEntry => new(ModuleFs, 4464);
                    /// <summary>Error code: 2002-4465; Inner value: 0x22e202</summary>
                    public static Result.Base InvalidSaveDataAllocationTableOffset => new(ModuleFs, 4465);
                    /// <summary>Error code: 2002-4466; Inner value: 0x22e402</summary>
                    public static Result.Base InvalidSaveDataAllocationTableBlockCount => new(ModuleFs, 4466);
                    /// <summary>Error code: 2002-4467; Inner value: 0x22e602</summary>
                    public static Result.Base InvalidSaveDataKeyValueListEntryIndex => new(ModuleFs, 4467);
                    /// <summary>Error code: 2002-4468; Inner value: 0x22e802</summary>
                    public static Result.Base InvalidSaveDataBitmapIndex => new(ModuleFs, 4468);

                /// <summary>Error code: 2002-4481; Range: 4481-4489; Inner value: 0x230202</summary>
                public static Result.Base SaveDataExtensionContextCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4481, 4489); }
                    /// <summary>Error code: 2002-4482; Inner value: 0x230402</summary>
                    public static Result.Base IncorrectSaveDataExtensionContextMagicCode => new(ModuleFs, 4482);
                    /// <summary>Error code: 2002-4483; Inner value: 0x230602</summary>
                    public static Result.Base InvalidSaveDataExtensionContextState => new(ModuleFs, 4483);
                    /// <summary>The extension context doesn't match the current save data.<br/>Error code: 2002-4484; Inner value: 0x230802</summary>
                    public static Result.Base DifferentSaveDataExtensionContextParameter => new(ModuleFs, 4484);
                    /// <summary>Error code: 2002-4485; Inner value: 0x230a02</summary>
                    public static Result.Base InvalidSaveDataExtensionContextParameter => new(ModuleFs, 4485);

                /// <summary>Error code: 2002-4491; Range: 4491-4499; Inner value: 0x231602</summary>
                public static Result.Base IntegritySaveDataCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4491, 4499); }
                    /// <summary>Error code: 2002-4492; Inner value: 0x231802</summary>
                    public static Result.Base InvalidIntegritySaveDataHashSize => new(ModuleFs, 4492);
                    /// <summary>Error code: 2002-4494; Inner value: 0x231c02</summary>
                    public static Result.Base InvalidIntegritySaveDataControlAreaSize => new(ModuleFs, 4494);
                    /// <summary>Error code: 2002-4495; Inner value: 0x231e02</summary>
                    public static Result.Base IntegritySaveDataControlAreaVerificationFailed => new(ModuleFs, 4495);
                    /// <summary>Error code: 2002-4496; Inner value: 0x232002</summary>
                    public static Result.Base IntegritySaveDataMasterSignatureVerificationFailed => new(ModuleFs, 4496);
                    /// <summary>Error code: 2002-4497; Inner value: 0x232202</summary>
                    public static Result.Base IncorrectIntegritySaveDataMagicCode => new(ModuleFs, 4497);

            /// <summary>Error code: 2002-4501; Range: 4501-4599; Inner value: 0x232a02</summary>
            public static Result.Base NcaCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4501, 4599); }
                /// <summary>Error code: 2002-4508; Inner value: 0x233802</summary>
                public static Result.Base NcaBaseStorageOutOfRangeA => new(ModuleFs, 4508);
                /// <summary>Error code: 2002-4509; Inner value: 0x233a02</summary>
                public static Result.Base NcaBaseStorageOutOfRangeB => new(ModuleFs, 4509);
                /// <summary>Error code: 2002-4510; Inner value: 0x233c02</summary>
                public static Result.Base NcaBaseStorageOutOfRangeC => new(ModuleFs, 4510);

                /// <summary>Error code: 2002-4511; Range: 4511-4529; Inner value: 0x233e02</summary>
                public static Result.Base NcaFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4511, 4529); }
                    /// <summary>Error code: 2002-4512; Inner value: 0x234002</summary>
                    public static Result.Base InvalidNcaFileSystemType => new(ModuleFs, 4512);
                    /// <summary>Error code: 2002-4513; Inner value: 0x234202</summary>
                    public static Result.Base InvalidAcidFileSize => new(ModuleFs, 4513);
                    /// <summary>Error code: 2002-4514; Inner value: 0x234402</summary>
                    public static Result.Base InvalidAcidSize => new(ModuleFs, 4514);
                    /// <summary>Error code: 2002-4515; Inner value: 0x234602</summary>
                    public static Result.Base InvalidAcid => new(ModuleFs, 4515);
                    /// <summary>Error code: 2002-4516; Inner value: 0x234802</summary>
                    public static Result.Base AcidVerificationFailed => new(ModuleFs, 4516);
                    /// <summary>Error code: 2002-4517; Inner value: 0x234a02</summary>
                    public static Result.Base InvalidNcaSignature => new(ModuleFs, 4517);
                    /// <summary>Error code: 2002-4518; Inner value: 0x234c02</summary>
                    public static Result.Base NcaHeaderSignature1VerificationFailed => new(ModuleFs, 4518);
                    /// <summary>Error code: 2002-4519; Inner value: 0x234e02</summary>
                    public static Result.Base NcaHeaderSignature2VerificationFailed => new(ModuleFs, 4519);
                    /// <summary>Error code: 2002-4520; Inner value: 0x235002</summary>
                    public static Result.Base NcaFsHeaderHashVerificationFailed => new(ModuleFs, 4520);
                    /// <summary>Error code: 2002-4521; Inner value: 0x235202</summary>
                    public static Result.Base InvalidNcaKeyIndex => new(ModuleFs, 4521);
                    /// <summary>Error code: 2002-4522; Inner value: 0x235402</summary>
                    public static Result.Base InvalidNcaFsHeaderHashType => new(ModuleFs, 4522);
                    /// <summary>Error code: 2002-4523; Inner value: 0x235602</summary>
                    public static Result.Base InvalidNcaFsHeaderEncryptionType => new(ModuleFs, 4523);
                    /// <summary>Error code: 2002-4524; Inner value: 0x235802</summary>
                    public static Result.Base InvalidNcaPatchInfoIndirectSize => new(ModuleFs, 4524);
                    /// <summary>Error code: 2002-4525; Inner value: 0x235a02</summary>
                    public static Result.Base InvalidNcaPatchInfoAesCtrExSize => new(ModuleFs, 4525);
                    /// <summary>Error code: 2002-4526; Inner value: 0x235c02</summary>
                    public static Result.Base InvalidNcaPatchInfoAesCtrExOffset => new(ModuleFs, 4526);
                    /// <summary>Error code: 2002-4527; Inner value: 0x235e02</summary>
                    public static Result.Base InvalidNcaId => new(ModuleFs, 4527);
                    /// <summary>Error code: 2002-4528; Inner value: 0x236002</summary>
                    public static Result.Base InvalidNcaHeader => new(ModuleFs, 4528);
                    /// <summary>Error code: 2002-4529; Inner value: 0x236202</summary>
                    public static Result.Base InvalidNcaFsHeader => new(ModuleFs, 4529);

                /// <summary>Error code: 2002-4530; Inner value: 0x236402</summary>
                public static Result.Base InvalidNcaPatchInfoIndirectOffset => new(ModuleFs, 4530);

                /// <summary>Error code: 2002-4531; Range: 4531-4539; Inner value: 0x236602</summary>
                public static Result.Base NcaHierarchicalSha256StorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4531, 4539); }
                    /// <summary>Error code: 2002-4532; Inner value: 0x236802</summary>
                    public static Result.Base InvalidHierarchicalSha256BlockSize => new(ModuleFs, 4532);
                    /// <summary>Error code: 2002-4533; Inner value: 0x236a02</summary>
                    public static Result.Base InvalidHierarchicalSha256LayerCount => new(ModuleFs, 4533);
                    /// <summary>Error code: 2002-4534; Inner value: 0x236c02</summary>
                    public static Result.Base HierarchicalSha256BaseStorageTooLarge => new(ModuleFs, 4534);
                    /// <summary>Error code: 2002-4535; Inner value: 0x236e02</summary>
                    public static Result.Base HierarchicalSha256HashVerificationFailed => new(ModuleFs, 4535);

                /// <summary>Error code: 2002-4541; Inner value: 0x237a02</summary>
                public static Result.Base InvalidHierarchicalIntegrityVerificationLayerCount => new(ModuleFs, 4541);
                /// <summary>Error code: 2002-4542; Inner value: 0x237c02</summary>
                public static Result.Base NcaIndirectStorageOutOfRange => new(ModuleFs, 4542);
                /// <summary>Error code: 2002-4543; Inner value: 0x237e02</summary>
                public static Result.Base InvalidNcaHeader1SignatureKeyGeneration => new(ModuleFs, 4543);
                /// <summary>Error code: 2002-4545; Inner value: 0x238202</summary>
                public static Result.Base InvalidNspdVerificationData => new(ModuleFs, 4545);
                /// <summary>Error code: 2002-4546; Inner value: 0x238402</summary>
                public static Result.Base MissingNspdVerificationData => new(ModuleFs, 4546);
                /// <summary>Error code: 2002-4547; Inner value: 0x238602</summary>
                public static Result.Base NcaInvalidCompressionInfo => new(ModuleFs, 4547);

            /// <summary>Error code: 2002-4601; Range: 4601-4639; Inner value: 0x23f202</summary>
            public static Result.Base IntegrityVerificationStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4601, 4639); }
                /// <summary>Error code: 2002-4602; Inner value: 0x23f402</summary>
                public static Result.Base IncorrectIntegrityVerificationMagicCode => new(ModuleFs, 4602);
                /// <summary>Error code: 2002-4603; Inner value: 0x23f602</summary>
                public static Result.Base InvalidZeroHash => new(ModuleFs, 4603);
                /// <summary>Error code: 2002-4604; Inner value: 0x23f802</summary>
                public static Result.Base NonRealDataVerificationFailed => new(ModuleFs, 4604);

                /// <summary>Error code: 2002-4611; Range: 4611-4619; Inner value: 0x240602</summary>
                public static Result.Base RealDataVerificationFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4611, 4619); }
                    /// <summary>Error code: 2002-4612; Inner value: 0x240802</summary>
                    public static Result.Base ClearedRealDataVerificationFailed => new(ModuleFs, 4612);
                    /// <summary>Error code: 2002-4613; Inner value: 0x240a02</summary>
                    public static Result.Base UnclearedRealDataVerificationFailed => new(ModuleFs, 4613);

            /// <summary>Error code: 2002-4641; Range: 4641-4659; Inner value: 0x244202</summary>
            public static Result.Base PartitionFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4641, 4659); }
                /// <summary>Error code: 2002-4642; Inner value: 0x244402</summary>
                public static Result.Base InvalidSha256PartitionHashTarget => new(ModuleFs, 4642);
                /// <summary>Error code: 2002-4643; Inner value: 0x244602</summary>
                public static Result.Base Sha256PartitionHashVerificationFailed => new(ModuleFs, 4643);
                /// <summary>Error code: 2002-4644; Inner value: 0x244802</summary>
                public static Result.Base PartitionSignatureVerificationFailed => new(ModuleFs, 4644);
                /// <summary>Error code: 2002-4645; Inner value: 0x244a02</summary>
                public static Result.Base Sha256PartitionSignatureVerificationFailed => new(ModuleFs, 4645);
                /// <summary>Error code: 2002-4646; Inner value: 0x244c02</summary>
                public static Result.Base InvalidPartitionEntryOffset => new(ModuleFs, 4646);
                /// <summary>Error code: 2002-4647; Inner value: 0x244e02</summary>
                public static Result.Base InvalidSha256PartitionMetaDataSize => new(ModuleFs, 4647);

            /// <summary>Error code: 2002-4661; Range: 4661-4679; Inner value: 0x246a02</summary>
            public static Result.Base BuiltInStorageCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4661, 4679); }
                /// <summary>Error code: 2002-4662; Inner value: 0x246c02</summary>
                public static Result.Base GptHeaderSignatureVerificationFailed => new(ModuleFs, 4662);
                /// <summary>Error code: 2002-4664; Inner value: 0x247002</summary>
                public static Result.Base GptHeaderInvalidPartitionSize => new(ModuleFs, 4664);

            /// <summary>Error code: 2002-4681; Range: 4681-4699; Inner value: 0x249202</summary>
            public static Result.Base FatFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4681, 4699); }
                /// <summary>Error code: 2002-4683; Inner value: 0x249602</summary>
                public static Result.Base InvalidFatFormat => new(ModuleFs, 4683);
                /// <summary>Error code: 2002-4684; Inner value: 0x249802</summary>
                public static Result.Base InvalidFatFileNumber => new(ModuleFs, 4684);
                /// <summary>Error code: 2002-4685; Inner value: 0x249a02</summary>
                public static Result.Base ExFatUnavailable => new(ModuleFs, 4685);
                /// <summary>Error code: 2002-4686; Inner value: 0x249c02</summary>
                public static Result.Base InvalidFatFormatBisUser => new(ModuleFs, 4686);
                /// <summary>Error code: 2002-4687; Inner value: 0x249e02</summary>
                public static Result.Base InvalidFatFormatBisSystem => new(ModuleFs, 4687);
                /// <summary>Error code: 2002-4688; Inner value: 0x24a002</summary>
                public static Result.Base InvalidFatFormatBisSafe => new(ModuleFs, 4688);
                /// <summary>Error code: 2002-4689; Inner value: 0x24a202</summary>
                public static Result.Base InvalidFatFormatBisCalibration => new(ModuleFs, 4689);
                /// <summary>Error code: 2002-4690; Inner value: 0x24a402</summary>
                public static Result.Base InvalidFatFormatSd => new(ModuleFs, 4690);

            /// <summary>Error code: 2002-4701; Range: 4701-4719; Inner value: 0x24ba02</summary>
            public static Result.Base HostFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4701, 4719); }
                /// <summary>Error code: 2002-4702; Inner value: 0x24bc02</summary>
                public static Result.Base HostEntryCorrupted => new(ModuleFs, 4702);
                /// <summary>Error code: 2002-4703; Inner value: 0x24be02</summary>
                public static Result.Base HostFileDataCorrupted => new(ModuleFs, 4703);
                /// <summary>Error code: 2002-4704; Inner value: 0x24c002</summary>
                public static Result.Base HostFileCorrupted => new(ModuleFs, 4704);
                /// <summary>Error code: 2002-4705; Inner value: 0x24c202</summary>
                public static Result.Base InvalidHostHandle => new(ModuleFs, 4705);

            /// <summary>Error code: 2002-4721; Range: 4721-4739; Inner value: 0x24e202</summary>
            public static Result.Base DatabaseCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4721, 4739); }
                /// <summary>Error code: 2002-4722; Inner value: 0x24e402</summary>
                public static Result.Base InvalidAllocationTableBlock => new(ModuleFs, 4722);
                /// <summary>Error code: 2002-4723; Inner value: 0x24e602</summary>
                public static Result.Base InvalidKeyValueListElementIndex => new(ModuleFs, 4723);
                /// <summary>Error code: 2002-4724; Inner value: 0x24e802</summary>
                public static Result.Base InvalidAllocationTableChainEntry => new(ModuleFs, 4724);
                /// <summary>Error code: 2002-4725; Inner value: 0x24ea02</summary>
                public static Result.Base InvalidAllocationTableOffset => new(ModuleFs, 4725);
                /// <summary>Error code: 2002-4726; Inner value: 0x24ec02</summary>
                public static Result.Base InvalidAllocationTableBlockCount => new(ModuleFs, 4726);
                /// <summary>Error code: 2002-4727; Inner value: 0x24ee02</summary>
                public static Result.Base InvalidKeyValueListEntryIndex => new(ModuleFs, 4727);
                /// <summary>Error code: 2002-4728; Inner value: 0x24f002</summary>
                public static Result.Base InvalidBitmapIndex => new(ModuleFs, 4728);

            /// <summary>Error code: 2002-4741; Range: 4741-4759; Inner value: 0x250a02</summary>
            public static Result.Base AesXtsFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4741, 4759); }
                /// <summary>Error code: 2002-4742; Inner value: 0x250c02</summary>
                public static Result.Base AesXtsFileSystemFileHeaderSizeCorruptedOnFileOpen => new(ModuleFs, 4742);
                /// <summary>Error code: 2002-4743; Inner value: 0x250e02</summary>
                public static Result.Base AesXtsFileSystemFileHeaderCorruptedOnFileOpen => new(ModuleFs, 4743);
                /// <summary>Error code: 2002-4744; Inner value: 0x251002</summary>
                public static Result.Base AesXtsFileSystemFileNoHeaderOnFileOpen => new(ModuleFs, 4744);
                /// <summary>Error code: 2002-4745; Inner value: 0x251202</summary>
                public static Result.Base AesXtsFileSystemFileSizeCorruptedOnFileOpen => new(ModuleFs, 4745);
                /// <summary>Error code: 2002-4746; Inner value: 0x251402</summary>
                public static Result.Base AesXtsFileSystemFileSizeCorruptedOnFileSetSize => new(ModuleFs, 4746);
                /// <summary>Error code: 2002-4747; Inner value: 0x251602</summary>
                public static Result.Base AesXtsFileSystemFileHeaderCorruptedOnRename => new(ModuleFs, 4747);
                /// <summary>Error code: 2002-4748; Inner value: 0x251802</summary>
                public static Result.Base AesXtsFileSystemFileHeaderCorruptedOnFileSetSize => new(ModuleFs, 4748);

            /// <summary>Error code: 2002-4761; Range: 4761-4769; Inner value: 0x253202</summary>
            public static Result.Base SaveDataTransferDataCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4761, 4769); }
                /// <summary>Error code: 2002-4762; Inner value: 0x253402</summary>
                public static Result.Base SaveDataTransferTokenMacVerificationFailed => new(ModuleFs, 4762);
                /// <summary>Error code: 2002-4763; Inner value: 0x253602</summary>
                public static Result.Base SaveDataTransferTokenSignatureVerificationFailed => new(ModuleFs, 4763);
                /// <summary>Error code: 2002-4764; Inner value: 0x253802</summary>
                public static Result.Base SaveDataTransferTokenChallengeVerificationFailed => new(ModuleFs, 4764);
                /// <summary>Error code: 2002-4765; Inner value: 0x253a02</summary>
                public static Result.Base SaveDataTransferImportMacVerificationFailed => new(ModuleFs, 4765);
                /// <summary>Error code: 2002-4766; Inner value: 0x253c02</summary>
                public static Result.Base SaveDataTransferInitialDataMacVerificationFailed => new(ModuleFs, 4766);
                /// <summary>Error code: 2002-4767; Inner value: 0x253e02</summary>
                public static Result.Base SaveDataTransferInitialDataVersionVerificationFailed => new(ModuleFs, 4767);

            /// <summary>Error code: 2002-4771; Range: 4771-4779; Inner value: 0x254602</summary>
            public static Result.Base SignedSystemPartitionDataCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4771, 4779); }
                /// <summary>Error code: 2002-4772; Inner value: 0x254802</summary>
                public static Result.Base SignedSystemPartitionInvalidSize => new(ModuleFs, 4772);
                /// <summary>Error code: 2002-4773; Inner value: 0x254a02</summary>
                public static Result.Base SignedSystemPartitionSignatureVerificationFailed => new(ModuleFs, 4773);
                /// <summary>Error code: 2002-4774; Inner value: 0x254c02</summary>
                public static Result.Base SignedSystemPartitionHashVerificationFailed => new(ModuleFs, 4774);
                /// <summary>Error code: 2002-4775; Inner value: 0x254e02</summary>
                public static Result.Base SignedSystemPartitionPackage2HashVerificationFailed => new(ModuleFs, 4775);
                /// <summary>Error code: 2002-4776; Inner value: 0x255002</summary>
                public static Result.Base SignedSystemPartitionInvalidAppendHashCount => new(ModuleFs, 4776);

            /// <summary>Error code: 2002-4781; Inner value: 0x255a02</summary>
            public static Result.Base GameCardLogoDataCorrupted => new(ModuleFs, 4781);
            /// <summary>Error code: 2002-4785; Inner value: 0x256202</summary>
            public static Result.Base SimulatedDeviceDataCorrupted => new(ModuleFs, 4785);

            /// <summary>Error code: 2002-4790; Range: 4790-4799; Inner value: 0x256c02</summary>
            public static Result.Base MultiCommitContextCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4790, 4799); }
                /// <summary>The version of the multi-commit context file is too high for the current MultiCommitManager implementation.<br/>Error code: 2002-4791; Inner value: 0x256e02</summary>
                public static Result.Base InvalidMultiCommitContextVersion => new(ModuleFs, 4791);
                /// <summary>The multi-commit has not been provisionally committed.<br/>Error code: 2002-4792; Inner value: 0x257002</summary>
                public static Result.Base InvalidMultiCommitContextState => new(ModuleFs, 4792);

            /// <summary>Error code: 2002-4802; Inner value: 0x258402</summary>
            public static Result.Base ConcatenationFsInvalidInternalFileCount => new(ModuleFs, 4802);

            /// <summary>Error code: 2002-4811; Range: 4811-4819; Inner value: 0x259602</summary>
            public static Result.Base ZeroBitmapFileCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 4811, 4819); }
                /// <summary>Error code: 2002-4812; Inner value: 0x259802</summary>
                public static Result.Base IncompleteBlockInZeroBitmapHashStorageFile => new(ModuleFs, 4812);

        /// <summary>Error code: 2002-5000; Range: 5000-5999; Inner value: 0x271002</summary>
        public static Result.Base Unexpected { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 5000, 5999); }
            /// <summary>Error code: 2002-5001; Range: 5001-5299; Inner value: 0x271202</summary>
            public static Result.Base FatFsUnexpected { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 5001, 5299); }
                /// <summary>Error code: 2002-5002; Inner value: 0x271402</summary>
                public static Result.Base FatFsUnclassified => new(ModuleFs, 5002);
                /// <summary>Error code: 2002-5003; Inner value: 0x271602</summary>
                public static Result.Base FatFsStorageStateMissmatch => new(ModuleFs, 5003);
                /// <summary>Error code: 2002-5024; Inner value: 0x274002</summary>
                public static Result.Base FatFsTooManyFilesOpenedS => new(ModuleFs, 5024);
                /// <summary>Error code: 2002-5025; Inner value: 0x274202</summary>
                public static Result.Base FatFsTooManyFilesOpenedU => new(ModuleFs, 5025);
                /// <summary>Error code: 2002-5026; Inner value: 0x274402</summary>
                public static Result.Base FatFsNotAFile => new(ModuleFs, 5026);
                /// <summary>Error code: 2002-5028; Inner value: 0x274802</summary>
                public static Result.Base FatFsLockError => new(ModuleFs, 5028);
                /// <summary>Error code: 2002-5029; Inner value: 0x274a02</summary>
                public static Result.Base FatFsInternalError => new(ModuleFs, 5029);
                /// <summary>Error code: 2002-5055; Inner value: 0x277e02</summary>
                public static Result.Base FatFsModuleSafeError => new(ModuleFs, 5055);
                /// <summary>Error code: 2002-5110; Inner value: 0x27ec02</summary>
                public static Result.Base FatFsUnexpectedSystemError => new(ModuleFs, 5110);

                /// <summary>Error code: 2002-5120; Range: 5120-5129; Inner value: 0x280002</summary>
                public static Result.Base FatFsFormatUnexpected { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 5120, 5129); }
                    /// <summary>Error code: 2002-5121; Inner value: 0x280202</summary>
                    public static Result.Base FatFsFormatUnsupportedSize => new(ModuleFs, 5121);
                    /// <summary>Error code: 2002-5122; Inner value: 0x280402</summary>
                    public static Result.Base FatFsFormatInvalidBpb => new(ModuleFs, 5122);
                    /// <summary>Error code: 2002-5123; Inner value: 0x280602</summary>
                    public static Result.Base FatFsFormatInvalidParameter => new(ModuleFs, 5123);
                    /// <summary>Error code: 2002-5124; Inner value: 0x280802</summary>
                    public static Result.Base FatFsFormatIllegalSectorsA => new(ModuleFs, 5124);
                    /// <summary>Error code: 2002-5125; Inner value: 0x280a02</summary>
                    public static Result.Base FatFsFormatIllegalSectorsB => new(ModuleFs, 5125);
                    /// <summary>Error code: 2002-5126; Inner value: 0x280c02</summary>
                    public static Result.Base FatFsFormatIllegalSectorsC => new(ModuleFs, 5126);
                    /// <summary>Error code: 2002-5127; Inner value: 0x280e02</summary>
                    public static Result.Base FatFsFormatIllegalSectorsD => new(ModuleFs, 5127);

                /// <summary>Error code: 2002-5131; Inner value: 0x281602</summary>
                public static Result.Base FatFsWriteVerifyError => new(ModuleFs, 5131);

            /// <summary>Error code: 2002-5301; Inner value: 0x296a02</summary>
            public static Result.Base UnexpectedInMountTableA => new(ModuleFs, 5301);
            /// <summary>Error code: 2002-5302; Inner value: 0x296c02</summary>
            public static Result.Base UnexpectedInJournalIntegritySaveDataFileSystemA => new(ModuleFs, 5302);
            /// <summary>Error code: 2002-5303; Inner value: 0x296e02</summary>
            public static Result.Base UnexpectedInJournalIntegritySaveDataFileSystemB => new(ModuleFs, 5303);
            /// <summary>Tried to write to an IntegrityFilteredFile that is provisionally committed.<br/>Error code: 2002-5304; Inner value: 0x297002</summary>
            public static Result.Base UnexpectedInJournalIntegritySaveDataFileSystemC => new(ModuleFs, 5304);
            /// <summary>Error code: 2002-5305; Inner value: 0x297202</summary>
            public static Result.Base UnexpectedInLocalFileSystemA => new(ModuleFs, 5305);
            /// <summary>Error code: 2002-5306; Inner value: 0x297402</summary>
            public static Result.Base UnexpectedInLocalFileSystemB => new(ModuleFs, 5306);
            /// <summary>Error code: 2002-5307; Inner value: 0x297602</summary>
            public static Result.Base UnexpectedInLocalFileSystemC => new(ModuleFs, 5307);
            /// <summary>Error code: 2002-5308; Inner value: 0x297802</summary>
            public static Result.Base UnexpectedInLocalFileSystemD => new(ModuleFs, 5308);
            /// <summary>Error code: 2002-5309; Inner value: 0x297a02</summary>
            public static Result.Base UnexpectedInLocalFileSystemE => new(ModuleFs, 5309);
            /// <summary>Error code: 2002-5310; Inner value: 0x297c02</summary>
            public static Result.Base UnexpectedInLocalFileSystemF => new(ModuleFs, 5310);
            /// <summary>Error code: 2002-5311; Inner value: 0x297e02</summary>
            public static Result.Base UnexpectedInPathToolA => new(ModuleFs, 5311);
            /// <summary>Error code: 2002-5312; Inner value: 0x298002</summary>
            public static Result.Base UnexpectedInPathOnExecutionDirectoryA => new(ModuleFs, 5312);
            /// <summary>Error code: 2002-5313; Inner value: 0x298202</summary>
            public static Result.Base UnexpectedInPathOnExecutionDirectoryB => new(ModuleFs, 5313);
            /// <summary>Error code: 2002-5314; Inner value: 0x298402</summary>
            public static Result.Base UnexpectedInPathOnExecutionDirectoryC => new(ModuleFs, 5314);
            /// <summary>Error code: 2002-5315; Inner value: 0x298602</summary>
            public static Result.Base UnexpectedInAesCtrStorageA => new(ModuleFs, 5315);
            /// <summary>Error code: 2002-5316; Inner value: 0x298802</summary>
            public static Result.Base UnexpectedInAesXtsStorageA => new(ModuleFs, 5316);
            /// <summary>Error code: 2002-5317; Inner value: 0x298a02</summary>
            public static Result.Base UnexpectedInSaveDataInternalStorageFileSystemA => new(ModuleFs, 5317);
            /// <summary>Error code: 2002-5318; Inner value: 0x298c02</summary>
            public static Result.Base UnexpectedInSaveDataInternalStorageFileSystemB => new(ModuleFs, 5318);
            /// <summary>Error code: 2002-5319; Inner value: 0x298e02</summary>
            public static Result.Base UnexpectedInMountUtilityA => new(ModuleFs, 5319);
            /// <summary>Ncas cannot be mounted from the given mount point.<br/>Error code: 2002-5320; Inner value: 0x299002</summary>
            public static Result.Base UnexpectedInNcaFileSystemServiceImplA => new(ModuleFs, 5320);
            /// <summary>Error code: 2002-5321; Inner value: 0x299202</summary>
            public static Result.Base UnexpectedInRamDiskFileSystemA => new(ModuleFs, 5321);
            /// <summary>Error code: 2002-5322; Inner value: 0x299402</summary>
            public static Result.Base UnexpectedInBisWiperA => new(ModuleFs, 5322);
            /// <summary>Error code: 2002-5323; Inner value: 0x299602</summary>
            public static Result.Base UnexpectedInBisWiperB => new(ModuleFs, 5323);
            /// <summary>Error code: 2002-5324; Inner value: 0x299802</summary>
            public static Result.Base UnexpectedInCompressedStorageA => new(ModuleFs, 5324);
            /// <summary>Error code: 2002-5325; Inner value: 0x299a02</summary>
            public static Result.Base UnexpectedInCompressedStorageB => new(ModuleFs, 5325);
            /// <summary>Error code: 2002-5326; Inner value: 0x299c02</summary>
            public static Result.Base UnexpectedInCompressedStorageC => new(ModuleFs, 5326);
            /// <summary>Error code: 2002-5327; Inner value: 0x299e02</summary>
            public static Result.Base UnexpectedInCompressedStorageD => new(ModuleFs, 5327);
            /// <summary>Error code: 2002-5328; Inner value: 0x29a002</summary>
            public static Result.Base UnexpectedInPathA => new(ModuleFs, 5328);
            /// <summary>Error code: 2002-5333; Inner value: 0x29aa02</summary>
            public static Result.Base UnexpectedInSaveDataFileSystemCoreImplA => new(ModuleFs, 5333);
            /// <summary>Error code: 2002-5334; Inner value: 0x29ac02</summary>
            public static Result.Base UnexpectedInIntegritySaveDataFileSystemA => new(ModuleFs, 5334);
            /// <summary>Error code: 2002-5335; Inner value: 0x29ae02</summary>
            public static Result.Base UnexpectedInJournalIntegritySaveDataFileSystemD => new(ModuleFs, 5335);
            /// <summary>Error code: 2002-5336; Inner value: 0x29b002</summary>
            public static Result.Base UnexpectedInAlignmentMatchableFileSystemA => new(ModuleFs, 5336);

        /// <summary>Error code: 2002-6000; Range: 6000-6499; Inner value: 0x2ee002</summary>
        public static Result.Base PreconditionViolation { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6000, 6499); }
            /// <summary>Error code: 2002-6001; Range: 6001-6199; Inner value: 0x2ee202</summary>
            public static Result.Base InvalidArgument { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6001, 6199); }
                /// <summary>Error code: 2002-6002; Range: 6002-6029; Inner value: 0x2ee402</summary>
                public static Result.Base InvalidPath { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6002, 6029); }
                    /// <summary>Error code: 2002-6003; Inner value: 0x2ee602</summary>
                    public static Result.Base TooLongPath => new(ModuleFs, 6003);
                    /// <summary>Error code: 2002-6004; Inner value: 0x2ee802</summary>
                    public static Result.Base InvalidCharacter => new(ModuleFs, 6004);
                    /// <summary>Error code: 2002-6005; Inner value: 0x2eea02</summary>
                    public static Result.Base InvalidPathFormat => new(ModuleFs, 6005);
                    /// <summary>Error code: 2002-6006; Inner value: 0x2eec02</summary>
                    public static Result.Base DirectoryUnobtainable => new(ModuleFs, 6006);
                    /// <summary>Error code: 2002-6007; Inner value: 0x2eee02</summary>
                    public static Result.Base NotNormalized => new(ModuleFs, 6007);

                /// <summary>Error code: 2002-6030; Range: 6030-6059; Inner value: 0x2f1c02</summary>
                public static Result.Base InvalidPathForOperation { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6030, 6059); }
                    /// <summary>Error code: 2002-6031; Inner value: 0x2f1e02</summary>
                    public static Result.Base DirectoryUndeletable => new(ModuleFs, 6031);
                    /// <summary>Error code: 2002-6032; Inner value: 0x2f2002</summary>
                    public static Result.Base DirectoryUnrenamable => new(ModuleFs, 6032);
                    /// <summary>Error code: 2002-6033; Inner value: 0x2f2202</summary>
                    public static Result.Base IncompatiblePath => new(ModuleFs, 6033);
                    /// <summary>Error code: 2002-6034; Inner value: 0x2f2402</summary>
                    public static Result.Base RenameToOtherFileSystem => new(ModuleFs, 6034);

                /// <summary>Error code: 2002-6061; Inner value: 0x2f5a02</summary>
                public static Result.Base InvalidOffset => new(ModuleFs, 6061);
                /// <summary>Error code: 2002-6062; Inner value: 0x2f5c02</summary>
                public static Result.Base InvalidSize => new(ModuleFs, 6062);
                /// <summary>Error code: 2002-6063; Inner value: 0x2f5e02</summary>
                public static Result.Base NullptrArgument => new(ModuleFs, 6063);
                /// <summary>Error code: 2002-6064; Inner value: 0x2f6002</summary>
                public static Result.Base InvalidAlignment => new(ModuleFs, 6064);
                /// <summary>Error code: 2002-6065; Inner value: 0x2f6202</summary>
                public static Result.Base InvalidMountName => new(ModuleFs, 6065);
                /// <summary>Error code: 2002-6066; Inner value: 0x2f6402</summary>
                public static Result.Base ExtensionSizeTooLarge => new(ModuleFs, 6066);
                /// <summary>Error code: 2002-6067; Inner value: 0x2f6602</summary>
                public static Result.Base ExtensionSizeInvalid => new(ModuleFs, 6067);
                /// <summary>Error code: 2002-6068; Inner value: 0x2f6802</summary>
                public static Result.Base InvalidHandle => new(ModuleFs, 6068);
                /// <summary>Error code: 2002-6069; Inner value: 0x2f6a02</summary>
                public static Result.Base CacheStorageSizeTooLarge => new(ModuleFs, 6069);
                /// <summary>Error code: 2002-6070; Inner value: 0x2f6c02</summary>
                public static Result.Base CacheStorageIndexTooLarge => new(ModuleFs, 6070);
                /// <summary>Up to 10 file systems can be committed at the same time.<br/>Error code: 2002-6071; Inner value: 0x2f6e02</summary>
                public static Result.Base InvalidCommitNameCount => new(ModuleFs, 6071);
                /// <summary>Error code: 2002-6072; Inner value: 0x2f7002</summary>
                public static Result.Base InvalidModeForFileOpen => new(ModuleFs, 6072);
                /// <summary>Error code: 2002-6073; Inner value: 0x2f7202</summary>
                public static Result.Base InvalidFileSize => new(ModuleFs, 6073);
                /// <summary>Error code: 2002-6074; Inner value: 0x2f7402</summary>
                public static Result.Base InvalidModeForDirectoryOpen => new(ModuleFs, 6074);
                /// <summary>Error code: 2002-6075; Inner value: 0x2f7602</summary>
                public static Result.Base InvalidCommitOption => new(ModuleFs, 6075);

                /// <summary>Error code: 2002-6080; Range: 6080-6099; Inner value: 0x2f8002</summary>
                public static Result.Base InvalidEnumValue { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6080, 6099); }
                    /// <summary>Error code: 2002-6081; Inner value: 0x2f8202</summary>
                    public static Result.Base InvalidSaveDataState => new(ModuleFs, 6081);
                    /// <summary>Error code: 2002-6082; Inner value: 0x2f8402</summary>
                    public static Result.Base InvalidSaveDataSpaceId => new(ModuleFs, 6082);

                /// <summary>Error code: 2002-6101; Inner value: 0x2faa02</summary>
                public static Result.Base GameCardLogoDataTooLarge => new(ModuleFs, 6101);
                /// <summary>Error code: 2002-6102; Inner value: 0x2fac02</summary>
                public static Result.Base FileDataCacheMemorySizeTooSmall => new(ModuleFs, 6102);

            /// <summary>Error code: 2002-6200; Range: 6200-6299; Inner value: 0x307002</summary>
            public static Result.Base InvalidOperationForOpenMode { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6200, 6299); }
                /// <summary>Error code: 2002-6201; Inner value: 0x307202</summary>
                public static Result.Base FileExtensionWithoutOpenModeAllowAppend => new(ModuleFs, 6201);
                /// <summary>Error code: 2002-6202; Inner value: 0x307402</summary>
                public static Result.Base ReadUnpermitted => new(ModuleFs, 6202);
                /// <summary>Error code: 2002-6203; Inner value: 0x307602</summary>
                public static Result.Base WriteUnpermitted => new(ModuleFs, 6203);

            /// <summary>Error code: 2002-6300; Range: 6300-6399; Inner value: 0x313802</summary>
            public static Result.Base UnsupportedOperation { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6300, 6399); }
                /// <summary>Error code: 2002-6301; Inner value: 0x313a02</summary>
                public static Result.Base UnsupportedCommitTarget => new(ModuleFs, 6301);
                /// <summary>Attempted to resize a non-resizable SubStorage.<br/>Error code: 2002-6302; Inner value: 0x313c02</summary>
                public static Result.Base UnsupportedSetSizeForNotResizableSubStorage => new(ModuleFs, 6302);
                /// <summary>Attempted to resize a SubStorage that wasn't located at the end of the base storage.<br/>Error code: 2002-6303; Inner value: 0x313e02</summary>
                public static Result.Base UnsupportedSetSizeForResizableSubStorage => new(ModuleFs, 6303);
                /// <summary>Error code: 2002-6304; Inner value: 0x314002</summary>
                public static Result.Base UnsupportedSetSizeForMemoryStorage => new(ModuleFs, 6304);
                /// <summary>Error code: 2002-6305; Inner value: 0x314202</summary>
                public static Result.Base UnsupportedOperateRangeForMemoryStorage => new(ModuleFs, 6305);
                /// <summary>Error code: 2002-6306; Inner value: 0x314402</summary>
                public static Result.Base UnsupportedOperateRangeForFileStorage => new(ModuleFs, 6306);
                /// <summary>Error code: 2002-6307; Inner value: 0x314602</summary>
                public static Result.Base UnsupportedOperateRangeForFileHandleStorage => new(ModuleFs, 6307);
                /// <summary>Error code: 2002-6308; Inner value: 0x314802</summary>
                public static Result.Base UnsupportedOperateRangeForSwitchStorage => new(ModuleFs, 6308);
                /// <summary>Error code: 2002-6309; Inner value: 0x314a02</summary>
                public static Result.Base UnsupportedOperateRangeForStorageServiceObjectAdapter => new(ModuleFs, 6309);
                /// <summary>Error code: 2002-6310; Inner value: 0x314c02</summary>
                public static Result.Base UnsupportedWriteForAesCtrCounterExtendedStorage => new(ModuleFs, 6310);
                /// <summary>Error code: 2002-6311; Inner value: 0x314e02</summary>
                public static Result.Base UnsupportedSetSizeForAesCtrCounterExtendedStorage => new(ModuleFs, 6311);
                /// <summary>Error code: 2002-6312; Inner value: 0x315002</summary>
                public static Result.Base UnsupportedOperateRangeForAesCtrCounterExtendedStorage => new(ModuleFs, 6312);
                /// <summary>Error code: 2002-6313; Inner value: 0x315202</summary>
                public static Result.Base UnsupportedWriteForAesCtrStorageExternal => new(ModuleFs, 6313);
                /// <summary>Error code: 2002-6314; Inner value: 0x315402</summary>
                public static Result.Base UnsupportedSetSizeForAesCtrStorageExternal => new(ModuleFs, 6314);
                /// <summary>Error code: 2002-6315; Inner value: 0x315602</summary>
                public static Result.Base UnsupportedSetSizeForAesCtrStorage => new(ModuleFs, 6315);
                /// <summary>Error code: 2002-6316; Inner value: 0x315802</summary>
                public static Result.Base UnsupportedSetSizeForHierarchicalIntegrityVerificationStorage => new(ModuleFs, 6316);
                /// <summary>Error code: 2002-6317; Inner value: 0x315a02</summary>
                public static Result.Base UnsupportedOperateRangeForHierarchicalIntegrityVerificationStorage => new(ModuleFs, 6317);
                /// <summary>Error code: 2002-6318; Inner value: 0x315c02</summary>
                public static Result.Base UnsupportedSetSizeForIntegrityVerificationStorage => new(ModuleFs, 6318);
                /// <summary>Error code: 2002-6319; Inner value: 0x315e02</summary>
                public static Result.Base UnsupportedOperateRangeForWritableIntegrityVerificationStorage => new(ModuleFs, 6319);
                /// <summary>Error code: 2002-6320; Inner value: 0x316002</summary>
                public static Result.Base UnsupportedOperateRangeForIntegrityVerificationStorage => new(ModuleFs, 6320);
                /// <summary>Error code: 2002-6321; Inner value: 0x316202</summary>
                public static Result.Base UnsupportedSetSizeForBlockCacheBufferedStorage => new(ModuleFs, 6321);
                /// <summary>Error code: 2002-6322; Inner value: 0x316402</summary>
                public static Result.Base UnsupportedOperateRangeForWritableBlockCacheBufferedStorage => new(ModuleFs, 6322);
                /// <summary>Error code: 2002-6323; Inner value: 0x316602</summary>
                public static Result.Base UnsupportedOperateRangeForBlockCacheBufferedStorage => new(ModuleFs, 6323);
                /// <summary>Error code: 2002-6324; Inner value: 0x316802</summary>
                public static Result.Base UnsupportedWriteForIndirectStorage => new(ModuleFs, 6324);
                /// <summary>Error code: 2002-6325; Inner value: 0x316a02</summary>
                public static Result.Base UnsupportedSetSizeForIndirectStorage => new(ModuleFs, 6325);
                /// <summary>Error code: 2002-6326; Inner value: 0x316c02</summary>
                public static Result.Base UnsupportedOperateRangeForIndirectStorage => new(ModuleFs, 6326);
                /// <summary>Error code: 2002-6327; Inner value: 0x316e02</summary>
                public static Result.Base UnsupportedWriteForZeroStorage => new(ModuleFs, 6327);
                /// <summary>Error code: 2002-6328; Inner value: 0x317002</summary>
                public static Result.Base UnsupportedSetSizeForZeroStorage => new(ModuleFs, 6328);
                /// <summary>Error code: 2002-6329; Inner value: 0x317202</summary>
                public static Result.Base UnsupportedSetSizeForHierarchicalSha256Storage => new(ModuleFs, 6329);
                /// <summary>Error code: 2002-6330; Inner value: 0x317402</summary>
                public static Result.Base UnsupportedWriteForReadOnlyBlockCacheStorage => new(ModuleFs, 6330);
                /// <summary>Error code: 2002-6331; Inner value: 0x317602</summary>
                public static Result.Base UnsupportedSetSizeForReadOnlyBlockCacheStorage => new(ModuleFs, 6331);
                /// <summary>Error code: 2002-6332; Inner value: 0x317802</summary>
                public static Result.Base UnsupportedSetSizeForIntegrityRomFsStorage => new(ModuleFs, 6332);
                /// <summary>Error code: 2002-6333; Inner value: 0x317a02</summary>
                public static Result.Base UnsupportedSetSizeForDuplexStorage => new(ModuleFs, 6333);
                /// <summary>Error code: 2002-6334; Inner value: 0x317c02</summary>
                public static Result.Base UnsupportedOperateRangeForDuplexStorage => new(ModuleFs, 6334);
                /// <summary>Error code: 2002-6335; Inner value: 0x317e02</summary>
                public static Result.Base UnsupportedSetSizeForHierarchicalDuplexStorage => new(ModuleFs, 6335);
                /// <summary>Error code: 2002-6336; Inner value: 0x318002</summary>
                public static Result.Base UnsupportedGetSizeForRemapStorage => new(ModuleFs, 6336);
                /// <summary>Error code: 2002-6337; Inner value: 0x318202</summary>
                public static Result.Base UnsupportedSetSizeForRemapStorage => new(ModuleFs, 6337);
                /// <summary>Error code: 2002-6338; Inner value: 0x318402</summary>
                public static Result.Base UnsupportedOperateRangeForRemapStorage => new(ModuleFs, 6338);
                /// <summary>Error code: 2002-6339; Inner value: 0x318602</summary>
                public static Result.Base UnsupportedSetSizeForIntegritySaveDataStorage => new(ModuleFs, 6339);
                /// <summary>Error code: 2002-6340; Inner value: 0x318802</summary>
                public static Result.Base UnsupportedOperateRangeForIntegritySaveDataStorage => new(ModuleFs, 6340);
                /// <summary>Error code: 2002-6341; Inner value: 0x318a02</summary>
                public static Result.Base UnsupportedSetSizeForJournalIntegritySaveDataStorage => new(ModuleFs, 6341);
                /// <summary>Error code: 2002-6342; Inner value: 0x318c02</summary>
                public static Result.Base UnsupportedOperateRangeForJournalIntegritySaveDataStorage => new(ModuleFs, 6342);
                /// <summary>Error code: 2002-6343; Inner value: 0x318e02</summary>
                public static Result.Base UnsupportedGetSizeForJournalStorage => new(ModuleFs, 6343);
                /// <summary>Error code: 2002-6344; Inner value: 0x319002</summary>
                public static Result.Base UnsupportedSetSizeForJournalStorage => new(ModuleFs, 6344);
                /// <summary>Error code: 2002-6345; Inner value: 0x319202</summary>
                public static Result.Base UnsupportedOperateRangeForJournalStorage => new(ModuleFs, 6345);
                /// <summary>Error code: 2002-6346; Inner value: 0x319402</summary>
                public static Result.Base UnsupportedSetSizeForUnionStorage => new(ModuleFs, 6346);
                /// <summary>Error code: 2002-6347; Inner value: 0x319602</summary>
                public static Result.Base UnsupportedSetSizeForAllocationTableStorage => new(ModuleFs, 6347);
                /// <summary>Error code: 2002-6348; Inner value: 0x319802</summary>
                public static Result.Base UnsupportedReadForWriteOnlyGameCardStorage => new(ModuleFs, 6348);
                /// <summary>Error code: 2002-6349; Inner value: 0x319a02</summary>
                public static Result.Base UnsupportedSetSizeForWriteOnlyGameCardStorage => new(ModuleFs, 6349);
                /// <summary>Error code: 2002-6350; Inner value: 0x319c02</summary>
                public static Result.Base UnsupportedWriteForReadOnlyGameCardStorage => new(ModuleFs, 6350);
                /// <summary>Error code: 2002-6351; Inner value: 0x319e02</summary>
                public static Result.Base UnsupportedSetSizeForReadOnlyGameCardStorage => new(ModuleFs, 6351);
                /// <summary>Error code: 2002-6352; Inner value: 0x31a002</summary>
                public static Result.Base UnsupportedOperateRangeForReadOnlyGameCardStorage => new(ModuleFs, 6352);
                /// <summary>Error code: 2002-6353; Inner value: 0x31a202</summary>
                public static Result.Base UnsupportedSetSizeForSdmmcStorage => new(ModuleFs, 6353);
                /// <summary>Error code: 2002-6354; Inner value: 0x31a402</summary>
                public static Result.Base UnsupportedOperateRangeForSdmmcStorage => new(ModuleFs, 6354);
                /// <summary>Error code: 2002-6355; Inner value: 0x31a602</summary>
                public static Result.Base UnsupportedOperateRangeForFatFile => new(ModuleFs, 6355);
                /// <summary>Error code: 2002-6356; Inner value: 0x31a802</summary>
                public static Result.Base UnsupportedOperateRangeForStorageFile => new(ModuleFs, 6356);
                /// <summary>Error code: 2002-6357; Inner value: 0x31aa02</summary>
                public static Result.Base UnsupportedSetSizeForInternalStorageConcatenationFile => new(ModuleFs, 6357);
                /// <summary>Error code: 2002-6358; Inner value: 0x31ac02</summary>
                public static Result.Base UnsupportedOperateRangeForInternalStorageConcatenationFile => new(ModuleFs, 6358);
                /// <summary>Error code: 2002-6359; Inner value: 0x31ae02</summary>
                public static Result.Base UnsupportedQueryEntryForConcatenationFileSystem => new(ModuleFs, 6359);
                /// <summary>Error code: 2002-6360; Inner value: 0x31b002</summary>
                public static Result.Base UnsupportedOperateRangeForConcatenationFile => new(ModuleFs, 6360);
                /// <summary>Error code: 2002-6361; Inner value: 0x31b202</summary>
                public static Result.Base UnsupportedSetSizeForZeroBitmapFile => new(ModuleFs, 6361);
                /// <summary>Called OperateRange with an invalid operation ID.<br/>Error code: 2002-6362; Inner value: 0x31b402</summary>
                public static Result.Base UnsupportedOperateRangeForFileServiceObjectAdapter => new(ModuleFs, 6362);
                /// <summary>Error code: 2002-6363; Inner value: 0x31b602</summary>
                public static Result.Base UnsupportedOperateRangeForAesXtsFile => new(ModuleFs, 6363);
                /// <summary>Error code: 2002-6364; Inner value: 0x31b802</summary>
                public static Result.Base UnsupportedWriteForRomFsFileSystem => new(ModuleFs, 6364);
                /// <summary>Called RomFsFileSystem::CommitProvisionally.<br/>Error code: 2002-6365; Inner value: 0x31ba02</summary>
                public static Result.Base UnsupportedCommitProvisionallyForRomFsFileSystem => new(ModuleFs, 6365);
                /// <summary>Error code: 2002-6366; Inner value: 0x31bc02</summary>
                public static Result.Base UnsupportedGetTotalSpaceSizeForRomFsFileSystem => new(ModuleFs, 6366);
                /// <summary>Error code: 2002-6367; Inner value: 0x31be02</summary>
                public static Result.Base UnsupportedWriteForRomFsFile => new(ModuleFs, 6367);
                /// <summary>Error code: 2002-6368; Inner value: 0x31c002</summary>
                public static Result.Base UnsupportedOperateRangeForRomFsFile => new(ModuleFs, 6368);
                /// <summary>Error code: 2002-6369; Inner value: 0x31c202</summary>
                public static Result.Base UnsupportedWriteForReadOnlyFileSystem => new(ModuleFs, 6369);
                /// <summary>Error code: 2002-6370; Inner value: 0x31c402</summary>
                public static Result.Base UnsupportedCommitProvisionallyForReadOnlyFileSystem => new(ModuleFs, 6370);
                /// <summary>Error code: 2002-6371; Inner value: 0x31c602</summary>
                public static Result.Base UnsupportedGetTotalSpaceSizeForReadOnlyFileSystem => new(ModuleFs, 6371);
                /// <summary>Error code: 2002-6372; Inner value: 0x31c802</summary>
                public static Result.Base UnsupportedWriteForReadOnlyFile => new(ModuleFs, 6372);
                /// <summary>Error code: 2002-6373; Inner value: 0x31ca02</summary>
                public static Result.Base UnsupportedOperateRangeForReadOnlyFile => new(ModuleFs, 6373);
                /// <summary>Error code: 2002-6374; Inner value: 0x31cc02</summary>
                public static Result.Base UnsupportedWriteForPartitionFileSystem => new(ModuleFs, 6374);
                /// <summary>Called PartitionFileSystemCore::CommitProvisionally.<br/>Error code: 2002-6375; Inner value: 0x31ce02</summary>
                public static Result.Base UnsupportedCommitProvisionallyForPartitionFileSystem => new(ModuleFs, 6375);
                /// <summary>Error code: 2002-6376; Inner value: 0x31d002</summary>
                public static Result.Base UnsupportedWriteForPartitionFile => new(ModuleFs, 6376);
                /// <summary>Error code: 2002-6377; Inner value: 0x31d202</summary>
                public static Result.Base UnsupportedOperateRangeForPartitionFile => new(ModuleFs, 6377);
                /// <summary>Error code: 2002-6378; Inner value: 0x31d402</summary>
                public static Result.Base UnsupportedOperateRangeForTmFileSystemFile => new(ModuleFs, 6378);
                /// <summary>Error code: 2002-6379; Inner value: 0x31d602</summary>
                public static Result.Base UnsupportedWriteForSaveDataInternalStorageFileSystem => new(ModuleFs, 6379);
                /// <summary>Error code: 2002-6382; Inner value: 0x31dc02</summary>
                public static Result.Base UnsupportedCommitProvisionallyForApplicationTemporaryFileSystem => new(ModuleFs, 6382);
                /// <summary>Error code: 2002-6383; Inner value: 0x31de02</summary>
                public static Result.Base UnsupportedCommitProvisionallyForSaveDataFileSystem => new(ModuleFs, 6383);
                /// <summary>Called DirectorySaveDataFileSystem::CommitProvisionally on a non-user savedata.<br/>Error code: 2002-6384; Inner value: 0x31e002</summary>
                public static Result.Base UnsupportedCommitProvisionallyForDirectorySaveDataFileSystem => new(ModuleFs, 6384);
                /// <summary>Error code: 2002-6385; Inner value: 0x31e202</summary>
                public static Result.Base UnsupportedWriteForZeroBitmapHashStorageFile => new(ModuleFs, 6385);
                /// <summary>Error code: 2002-6386; Inner value: 0x31e402</summary>
                public static Result.Base UnsupportedSetSizeForZeroBitmapHashStorageFile => new(ModuleFs, 6386);
                /// <summary>Error code: 2002-6387; Inner value: 0x31e602</summary>
                public static Result.Base UnsupportedWriteForCompressedStorage => new(ModuleFs, 6387);
                /// <summary>Error code: 2002-6388; Inner value: 0x31e802</summary>
                public static Result.Base UnsupportedOperateRangeForCompressedStorage => new(ModuleFs, 6388);
                /// <summary>Error code: 2002-6395; Inner value: 0x31f602</summary>
                public static Result.Base UnsupportedRollbackOnlyModifiedForApplicationTemporaryFileSystem => new(ModuleFs, 6395);
                /// <summary>Error code: 2002-6396; Inner value: 0x31f802</summary>
                public static Result.Base UnsupportedRollbackOnlyModifiedForDirectorySaveDataFileSystem => new(ModuleFs, 6396);
                /// <summary>Error code: 2002-6397; Inner value: 0x31fa02</summary>
                public static Result.Base UnsupportedOperateRangeForRegionSwitchStorage => new(ModuleFs, 6397);
                /// <summary>Error code: 2002-6398; Inner value: 0x31fc02</summary>
                public static Result.Base UnsupportedOperateRangeForSaveDataFile => new(ModuleFs, 6398);
                /// <summary>Error code: 2002-6399; Inner value: 0x31fe02</summary>
                public static Result.Base UnsupportedOperateRangeForApplicationTemporaryFile => new(ModuleFs, 6399);

            /// <summary>Error code: 2002-6400; Range: 6400-6449; Inner value: 0x320002</summary>
            public static Result.Base PermissionDenied { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6400, 6449); }
                /// <summary>Returned when opening a host FS on a retail device.<br/>Error code: 2002-6403; Inner value: 0x320602</summary>
                public static Result.Base HostFileSystemOperationDisabled => new(ModuleFs, 6403);

            /// <summary>Error code: 2002-6450; Inner value: 0x326402</summary>
            public static Result.Base PortAcceptableCountLimited => new(ModuleFs, 6450);
            /// <summary>Error code: 2002-6452; Inner value: 0x326802</summary>
            public static Result.Base NcaExternalKeyInconsistent => new(ModuleFs, 6452);
            /// <summary>Error code: 2002-6454; Inner value: 0x326c02</summary>
            public static Result.Base NeedFlush => new(ModuleFs, 6454);
            /// <summary>Error code: 2002-6455; Inner value: 0x326e02</summary>
            public static Result.Base FileNotClosed => new(ModuleFs, 6455);
            /// <summary>Error code: 2002-6456; Inner value: 0x327002</summary>
            public static Result.Base DirectoryNotClosed => new(ModuleFs, 6456);
            /// <summary>Error code: 2002-6457; Inner value: 0x327202</summary>
            public static Result.Base WriteModeFileNotClosed => new(ModuleFs, 6457);
            /// <summary>Error code: 2002-6458; Inner value: 0x327402</summary>
            public static Result.Base AllocatorAlreadyRegistered => new(ModuleFs, 6458);
            /// <summary>Error code: 2002-6459; Inner value: 0x327602</summary>
            public static Result.Base DefaultAllocatorAlreadyUsed => new(ModuleFs, 6459);
            /// <summary>Error code: 2002-6460; Inner value: 0x327802</summary>
            public static Result.Base GameCardLogoDataSizeInvalid => new(ModuleFs, 6460);
            /// <summary>Error code: 2002-6461; Inner value: 0x327a02</summary>
            public static Result.Base AllocatorAlignmentViolation => new(ModuleFs, 6461);
            /// <summary>Error code: 2002-6462; Inner value: 0x327c02</summary>
            public static Result.Base GlobalFileDataCacheAlreadyEnabled => new(ModuleFs, 6462);
            /// <summary>The provided file system has already been added to the multi-commit manager.<br/>Error code: 2002-6463; Inner value: 0x327e02</summary>
            public static Result.Base MultiCommitFileSystemDuplicated => new(ModuleFs, 6463);
            /// <summary>A multi-commit was performed while another multi-commit operation was already running.<br/>Error code: 2002-6464; Inner value: 0x328002</summary>
            public static Result.Base SaveDataMultiCommitRepeated => new(ModuleFs, 6464);
            /// <summary>Error code: 2002-6465; Inner value: 0x328202</summary>
            public static Result.Base UserNotExist => new(ModuleFs, 6465);
            /// <summary>Error code: 2002-6466; Inner value: 0x328402</summary>
            public static Result.Base DefaultGlobalFileDataCacheEnabled => new(ModuleFs, 6466);
            /// <summary>Error code: 2002-6467; Inner value: 0x328602</summary>
            public static Result.Base SaveDataRootPathUnavailable => new(ModuleFs, 6467);
            /// <summary>Error code: 2002-6470; Inner value: 0x328c02</summary>
            public static Result.Base RomMountDivisionSizeUnitCountLimit => new(ModuleFs, 6470);
            /// <summary>Error code: 2002-6471; Inner value: 0x328e02</summary>
            public static Result.Base RomMountCountLimit => new(ModuleFs, 6471);
            /// <summary>Error code: 2002-6472; Inner value: 0x329002</summary>
            public static Result.Base AocMountDivisionSizeUnitCountLimit => new(ModuleFs, 6472);

        /// <summary>Error code: 2002-6600; Range: 6600-6699; Inner value: 0x339002</summary>
        public static Result.Base NotFound { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6600, 6699); }
            /// <summary>Error code: 2002-6602; Inner value: 0x339402</summary>
            public static Result.Base FileNotFound => new(ModuleFs, 6602);
            /// <summary>Error code: 2002-6603; Inner value: 0x339602</summary>
            public static Result.Base DirectoryNotFound => new(ModuleFs, 6603);
            /// <summary>Error code: 2002-6604; Inner value: 0x339802</summary>
            public static Result.Base DatabaseKeyNotFound => new(ModuleFs, 6604);
            /// <summary>Specified program is not found in the program registry.<br/>Error code: 2002-6605; Inner value: 0x339a02</summary>
            public static Result.Base ProgramInfoNotFound => new(ModuleFs, 6605);
            /// <summary>Specified program index is not found<br/>Error code: 2002-6606; Inner value: 0x339c02</summary>
            public static Result.Base ProgramIndexNotFound => new(ModuleFs, 6606);

        /// <summary>Error code: 2002-6700; Range: 6700-6799; Inner value: 0x345802</summary>
        public static Result.Base OutOfResource { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6700, 6799); }
            /// <summary>Error code: 2002-6705; Inner value: 0x346202</summary>
            public static Result.Base BufferAllocationFailed => new(ModuleFs, 6705);
            /// <summary>Error code: 2002-6706; Inner value: 0x346402</summary>
            public static Result.Base MappingTableFull => new(ModuleFs, 6706);
            /// <summary>Error code: 2002-6707; Inner value: 0x346602</summary>
            public static Result.Base AllocationTableFull => new(ModuleFs, 6707);
            /// <summary>Error code: 2002-6709; Inner value: 0x346a02</summary>
            public static Result.Base OpenCountLimit => new(ModuleFs, 6709);
            /// <summary>The maximum number of file systems have been added to the multi-commit manager.<br/>Error code: 2002-6710; Inner value: 0x346c02</summary>
            public static Result.Base MultiCommitFileSystemLimit => new(ModuleFs, 6710);

        /// <summary>Error code: 2002-6800; Range: 6800-6899; Inner value: 0x352002</summary>
        public static Result.Base MappingFailed { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6800, 6899); }
            /// <summary>Error code: 2002-6811; Inner value: 0x353602</summary>
            public static Result.Base MapFull => new(ModuleFs, 6811);

        /// <summary>Error code: 2002-6900; Range: 6900-6999; Inner value: 0x35e802</summary>
        public static Result.Base BadState { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 6900, 6999); }
            /// <summary>Error code: 2002-6902; Inner value: 0x35ec02</summary>
            public static Result.Base NotInitialized => new(ModuleFs, 6902);
            /// <summary>Error code: 2002-6903; Inner value: 0x35ee02</summary>
            public static Result.Base BisProxyInvalidated => new(ModuleFs, 6903);
            /// <summary>Error code: 2002-6904; Inner value: 0x35f002</summary>
            public static Result.Base NcaDigestInconsistent => new(ModuleFs, 6904);
            /// <summary>Error code: 2002-6905; Inner value: 0x35f202</summary>
            public static Result.Base NotMounted => new(ModuleFs, 6905);
            /// <summary>Error code: 2002-6906; Inner value: 0x35f402</summary>
            public static Result.Base SaveDataExtending => new(ModuleFs, 6906);
            /// <summary>Error code: 2002-6907; Inner value: 0x35f602</summary>
            public static Result.Base SaveDataToExpandIsProvisionallyCommitted => new(ModuleFs, 6907);

        /// <summary>Error code: 2002-7002; Inner value: 0x36b402</summary>
        public static Result.Base SaveDataTransferV2KeySeedPackageMacVerificationFailed => new(ModuleFs, 7002);
        /// <summary>Error code: 2002-7003; Inner value: 0x36b602</summary>
        public static Result.Base SaveDataTransferV2KeySeedPackageSignatureVerificationFailed => new(ModuleFs, 7003);
        /// <summary>Error code: 2002-7004; Inner value: 0x36b802</summary>
        public static Result.Base SaveDataTransferV2KeySeedPackageChallengeVerificationFailed => new(ModuleFs, 7004);
        /// <summary>Error code: 2002-7005; Inner value: 0x36ba02</summary>
        public static Result.Base SaveDataTransferV2ImportDataVerificationFailed => new(ModuleFs, 7005);
        /// <summary>Error code: 2002-7006; Inner value: 0x36bc02</summary>
        public static Result.Base SaveDataTransferV2InitialDataGcmMacVerificationFailed => new(ModuleFs, 7006);
        /// <summary>Error code: 2002-7009; Inner value: 0x36c202</summary>
        public static Result.Base SaveDataTransferV2InitialDataMacVerificationFailed => new(ModuleFs, 7009);
        /// <summary>Error code: 2002-7010; Inner value: 0x36c402</summary>
        public static Result.Base SaveDataTransferV2ImportDataDecompressionFailed => new(ModuleFs, 7010);
        /// <summary>Error code: 2002-7011; Inner value: 0x36c602</summary>
        public static Result.Base SaveDataTransferV2PortContextMacVerificationFailed => new(ModuleFs, 7011);
        /// <summary>Error code: 2002-7031; Inner value: 0x36ee02</summary>
        public static Result.Base SaveDataPorterInvalidated => new(ModuleFs, 7031);
        /// <summary>Error code: 2002-7032; Inner value: 0x36f002</summary>
        public static Result.Base SaveDataDivisionExporterChunkExportIncomplete => new(ModuleFs, 7032);
        /// <summary>Error code: 2002-7033; Inner value: 0x36f202</summary>
        public static Result.Base SaveDataDivisionImporterChunkImportIncomplete => new(ModuleFs, 7033);
        /// <summary>Error code: 2002-7034; Inner value: 0x36f402</summary>
        public static Result.Base SaveDataPorterInitialDataVersionVerificationFailed => new(ModuleFs, 7034);
        /// <summary>Error code: 2002-7035; Inner value: 0x36f602</summary>
        public static Result.Base SaveDataChunkDecryptorGcmStreamVersionVerificationFailed => new(ModuleFs, 7035);
        /// <summary>The save data being ported has been modified since the importer/exporter was created.<br/>Error code: 2002-7036; Inner value: 0x36f802</summary>
        public static Result.Base SaveDataPorterSaveDataModified => new(ModuleFs, 7036);
        /// <summary>The key generation or the version of the initial data or key package is too high.<br/>Error code: 2002-7037; Inner value: 0x36fa02</summary>
        public static Result.Base SaveDataPorterVersionUnsupported => new(ModuleFs, 7037);
        /// <summary>Error code: 2002-7038; Inner value: 0x36fc02</summary>
        public static Result.Base SaveDataTransferV2SecondarySaveCorrupted => new(ModuleFs, 7038);
        /// <summary>Error code: 2002-7062; Inner value: 0x372c02</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairKeyPackageMacVerificationFailed => new(ModuleFs, 7062);
        /// <summary>Error code: 2002-7063; Inner value: 0x372e02</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairKeyPackageSignatureVerificationFailed => new(ModuleFs, 7063);
        /// <summary>Error code: 2002-7064; Inner value: 0x373002</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairKeyPackageChallengeVerificationFailed => new(ModuleFs, 7064);
        /// <summary>Error code: 2002-7065; Inner value: 0x373202</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairUnsupportedKeyGeneration => new(ModuleFs, 7065);
        /// <summary>Error code: 2002-7066; Inner value: 0x373402</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairInitialDataMacVerificationFailed => new(ModuleFs, 7066);
        /// <summary>The initial data doesn't match the set key package.<br/>Error code: 2002-7069; Inner value: 0x373a02</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairIncorrectInitialData => new(ModuleFs, 7069);
        /// <summary>The before and after initial data refer to different saves.<br/>Error code: 2002-7070; Inner value: 0x373c02</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairInconsistentInitialData => new(ModuleFs, 7070);
        /// <summary>The initial data doesn't match the given user ID.<br/>Error code: 2002-7071; Inner value: 0x373e02</summary>
        public static Result.Base SaveDataTransferForSaveDataRepairInitialDataIncorrectUserId => new(ModuleFs, 7071);

        /// <summary>Error code: 2002-7100; Range: 7100-7139; Inner value: 0x377802</summary>
        public static Result.Base RamDiskCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 7100, 7139); }
            /// <summary>Error code: 2002-7101; Inner value: 0x377a02</summary>
            public static Result.Base RamDiskVerifiedStorageVerificationFailed => new(ModuleFs, 7101);

            /// <summary>Error code: 2002-7111; Range: 7111-7119; Inner value: 0x378e02</summary>
            public static Result.Base RamDiskSaveDataCoreFileSystemCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 7111, 7119); }
                /// <summary>Error code: 2002-7112; Inner value: 0x379002</summary>
                public static Result.Base IncorrectRamDiskSaveDataFileSystemMagicCode => new(ModuleFs, 7112);
                /// <summary>Error code: 2002-7113; Inner value: 0x379202</summary>
                public static Result.Base InvalidRamDiskSaveDataFileReadOffset => new(ModuleFs, 7113);
                /// <summary>Error code: 2002-7114; Inner value: 0x379402</summary>
                public static Result.Base InvalidRamDiskSaveDataCoreDataStorageSize => new(ModuleFs, 7114);

            /// <summary>Error code: 2002-7121; Range: 7121-7129; Inner value: 0x37a202</summary>
            public static Result.Base RamDiskDatabaseCorrupted { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 7121, 7129); }
                /// <summary>Error code: 2002-7122; Inner value: 0x37a402</summary>
                public static Result.Base InvalidRamDiskAllocationTableBlock => new(ModuleFs, 7122);
                /// <summary>Error code: 2002-7123; Inner value: 0x37a602</summary>
                public static Result.Base InvalidRamDiskKeyValueListElementIndex => new(ModuleFs, 7123);
                /// <summary>Error code: 2002-7124; Inner value: 0x37a802</summary>
                public static Result.Base InvalidRamDiskAllocationTableChainEntry => new(ModuleFs, 7124);
                /// <summary>Error code: 2002-7125; Inner value: 0x37aa02</summary>
                public static Result.Base InvalidRamDiskAllocationTableOffset => new(ModuleFs, 7125);
                /// <summary>Error code: 2002-7126; Inner value: 0x37ac02</summary>
                public static Result.Base InvalidRamDiskAllocationTableBlockCount => new(ModuleFs, 7126);
                /// <summary>Error code: 2002-7127; Inner value: 0x37ae02</summary>
                public static Result.Base InvalidRamDiskKeyValueListEntryIndex => new(ModuleFs, 7127);

        /// <summary>Error code: 2002-7142; Inner value: 0x37cc02</summary>
        public static Result.Base SaveDataTransferForRepairInitialDataMacVerificationFailed => new(ModuleFs, 7142);
        /// <summary>Error code: 2002-7900; Inner value: 0x3db802</summary>
        public static Result.Base Unknown => new(ModuleFs, 7900);

        /// <summary>Error code: 2002-7901; Range: 7901-7904; Inner value: 0x3dba02</summary>
        public static Result.Base DbmNotFound { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 7901, 7904); }
            /// <summary>Error code: 2002-7902; Inner value: 0x3dbc02</summary>
            public static Result.Base DbmKeyNotFound => new(ModuleFs, 7902);
            /// <summary>Error code: 2002-7903; Inner value: 0x3dbe02</summary>
            public static Result.Base DbmFileNotFound => new(ModuleFs, 7903);
            /// <summary>Error code: 2002-7904; Inner value: 0x3dc002</summary>
            public static Result.Base DbmDirectoryNotFound => new(ModuleFs, 7904);

        /// <summary>Error code: 2002-7906; Inner value: 0x3dc402</summary>
        public static Result.Base DbmAlreadyExists => new(ModuleFs, 7906);
        /// <summary>Error code: 2002-7907; Inner value: 0x3dc602</summary>
        public static Result.Base DbmKeyFull => new(ModuleFs, 7907);
        /// <summary>Error code: 2002-7908; Inner value: 0x3dc802</summary>
        public static Result.Base DbmDirectoryEntryFull => new(ModuleFs, 7908);
        /// <summary>Error code: 2002-7909; Inner value: 0x3dca02</summary>
        public static Result.Base DbmFileEntryFull => new(ModuleFs, 7909);

        /// <summary>Error code: 2002-7910; Range: 7910-7912; Inner value: 0x3dcc02</summary>
        public static Result.Base DbmFindFinished { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new(ModuleFs, 7910, 7912); }
            /// <summary>Error code: 2002-7911; Inner value: 0x3dce02</summary>
            public static Result.Base DbmFindKeyFinished => new(ModuleFs, 7911);
            /// <summary>Error code: 2002-7912; Inner value: 0x3dd002</summary>
            public static Result.Base DbmIterationFinished => new(ModuleFs, 7912);

        /// <summary>Error code: 2002-7914; Inner value: 0x3dd402</summary>
        public static Result.Base DbmInvalidOperation => new(ModuleFs, 7914);
        /// <summary>Error code: 2002-7915; Inner value: 0x3dd602</summary>
        public static Result.Base DbmInvalidPathFormat => new(ModuleFs, 7915);
        /// <summary>Error code: 2002-7916; Inner value: 0x3dd802</summary>
        public static Result.Base DbmDirectoryNameTooLong => new(ModuleFs, 7916);
        /// <summary>Error code: 2002-7917; Inner value: 0x3dda02</summary>
        public static Result.Base DbmFileNameTooLong => new(ModuleFs, 7917);
}