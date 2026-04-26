using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZstdSharp;

namespace LibHac.NSZ;


public class NczSection2
{
    public long Offset;
    public long Size;
    public long CryptoType;
    public byte[] CryptoKey = new byte[16];
    public byte[] CryptoCounter = new byte[16];
}

public static class NcaToNczConverter
{
    private const int HeaderSize = 0x4000;

    public static void Convert(Stream ncaStream, Stream outputStream, KeySet keySet, int compressionLevel = 18, byte blockSizeExponent = 17)
    {
        if (blockSizeExponent < 14 || blockSizeExponent > 32)
            throw new ArgumentOutOfRangeException(nameof(blockSizeExponent), "블록 크기 지수는 14~32 이어야 합니다.");

        long ncaSize = ncaStream.Length;
        if (ncaSize <= HeaderSize)
            throw new InvalidDataException("NCA 파일이 너무 작습니다.");

        ncaStream.Position = 0;
        var nca = new Nca(keySet, new StreamStorage(ncaStream, leaveOpen: true));

        byte[] rawHeader = new byte[HeaderSize];
        ncaStream.Position = 0;
        ncaStream.ReadExactly(rawHeader, 0, HeaderSize);
        outputStream.Write(rawHeader);

        var sections = CollectSections(nca, rawHeader);
        if (sections.Count == 0)
            throw new InvalidDataException("압축 가능한 섹션이 없습니다. 키가 올바른지 확인하세요.");

        outputStream.Write(Encoding.ASCII.GetBytes("NCZSECTN"));
        outputStream.Write(BitConverter.GetBytes((long)sections.Count));
        foreach (var s in sections)
        {
            outputStream.Write(BitConverter.GetBytes(s.Offset));
            outputStream.Write(BitConverter.GetBytes(s.Size));
            outputStream.Write(BitConverter.GetBytes(s.CryptoType));
            outputStream.Write(new byte[8]);         // padding
            outputStream.Write(s.CryptoKey);         // 16 bytes
            outputStream.Write(s.CryptoCounter);     // 16 bytes
        }

        int blockSize = 1 << blockSizeExponent;
        long bytesToCompress = ncaSize - HeaderSize;
        int blockCount = (int)((bytesToCompress + blockSize - 1) / blockSize);

        outputStream.Write(Encoding.ASCII.GetBytes("NCZBLOCK"));
        outputStream.Write([2, 1, 0, blockSizeExponent]);
        outputStream.Write(BitConverter.GetBytes(blockCount));
        outputStream.Write(BitConverter.GetBytes(bytesToCompress));

        long blockTablePos = outputStream.Position;
        outputStream.Write(new byte[blockCount * 4]);

        var blockSizes = CompressBlocks(nca, ncaSize, outputStream, compressionLevel, blockSize, blockCount);

        long endPos = outputStream.Position;
        outputStream.Position = blockTablePos;
        foreach (var size in blockSizes)
            outputStream.Write(BitConverter.GetBytes(size));
        outputStream.Position = endPos;
        outputStream.Flush();
    }

    private static List<NczSection2> CollectSections(Nca nca, byte[] rawHeader)
    {
        var result = new List<NczSection2>();

        for (int i = 0; i < 4; i++)
        {
            if (!nca.CanOpenSection(i)) continue;

            int entryOff = 0x240 + i * 16;
            uint mediaStart = BitConverter.ToUInt32(rawHeader, entryOff);
            uint mediaEnd = BitConverter.ToUInt32(rawHeader, entryOff + 4);
            if (mediaStart == 0 && mediaEnd == 0) continue;

            long sectionOffset = (long)mediaStart * 0x200;
            long sectionSize = (long)(mediaEnd - mediaStart) * 0x200;

            int fsOff = 0x400 + i * 0x200;
            byte encType = rawHeader[fsOff + 0x04];

            var section = new NczSection2
            {
                Offset = sectionOffset,
                Size = sectionSize,
                CryptoType = encType,
            };

            if (encType == 3 || encType == 4)
            {
                try
                {
                    var key = nca.GetDecryptedKey(i);
                    key.CopyTo(section.CryptoKey.AsSpan());
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException(
                        $"섹션 {i} 키 복호화 실패. prod.keys 파일이 올바른지 확인하세요. ({ex.Message})");
                }

                section.CryptoCounter[0] = rawHeader[fsOff + 0x14F];
                section.CryptoCounter[1] = rawHeader[fsOff + 0x14E];
                section.CryptoCounter[2] = rawHeader[fsOff + 0x14D];
                section.CryptoCounter[3] = rawHeader[fsOff + 0x14C];
                section.CryptoCounter[4] = rawHeader[fsOff + 0x14B];
                section.CryptoCounter[5] = rawHeader[fsOff + 0x14A];
                section.CryptoCounter[6] = rawHeader[fsOff + 0x149];
                section.CryptoCounter[7] = rawHeader[fsOff + 0x148];
            }

            result.Add(section);
        }

        return result;
    }


    private static List<int> CompressBlocks(Nca nca, long ncaSize, Stream outputStream, int compressionLevel, int blockSize, int blockCount)
    {
        var blockSizes = new List<int>(blockCount);
        var compressor = new Compressor(compressionLevel);

        IStorage decryptedNca = nca.OpenDecryptedNca();

        byte[] buf = new byte[blockSize];
        long readPos = HeaderSize;

        for (int i = 0; i < blockCount; i++)
        {
            int toRead = (int)Math.Min(blockSize, ncaSize - readPos);
            var span = new Span<byte>(buf, 0, toRead);

            decryptedNca.Read(readPos, span).ThrowIfFailure();
            readPos += toRead;

            byte[] compressed = compressor.Wrap(span).ToArray();

            if (compressed.Length >= toRead)
            {
                outputStream.Write(buf, 0, toRead);
                blockSizes.Add(toRead);
            }
            else
            {
                outputStream.Write(compressed);
                blockSizes.Add(compressed.Length);
            }
        }

        return blockSizes;
    }
}