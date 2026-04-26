using LibHac.NSZ.Utils;
using System;
using System.IO;

namespace LibHac.NSZ.Streams;


/// <summary>
/// Stream in charge of restoring the original NCA encryption from the decompression stream.
/// </summary>
public class NcaEncryptionStream : Stream
{
    private readonly Stream _nczDecompressionStream;
    private readonly NczSectionsEncryptionHelper _nczSectionsEncryptionHelper;


    /// <summary>
    /// </summary>
    /// <param name="nczHeader"></param>
    /// <param name="nczDecompressionStream">The stream in charge of decompressing the NCZ compressed part (which excludes untouched 0x4000 NCZ header)</param>
    /// <exception cref="ArgumentNullException"></exception>
    public NcaEncryptionStream(NczHeader nczHeader, Stream nczDecompressionStream)
    {
        nczHeader = nczHeader ?? throw new ArgumentNullException(nameof(nczHeader));
        _nczDecompressionStream = nczDecompressionStream ?? throw new ArgumentNullException(nameof(nczDecompressionStream));
        _nczSectionsEncryptionHelper = new NczSectionsEncryptionHelper(nczHeader.Sections);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _nczDecompressionStream?.Dispose();
    }

    public override void Flush()
    {
    }

    /// <summary>
    /// 프린세스 메이커 2, Ultra Street Fighter II 버그 대응 수정
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    /// <exception cref="NczFormatException"></exception>
    public override int Read(byte[] buffer, int offset, int count)
    {
        var ncaOffset = NczHeader.INCOMPRESSIBLE_HEADER_SIZE + _nczDecompressionStream.Position;

        var nbDecompressedBytes = _nczDecompressionStream.Read(buffer, offset, count);

        if (nbDecompressedBytes == 0) return 0;

        var subSpan = buffer.AsSpan(offset, nbDecompressedBytes);

        var nbBytesRecovered = _nczSectionsEncryptionHelper.Recover(ncaOffset, subSpan);

        if (nbDecompressedBytes != nbBytesRecovered)
            throw new NczFormatException("The number of decompressed bytes doesn't match the number of recovered bytes.");

        return nbBytesRecovered;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
        throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException();
    }

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => _nczDecompressionStream.Length;

    public override long Position
    {
        get => _nczDecompressionStream.Position;
        set => _nczDecompressionStream.Position = value;
    }
}