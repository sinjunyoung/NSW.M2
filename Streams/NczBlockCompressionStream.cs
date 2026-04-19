using System;
using System.Collections.Generic;
using System.IO;
using ZstdSharp;

namespace LibHac.NSZ.Streams;

public class NczBlockCompressionStream : Stream
{
    private readonly Stream _baseStream;
    private readonly Compressor _compressor;
    private readonly int _blockSize;
    private readonly List<int> _compressedSizes = new();
    private byte[] _rawBuffer;
    private int _rawBufferOffset;

    public IReadOnlyList<int> CompressedSizes => _compressedSizes;

    public NczBlockCompressionStream(Stream baseStream, int compressionLevel = 3, int blockSize = 0x40000)
    {
        _baseStream = baseStream ?? throw new ArgumentNullException(nameof(baseStream));
        _compressor = new Compressor(compressionLevel);
        _blockSize = blockSize;
        _rawBuffer = new byte[blockSize];
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        int remaining = count;
        int currentOffset = offset;

        while (remaining > 0)
        {
            int toCopy = Math.Min(_blockSize - _rawBufferOffset, remaining);
            Buffer.BlockCopy(buffer, currentOffset, _rawBuffer, _rawBufferOffset, toCopy);

            _rawBufferOffset += toCopy;
            currentOffset += toCopy;
            remaining -= toCopy;

            if (_rawBufferOffset == _blockSize)
            {
                CompressAndWriteBlock();
            }
        }
    }

    private void CompressAndWriteBlock()
    {
        if (_rawBufferOffset == 0) return;

        // Zstd 압축 수행
        ReadOnlySpan<byte> compressed = _compressor.Wrap(_rawBuffer.AsSpan(0, _rawBufferOffset));
        _baseStream.Write(compressed);

        // 압축된 크기 저장
        _compressedSizes.Add(compressed.Length);
        _rawBufferOffset = 0;
    }

    public override void Flush()
    {
        if (_rawBufferOffset > 0)
        {
            CompressAndWriteBlock();
        }
        _baseStream.Flush();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Flush();
            _compressor.Dispose();
        }
        base.Dispose(disposing);
    }

    // Stream 필수 구현 (압축 전용이므로 Read 등은 지원 안 함)
    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override long Length => throw new NotSupportedException();
    public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
    public override void SetLength(long value) => throw new NotSupportedException();
}