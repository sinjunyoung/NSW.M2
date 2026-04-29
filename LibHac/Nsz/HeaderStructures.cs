using LibHac.Tools.FsSystem.NcaUtils;
using System.Runtime.InteropServices;

namespace LibHac.NSZ;

/// <summary>
/// The raw structure of an NCZ section header
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NczSectionRaw
{
    public long Offset;

    public long Size;

    public long CryptoType;

    public long Padding;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] CryptoKey;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] CryptoCounter;
}

/// <summary>
/// A section specify the way to decrypt a portion of the decompressed stream, starting at <see cref="Offset"/>
/// </summary>
public class NczSection(NczSectionRaw sectionRaw)
{

    /// <summary>
    /// The offset relative to the beginning of the NCA (including NCA header)
    /// </summary>
    public long Offset => sectionRaw.Offset;

    /// <summary>
    /// The size covered by this section
    /// </summary>
    public long Size => sectionRaw.Size;

    /// <summary>
    /// The encryption type to use to recover the original NCA file
    /// </summary>
    public NcaEncryptionType CryptoType => (NcaEncryptionType)sectionRaw.CryptoType;

    /// <summary>
    /// The padding
    /// </summary>
    public long Padding => sectionRaw.Padding;

    /// <summary>
    /// The encryption key
    /// </summary>
    public byte[] CryptoKey => sectionRaw.CryptoKey;

    /// <summary>
    /// The encryption counter when encryption is <see cref="NcaEncryptionType.AesCtr"/> or <see cref="NcaEncryptionType.AesCtrEx"/> 
    /// </summary>
    public byte[] CryptoCounter => sectionRaw.CryptoCounter;

    /// <summary>
    /// Returns true if specified NCA position fall in this section
    /// </summary>
    /// <param name="ncaOffset"></param>
    /// <returns></returns>
    public bool ContainsOffset(long ncaOffset)
    {
        return ncaOffset >= Offset && ncaOffset < (Offset + Size);
    }

    public override string ToString()
    {
        return $"Section [{Offset}-{Offset + Size - 1}] (Crypto={CryptoType})";
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct NczBlockCompressionHeaderRaw
{

    public byte Version;

    public byte Type;

    public byte Unused;

    public byte BlockSizeExponent;

    public int NumberOfBlocks;

    public long DecompressedSize;

}

/// <summary>
/// Header containing information about NCZ block compression 
/// </summary>
public class NczBlockCompressionHeader(NczBlockCompressionHeaderRaw nczBlockCompressionHeaderRaw, int[] compressedBlockSizes)
{

    /// <summary>
    /// The NCZ version
    /// </summary>
    public byte Version => nczBlockCompressionHeaderRaw.Version;

    /// <summary>
    /// 
    /// </summary>
    public byte Type => nczBlockCompressionHeaderRaw.Type;

    /// <summary>
    /// The decompressed block size in exponent of 2
    /// </summary>
    public byte BlockSizeExponent => nczBlockCompressionHeaderRaw.BlockSizeExponent;

    /// <summary>
    /// The total decompressed size (does not include NCA header)
    /// </summary>
    public long DecompressedSize => nczBlockCompressionHeaderRaw.DecompressedSize;

    /// <summary>
    /// The array of compressed blocks sizes.
    /// </summary>
    public int[] CompressedBlockSizes { get; } = compressedBlockSizes;
}