using LibHac.Common.FixedArrays;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.FsSystem;
using LibHac.Tools.FsSystem;
using LibHac.Tools.FsSystem.NcaUtils;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZstdSharp;
using ZstdSharp.Unsafe;

namespace LibHac.NSZ;

public class NcaToNczConverter(KeySet keySet)
{
    private const long HeaderSize = 0x4000;
    private const int ChunkSize = 0x400000;

    private const string StreamingSectionMagic = "NCZSECTN";
    private const string BlockSectionMagic = "NCZBLOCK";

    public const int DefaultBlockSizeExponent = 20;

    private byte[]? _originalHash;

    public void Convert(Stream ncaStream, Stream outputStream, int compressionLevel = 18, bool multiThread = true, Action<long>? onRead = null, CancellationToken ct = default)
    {
        _originalHash = null;

        ncaStream.Position = 0;
        var nca = new Nca(keySet, new StreamStorage(ncaStream, leaveOpen: true));

        byte[] rawHeader = new byte[HeaderSize];
        ncaStream.Position = 0;
        ncaStream.ReadExactly(rawHeader, 0, (int)HeaderSize);
        outputStream.Write(rawHeader);

        var sections = CollectSections(nca);
        if (sections.Count == 0)
            throw new InvalidDataException("No compressible sections found. Please check your prod.keys file.");

        WriteSectionTable(outputStream, sections, StreamingSectionMagic);

        using IStorage decryptedStorage = nca.OpenDecryptedNca();
        decryptedStorage.GetSize(out long ncaSize).ThrowIfFailure();

        using var sha256 = System.Security.Cryptography.SHA256.Create();

        int maxDegreeOfParallelism = multiThread ? Environment.ProcessorCount : 1;
        using var semaphore = new SemaphoreSlim(maxDegreeOfParallelism);
        var tasks = new List<Task<byte[]>>();

        try
        {
            long readPos = HeaderSize;

            while (readPos < ncaSize)
            {
                ct.ThrowIfCancellationRequested();

                int toRead = (int)Math.Min(ChunkSize, ncaSize - readPos);
                byte[] inBuf = new byte[toRead];

                decryptedStorage.Read(readPos, inBuf.AsSpan(0, toRead)).ThrowIfFailure();
                sha256.TransformBlock(inBuf, 0, toRead, null, 0);

                semaphore.Wait(ct);
                var task = Task.Run(() =>
                {
                    try
                    {
                        using var compressor = BuildCompressor(compressionLevel, false);
                        return compressor.Wrap(inBuf).ToArray();
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }, ct);

                tasks.Add(task);
                readPos += toRead;
                onRead?.Invoke(toRead);

                if (tasks.Count >= maxDegreeOfParallelism * 2)
                {
                    FlushTasks(tasks, outputStream);
                    tasks.Clear();
                }
            }

            FlushTasks(tasks, outputStream);
        }
        finally
        {
        }

        sha256.TransformFinalBlock([], 0, 0);
        _originalHash = sha256.Hash;
    }

    private static void FlushTasks(List<Task<byte[]>> tasks, Stream output)
    {
        try
        {
            foreach (var t in tasks)
            {
                byte[] result = t.GetAwaiter().GetResult();
                output.Write(result);
            }
        }
        finally
        {
            foreach (var t in tasks)
                t.Wait();
        }
    }

    public void Verify(Stream nczStream, long totalVerifySize, ref long currentVerifyPos, string label, IProgress<(int pct, string label)>? progress, CancellationToken ct)
    {
        if (_originalHash == null)
            throw new InvalidOperationException("Convert must be called first.");

        var ncz = new Ncz(keySet, nczStream, NczReadMode.Original);
        using IStorage decrypted = ncz.OpenDecryptedNca();
        decrypted.GetSize(out long decSize).ThrowIfFailure();

        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var reportSw = System.Diagnostics.Stopwatch.StartNew();

        int prefetchCount = 10;
        var dataQueue = new System.Collections.Concurrent.BlockingCollection<byte[]>(prefetchCount);

        var readTask = Task.Run(() =>
        {
            try
            {
                long readPos = HeaderSize;
                while (readPos < decSize)
                {
                    if (ct.IsCancellationRequested) break;

                    int toRead = (int)Math.Min(ChunkSize, decSize - readPos);
                    byte[] buf = new byte[toRead];
                    decrypted.Read(readPos, buf.AsSpan()).ThrowIfFailure();

                    dataQueue.Add(buf, ct);
                    readPos += toRead;
                }
            }
            finally
            {
                dataQueue.CompleteAdding();
            }
        }, ct);

        try
        {
            foreach (var data in dataQueue.GetConsumingEnumerable(ct))
            {
                sha256.TransformBlock(data, 0, data.Length, null, 0);

                currentVerifyPos += data.Length;

                if (reportSw.ElapsedMilliseconds >= 100)
                {
                    int pct = totalVerifySize > 0
                        ? (int)Math.Min(100, currentVerifyPos * 100 / totalVerifySize)
                        : 0;

                    var r = NSW.Utils.Common.CalculateProgress(currentVerifyPos, totalVerifySize, label);
                    progress?.Report((pct, $"Decompressing and hashing... {r.label}"));
                    reportSw.Restart();
                }
            }

            readTask.Wait(ct);
        }
        catch (OperationCanceledException) { /* 취소 처리 */ }
        finally
        {
            dataQueue.Dispose();
        }

        sha256.TransformFinalBlock([], 0, 0);

        if (!sha256.Hash.SequenceEqual(_originalHash))
            throw new InvalidDataException($"{label} verification failed: hash mismatch");
    }

    private static void WriteSectionTable(Stream output, List<NczSectionRaw> sections, string magic)
    {
        output.Write(Encoding.ASCII.GetBytes(magic));
        output.Write(BitConverter.GetBytes((long)sections.Count));

        foreach (var s in sections)
        {
            output.Write(BitConverter.GetBytes(s.Offset));
            output.Write(BitConverter.GetBytes(s.Size));
            output.Write(BitConverter.GetBytes(s.CryptoType));
            output.Write(new byte[8]);
            output.Write(s.CryptoKey);
            output.Write(s.CryptoCounter);
        }
    }

    private static Compressor BuildCompressor(int compressionLevel, bool multiThread)
    {
        var compressor = new Compressor(compressionLevel);

        if (compressionLevel <= 3)
        {
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_enableLongDistanceMatching, 0);
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_windowLog, 20);
        }
        else if (compressionLevel <= 12)
        {
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_enableLongDistanceMatching, 0);
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_windowLog, 20);
        }
        else
        {
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_enableLongDistanceMatching, 0);
            compressor.SetParameter(ZSTD_cParameter.ZSTD_c_windowLog, 20);
        }

        compressor.SetParameter(ZSTD_cParameter.ZSTD_c_nbWorkers, 0);
        return compressor;
    }

    private static List<NczSectionRaw> CollectSections(Nca nca)
    {
        var result = new List<NczSectionRaw>();

        for (int i = 0; i < 4; i++)
        {
            if (!nca.SectionExists(i)) continue;

            var fsHeader = nca.GetFsHeader(i);
            long sectionOffset = nca.Header.GetSectionStartOffset(i);
            long sectionSize = nca.Header.GetSectionSize(i);

            if (fsHeader.EncryptionType == NcaEncryptionType.AesCtrEx)
            {
                var extStorage = nca.OpenAesCtrCounterExtendedStorage(i);
                if (extStorage == null) continue;

                extStorage.ReadAllEntries(out var entries).ThrowIfFailure();
                byte[] key = extStorage.GetKey().ToArray();
                uint secureValue = extStorage.GetSecureValue();

                for (int e = 0; e < entries.Length; e++)
                {
                    var entry = entries[e];
                    long entryOffset = sectionOffset + entry.GetOffset();
                    long entryEnd = e + 1 < entries.Length
                        ? sectionOffset + entries[e + 1].GetOffset()
                        : sectionOffset + sectionSize;

                    var section = new NczSectionRaw
                    {
                        Offset = entryOffset,
                        Size = entryEnd - entryOffset,
                        CryptoType = entry.EncryptionValue == AesCtrCounterExtendedStorage.Entry.Encryption.Encrypted
                            ? (long)NcaEncryptionType.AesCtr
                            : (long)NcaEncryptionType.None,
                        CryptoKey = new byte[16],
                        CryptoCounter = new byte[16]
                    };

                    if (entry.EncryptionValue == AesCtrCounterExtendedStorage.Entry.Encryption.Encrypted)
                    {
                        NcaAesCtrUpperIv upperIv = new() { Generation = (uint)entry.Generation, SecureValue = secureValue };
                        Unsafe.SkipInit(out Array16<byte> counter);
                        AesCtrStorage.MakeIv(counter, upperIv.Value, 0);

                        key.CopyTo(section.CryptoKey.AsSpan());
                        counter[..].CopyTo(section.CryptoCounter.AsSpan());
                    }
                    result.Add(section);
                }
                continue;
            }

            var s = new NczSectionRaw
            {
                Offset = sectionOffset,
                Size = sectionSize,
                CryptoType = (long)fsHeader.EncryptionType,
                CryptoKey = new byte[16],
                CryptoCounter = new byte[16]
            };

            if (fsHeader.EncryptionType == NcaEncryptionType.AesCtr)
            {
                nca.GetContentKey(NcaKeyType.AesCtr).CopyTo(s.CryptoKey.AsSpan());
                ulong upperIv = fsHeader.Counter;
                byte[] counterBytes = BitConverter.GetBytes(upperIv);
                if (BitConverter.IsLittleEndian) Array.Reverse(counterBytes);
                counterBytes.CopyTo(s.CryptoCounter, 0);
            }

            result.Add(s);
        }

        result.Sort((a, b) => a.Offset.CompareTo(b.Offset));

        if (result.Count > 0 && result[0].Offset < HeaderSize)
        {
            long overlap = HeaderSize - result[0].Offset;
            var first = result[0];
            first.Offset = HeaderSize;
            first.Size -= overlap;

            if (first.Size <= 0)
                result.RemoveAt(0);
            else
                result[0] = first;
        }

        return result;
    }
}