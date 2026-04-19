using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using System.IO;
using System.Text;
using ZstdSharp;

namespace LibHac.NSZ;

/// <summary>
/// NCZSECTN에 기록되는 섹션 암호화 메타데이터
/// </summary>
public class NczSection2
{
    public long Offset;                             // NCA 내 절대 오프셋 (바이트)
    public long Size;                               // 섹션 크기 (바이트)
    public long CryptoType;                         // 암호화 타입 (0=None, 3=AES-CTR, 4=AES-CTR-EX)
    public byte[] CryptoKey = new byte[16];     // 복호화된 AES 키
    public byte[] CryptoCounter = new byte[16];     // AES-CTR 초기 카운터
}

public static class NcaToNczConverter
{
    private const int HeaderSize = 0x4000; // NCZ 스펙: 첫 0x4000바이트는 원본 그대로

    /// <summary>
    /// NCA 스트림을 NCZ 블록 압축 포맷으로 변환합니다.
    /// 출력 스트림은 반드시 seek 가능해야 합니다 (블록 테이블 backpatch).
    /// </summary>
    public static void Convert(
        Stream ncaStream,
        Stream outputStream,
        KeySet keySet,
        int compressionLevel = 18,
        byte blockSizeExponent = 17)
    {
        if (blockSizeExponent < 14 || blockSizeExponent > 32)
            throw new ArgumentOutOfRangeException(nameof(blockSizeExponent), "블록 크기 지수는 14~32 이어야 합니다.");

        long ncaSize = ncaStream.Length;
        if (ncaSize <= HeaderSize)
            throw new InvalidDataException("NCA 파일이 너무 작습니다.");

        // NCA 파싱 (헤더 복호화용)
        ncaStream.Position = 0;
        var nca = new Nca(keySet, new StreamStorage(ncaStream, leaveOpen: true));

        // ─── 1. 헤더 0x4000 바이트 원본 그대로 복사 (여전히 암호화 상태) ───────
        byte[] rawHeader = new byte[HeaderSize];
        ncaStream.Position = 0;
        ncaStream.ReadExactly(rawHeader, 0, HeaderSize);
        outputStream.Write(rawHeader);

        // ─── 2. 섹션 정보 수집 ────────────────────────────────────────────────
        var sections = CollectSections(nca, rawHeader);
        if (sections.Count == 0)
            throw new InvalidDataException("압축 가능한 섹션이 없습니다. 키가 올바른지 확인하세요.");

        // ─── 3. NCZSECTN 헤더 ─────────────────────────────────────────────────
        // [magic:8][sectionCount:8] 이후 섹션마다:
        // [offset:8][size:8][cryptoType:8][padding:8][key:16][counter:16] = 56바이트
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

        // ─── 4. NCZBLOCK 헤더 ─────────────────────────────────────────────────
        int blockSize = 1 << blockSizeExponent;
        long bytesToCompress = ncaSize - HeaderSize;
        int blockCount = (int)((bytesToCompress + blockSize - 1) / blockSize);

        // [magic:8][version:1][type:1][unused:1][blockSizeExp:1][blockCount:4][decompressedSize:8]
        // + [compressedBlockSizeList: blockCount * 4] (임시 0, 나중에 backpatch)
        outputStream.Write(Encoding.ASCII.GetBytes("NCZBLOCK"));
        outputStream.Write([2, 1, 0, blockSizeExponent]);
        outputStream.Write(BitConverter.GetBytes(blockCount));
        outputStream.Write(BitConverter.GetBytes(bytesToCompress));

        long blockTablePos = outputStream.Position; // backpatch 위치 기억
        outputStream.Write(new byte[blockCount * 4]);

        // ─── 5. 블록 단위 압축 ────────────────────────────────────────────────
        var blockSizes = CompressBlocks(nca, ncaSize, outputStream, compressionLevel, blockSize, blockCount);

        // ─── 6. 블록 크기 테이블 backpatch ───────────────────────────────────
        long endPos = outputStream.Position;
        outputStream.Position = blockTablePos;
        foreach (var size in blockSizes)
            outputStream.Write(BitConverter.GetBytes(size));
        outputStream.Position = endPos;
        outputStream.Flush();
    }

    // ──────────────────────────────────────────────────────────────────────────

    private static List<NczSection2> CollectSections(Nca nca, byte[] rawHeader)
    {
        var result = new List<NczSection2>();

        for (int i = 0; i < 4; i++)
        {
            if (!nca.CanOpenSection(i)) continue;

            // 섹션 엔트리 파싱 (NCA 헤더 0x240 + i*16)
            // [mediaStartOffset:4][mediaEndOffset:4][unknown:8]
            int entryOff = 0x240 + i * 16;
            uint mediaStart = BitConverter.ToUInt32(rawHeader, entryOff);
            uint mediaEnd = BitConverter.ToUInt32(rawHeader, entryOff + 4);
            if (mediaStart == 0 && mediaEnd == 0) continue;

            long sectionOffset = (long)mediaStart * 0x200;
            long sectionSize = (long)(mediaEnd - mediaStart) * 0x200;

            // FsHeader 파싱 (복호화된 헤더 기준, NCA 헤더 0x400 + i*0x200)
            // [version:2][fsType:1][hashType:1][encryptionType:1][...]
            int fsOff = 0x400 + i * 0x200;
            byte encType = rawHeader[fsOff + 0x04];

            var section = new NczSection2
            {
                Offset = sectionOffset,
                Size = sectionSize,
                CryptoType = encType,
            };

            // AES-CTR(3) 또는 AES-CTR-EX(4) 섹션만 키/카운터 추출
            if (encType == 3 || encType == 4)
            {
                // LibHac GetDecryptedKey(index): 섹션 인덱스에 해당하는 복호화된 키 영역 반환
                // 내부적으로 KeyAreaKey 로 복호화된 16바이트 키
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

                // AES-CTR 카운터 구성:
                // FsHeader + 0x14C: SecureValue (4바이트, big-endian) → counter[0..3]
                // FsHeader + 0x148: Generation   (4바이트, big-endian) → counter[4..7]
                // counter[8..15] = 0 (섹션 내부에서 오프셋에 따라 증가)
                section.CryptoCounter[0] = rawHeader[fsOff + 0x14F];
                section.CryptoCounter[1] = rawHeader[fsOff + 0x14E];
                section.CryptoCounter[2] = rawHeader[fsOff + 0x14D];
                section.CryptoCounter[3] = rawHeader[fsOff + 0x14C];
                section.CryptoCounter[4] = rawHeader[fsOff + 0x14B];
                section.CryptoCounter[5] = rawHeader[fsOff + 0x14A];
                section.CryptoCounter[6] = rawHeader[fsOff + 0x149];
                section.CryptoCounter[7] = rawHeader[fsOff + 0x148];
                // counter[8..15] = 0 (이미 new byte[16]으로 초기화됨)
            }

            result.Add(section);
        }

        return result;
    }

    // ──────────────────────────────────────────────────────────────────────────

    private static List<int> CompressBlocks(
        Nca nca,
        long ncaSize,
        Stream outputStream,
        int compressionLevel,
        int blockSize,
        int blockCount)
    {
        var blockSizes = new List<int>(blockCount);
        var compressor = new Compressor(compressionLevel);

        // OpenDecryptedNca(): 헤더를 포함한 NCA 전체를 복호화된 상태로 제공
        // 이 IStorage에서 0x4000 이후를 읽으면 복호화된 섹션 데이터가 나옴
        IStorage decryptedNca = nca.OpenDecryptedNca();

        byte[] buf = new byte[blockSize];
        long readPos = HeaderSize;

        for (int i = 0; i < blockCount; i++)
        {
            int toRead = (int)Math.Min(blockSize, ncaSize - readPos);
            var span = new Span<byte>(buf, 0, toRead);

            decryptedNca.Read(readPos, span).ThrowIfFailure();
            readPos += toRead;

            // 압축
            byte[] compressed = compressor.Wrap(span).ToArray();

            // NCZ 스펙: CompressedSize >= OriginalSize 이면 비압축으로 저장
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