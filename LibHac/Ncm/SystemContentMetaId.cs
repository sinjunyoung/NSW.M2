namespace LibHac.Ncm;

public readonly struct SystemProgramId
{
    public readonly ulong Value;

    public SystemProgramId(ulong value)
    {
        Value = value;
    }

    public static implicit operator ProgramId(SystemProgramId id) => new(id.Value);

    public static bool IsSystemProgramId(ProgramId programId)
    {
        return Start <= programId && programId <= End;
    }

    public static bool IsSystemProgramId(SystemProgramId id) => true;

    public static SystemProgramId Start => new(0x0100000000000000);

    public static SystemProgramId Fs => new(0x0100000000000000);
    public static SystemProgramId Loader => new(0x0100000000000001);
    public static SystemProgramId Ncm => new(0x0100000000000002);
    public static SystemProgramId Pm => new(0x0100000000000003);
    public static SystemProgramId Sm => new(0x0100000000000004);
    public static SystemProgramId Boot => new(0x0100000000000005);
    public static SystemProgramId Usb => new(0x0100000000000006);
    public static SystemProgramId Tma => new(0x0100000000000007);
    public static SystemProgramId Boot2 => new(0x0100000000000008);
    public static SystemProgramId Settings => new(0x0100000000000009);
    public static SystemProgramId Bus => new(0x010000000000000A);
    public static SystemProgramId Bluetooth => new(0x010000000000000B);
    public static SystemProgramId Bcat => new(0x010000000000000C);
    public static SystemProgramId Dmnt => new(0x010000000000000D);
    public static SystemProgramId Friends => new(0x010000000000000E);
    public static SystemProgramId Nifm => new(0x010000000000000F);
    public static SystemProgramId Ptm => new(0x0100000000000010);
    public static SystemProgramId Shell => new(0x0100000000000011);
    public static SystemProgramId BsdSockets => new(0x0100000000000012);
    public static SystemProgramId Hid => new(0x0100000000000013);
    public static SystemProgramId Audio => new(0x0100000000000014);
    public static SystemProgramId LogManager => new(0x0100000000000015);
    public static SystemProgramId Wlan => new(0x0100000000000016);
    public static SystemProgramId Cs => new(0x0100000000000017);
    public static SystemProgramId Ldn => new(0x0100000000000018);
    public static SystemProgramId NvServices => new(0x0100000000000019);
    public static SystemProgramId Pcv => new(0x010000000000001A);
    public static SystemProgramId Ppc => new(0x010000000000001B);
    public static SystemProgramId NvnFlinger => new(0x010000000000001C);
    public static SystemProgramId Pcie => new(0x010000000000001D);
    public static SystemProgramId Account => new(0x010000000000001E);
    public static SystemProgramId Ns => new(0x010000000000001F);
    public static SystemProgramId Nfc => new(0x0100000000000020);
    public static SystemProgramId Psc => new(0x0100000000000021);
    public static SystemProgramId CapSrv => new(0x0100000000000022);
    public static SystemProgramId Am => new(0x0100000000000023);
    public static SystemProgramId Ssl => new(0x0100000000000024);
    public static SystemProgramId Nim => new(0x0100000000000025);
    public static SystemProgramId Cec => new(0x0100000000000026);
    public static SystemProgramId Tspm => new(0x0100000000000027);
    public static SystemProgramId Spl => new(0x0100000000000028);
    public static SystemProgramId Lbl => new(0x0100000000000029);
    public static SystemProgramId Btm => new(0x010000000000002A);
    public static SystemProgramId Erpt => new(0x010000000000002B);
    public static SystemProgramId Time => new(0x010000000000002C);
    public static SystemProgramId Vi => new(0x010000000000002D);
    public static SystemProgramId Pctl => new(0x010000000000002E);
    public static SystemProgramId Npns => new(0x010000000000002F);
    public static SystemProgramId Eupld => new(0x0100000000000030);
    public static SystemProgramId Arp => new(0x0100000000000031);
    public static SystemProgramId Glue => new(0x0100000000000031);
    public static SystemProgramId Eclct => new(0x0100000000000032);
    public static SystemProgramId Es => new(0x0100000000000033);
    public static SystemProgramId Fatal => new(0x0100000000000034);
    public static SystemProgramId Grc => new(0x0100000000000035);
    public static SystemProgramId Creport => new(0x0100000000000036);
    public static SystemProgramId Ro => new(0x0100000000000037);
    public static SystemProgramId Profiler => new(0x0100000000000038);
    public static SystemProgramId Sdb => new(0x0100000000000039);
    public static SystemProgramId Migration => new(0x010000000000003A);
    public static SystemProgramId Jit => new(0x010000000000003B);
    public static SystemProgramId JpegDec => new(0x010000000000003C);
    public static SystemProgramId SafeMode => new(0x010000000000003D);
    public static SystemProgramId Olsc => new(0x010000000000003E);
    public static SystemProgramId Dt => new(0x010000000000003F);
    public static SystemProgramId Nd => new(0x0100000000000040);
    public static SystemProgramId Ngct => new(0x0100000000000041);
    public static SystemProgramId Pgl => new(0x0100000000000042);

    public static SystemProgramId End => new(0x01000000000007FF);
}

public readonly struct SystemDataId
{
    public readonly ulong Value;

    public SystemDataId(ulong value)
    {
        Value = value;
    }

    public static implicit operator DataId(SystemDataId id) => new(id.Value);

    public static bool IsSystemDataId(DataId dataId)
    {
        return Start <= dataId && dataId <= End;
    }

    public static bool IsSystemDataId(SystemDataId id) => true;

    public static SystemDataId Start => new(0x0100000000000800);

    public static SystemDataId CertStore => new(0x0100000000000800);
    public static SystemDataId ErrorMessage => new(0x0100000000000801);
    public static SystemDataId MiiModel => new(0x0100000000000802);
    public static SystemDataId BrowserDll => new(0x0100000000000803);
    public static SystemDataId Help => new(0x0100000000000804);
    public static SystemDataId SharedFont => new(0x0100000000000805);
    public static SystemDataId NgWord => new(0x0100000000000806);
    public static SystemDataId SsidList => new(0x0100000000000807);
    public static SystemDataId Dictionary => new(0x0100000000000808);
    public static SystemDataId SystemVersion => new(0x0100000000000809);
    public static SystemDataId AvatarImage => new(0x010000000000080A);
    public static SystemDataId LocalNews => new(0x010000000000080B);
    public static SystemDataId Eula => new(0x010000000000080C);
    public static SystemDataId UrlBlackList => new(0x010000000000080D);
    public static SystemDataId TimeZoneBinar => new(0x010000000000080E);
    public static SystemDataId CertStoreCruiser => new(0x010000000000080F);
    public static SystemDataId FontNintendoExtension => new(0x0100000000000810);
    public static SystemDataId FontStandard => new(0x0100000000000811);
    public static SystemDataId FontKorean => new(0x0100000000000812);
    public static SystemDataId FontChineseTraditional => new(0x0100000000000813);
    public static SystemDataId FontChineseSimple => new(0x0100000000000814);
    public static SystemDataId FontBfcpx => new(0x0100000000000815);
    public static SystemDataId SystemUpdate => new(0x0100000000000816);

    public static SystemDataId FirmwareDebugSettings => new(0x0100000000000818);
    public static SystemDataId BootImagePackage => new(0x0100000000000819);
    public static SystemDataId BootImagePackageSafe => new(0x010000000000081A);
    public static SystemDataId BootImagePackageExFat => new(0x010000000000081B);
    public static SystemDataId BootImagePackageExFatSafe => new(0x010000000000081C);
    public static SystemDataId FatalMessage => new(0x010000000000081D);
    public static SystemDataId ControllerIcon => new(0x010000000000081E);
    public static SystemDataId PlatformConfigIcosa => new(0x010000000000081F);
    public static SystemDataId PlatformConfigCopper => new(0x0100000000000820);
    public static SystemDataId PlatformConfigHoag => new(0x0100000000000821);
    public static SystemDataId ControllerFirmware => new(0x0100000000000822);
    public static SystemDataId NgWord2 => new(0x0100000000000823);
    public static SystemDataId PlatformConfigIcosaMariko => new(0x0100000000000824);
    public static SystemDataId ApplicationBlackList => new(0x0100000000000825);
    public static SystemDataId RebootlessSystemUpdateVersion => new(0x0100000000000826);
    public static SystemDataId ContentActionTable => new(0x0100000000000827);

    public static SystemDataId End => new(0x0100000000000FFF);
}

public readonly struct SystemUpdateId
{
    public readonly ulong Value;

    public SystemUpdateId(ulong value)
    {
        Value = value;
    }

    public static implicit operator DataId(SystemUpdateId id) => new(id.Value);
}

public readonly struct SystemAppletId
{
    public readonly ulong Value;

    public SystemAppletId(ulong value)
    {
        Value = value;
    }

    public static implicit operator ProgramId(SystemAppletId id) => new(id.Value);

    public static bool IsSystemAppletId(ProgramId programId)
    {
        return Start <= programId && programId <= End;
    }

    public static bool IsSystemAppletId(SystemAppletId id) => true;

    public static SystemAppletId Start => new(0x0100000000001000);

    public static SystemAppletId Qlaunch => new(0x0100000000001000);
    public static SystemAppletId Auth => new(0x0100000000001001);
    public static SystemAppletId Cabinet => new(0x0100000000001002);
    public static SystemAppletId Controller => new(0x0100000000001003);
    public static SystemAppletId DataErase => new(0x0100000000001004);
    public static SystemAppletId Error => new(0x0100000000001005);
    public static SystemAppletId NetConnect => new(0x0100000000001006);
    public static SystemAppletId PlayerSelect => new(0x0100000000001007);
    public static SystemAppletId Swkbd => new(0x0100000000001008);
    public static SystemAppletId MiiEdit => new(0x0100000000001009);
    public static SystemAppletId Web => new(0x010000000000100A);
    public static SystemAppletId Shop => new(0x010000000000100B);
    public static SystemAppletId OverlayDisp => new(0x010000000000100C);
    public static SystemAppletId PhotoViewer => new(0x010000000000100D);
    public static SystemAppletId Set => new(0x010000000000100E);
    public static SystemAppletId OfflineWeb => new(0x010000000000100F);
    public static SystemAppletId LoginShare => new(0x0100000000001010);
    public static SystemAppletId WifiWebAuth => new(0x0100000000001011);
    public static SystemAppletId Starter => new(0x0100000000001012);
    public static SystemAppletId MyPage => new(0x0100000000001013);
    public static SystemAppletId PlayReport => new(0x0100000000001014);
    public static SystemAppletId MaintenanceMenu => new(0x0100000000001015);

    public static SystemAppletId Gift => new(0x010000000000101A);
    public static SystemAppletId DummyShop => new(0x010000000000101B);
    public static SystemAppletId UserMigration => new(0x010000000000101C);
    public static SystemAppletId Encounter => new(0x010000000000101D);

    public static SystemAppletId Story => new(0x0100000000001020);

    public static SystemAppletId End => new(0x0100000000001FFF);
}

public readonly struct SystemDebugAppletId
{
    public readonly ulong Value;

    public SystemDebugAppletId(ulong value)
    {
        Value = value;
    }

    public static implicit operator ProgramId(SystemDebugAppletId id) => new(id.Value);

    public static bool IsSystemDebugAppletId(ProgramId programId)
    {
        return Start <= programId && programId <= End;
    }

    public static bool IsSystemDebugAppletId(SystemDebugAppletId id) => true;

    public static SystemDebugAppletId Start => new(0x0100000000002000);

    public static SystemDebugAppletId SnapShotDumper => new(0x0100000000002071);

    public static SystemDebugAppletId End => new(0x0100000000002FFF);
}

public readonly struct LibraryAppletId
{
    public readonly ulong Value;

    public LibraryAppletId(ulong value)
    {
        Value = value;
    }

    public static implicit operator SystemAppletId(LibraryAppletId id) => new(id.Value);
    public static implicit operator ProgramId(LibraryAppletId id) => new(id.Value);

    public static bool IsLibraryAppletId(ProgramId programId)
    {
        return programId == Auth ||
               programId == Controller ||
               programId == Error ||
               programId == PlayerSelect ||
               programId == Swkbd ||
               programId == Web ||
               programId == Shop ||
               programId == PhotoViewer ||
               programId == OfflineWeb ||
               programId == LoginShare ||
               programId == WifiWebAuth ||
               programId == MyPage;
    }

    public static bool IsLibraryAppletId(LibraryAppletId id) => true;

    public static LibraryAppletId Auth => new(SystemAppletId.Auth.Value);
    public static LibraryAppletId Controller => new(SystemAppletId.Controller.Value);
    public static LibraryAppletId Error => new(SystemAppletId.Error.Value);
    public static LibraryAppletId PlayerSelect => new(SystemAppletId.PlayerSelect.Value);
    public static LibraryAppletId Swkbd => new(SystemAppletId.Swkbd.Value);
    public static LibraryAppletId Web => new(SystemAppletId.Web.Value);
    public static LibraryAppletId Shop => new(SystemAppletId.Shop.Value);
    public static LibraryAppletId PhotoViewer => new(SystemAppletId.PhotoViewer.Value);
    public static LibraryAppletId OfflineWeb => new(SystemAppletId.OfflineWeb.Value);
    public static LibraryAppletId LoginShare => new(SystemAppletId.LoginShare.Value);
    public static LibraryAppletId WifiWebAuth => new(SystemAppletId.WifiWebAuth.Value);
    public static LibraryAppletId MyPage => new(SystemAppletId.MyPage.Value);
}

public readonly struct WebAppletId
{
    public readonly ulong Value;

    public WebAppletId(ulong value)
    {
        Value = value;
    }

    public static implicit operator LibraryAppletId(WebAppletId id) => new(id.Value);
    public static implicit operator SystemAppletId(WebAppletId id) => new(id.Value);
    public static implicit operator ProgramId(WebAppletId id) => new(id.Value);

    public static bool IsWebAppletId(ProgramId programId)
    {
        return programId == Web ||
               programId == Shop ||
               programId == OfflineWeb ||
               programId == LoginShare ||
               programId == WifiWebAuth;
    }

    public static bool IsWebAppletId(WebAppletId id) => true;

    public static WebAppletId Web => new(LibraryAppletId.Web.Value);
    public static WebAppletId Shop => new(LibraryAppletId.Shop.Value);
    public static WebAppletId OfflineWeb => new(LibraryAppletId.OfflineWeb.Value);
    public static WebAppletId LoginShare => new(LibraryAppletId.LoginShare.Value);
    public static WebAppletId WifiWebAuth => new(LibraryAppletId.WifiWebAuth.Value);
}

public readonly struct SystemApplicationId
{
    public readonly ulong Value;

    public SystemApplicationId(ulong value)
    {
        Value = value;
    }

    public static implicit operator ProgramId(SystemApplicationId id) => new(id.Value);
}