using System;

namespace LibHac.Common.Keys;

internal static partial class DefaultKeySet
{
    private static ReadOnlySpan<byte> TsecSecrets => Array.Empty<byte>();
    private static ReadOnlySpan<byte> RootKeysDev => Array.Empty<byte>();
    private static ReadOnlySpan<byte> RootKeysProd => Array.Empty<byte>();
    private static ReadOnlySpan<byte> KeySeeds => Array.Empty<byte>();
    private static ReadOnlySpan<byte> StoredKeysDev => Array.Empty<byte>();
    private static ReadOnlySpan<byte> StoredKeysProd => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DerivedKeysDev => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DerivedKeysProd => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DeviceKeys => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DerivedDeviceKeysDev => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DerivedDeviceKeysProd => Array.Empty<byte>();
    private static ReadOnlySpan<byte> RsaSigningKeysDev => Array.Empty<byte>();
    private static ReadOnlySpan<byte> RsaSigningKeysProd => Array.Empty<byte>();
    private static ReadOnlySpan<byte> RsaKeys => Array.Empty<byte>();
    private static ReadOnlySpan<byte> DeviceRsaKeys => Array.Empty<byte>();
}