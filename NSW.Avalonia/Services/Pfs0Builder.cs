using Avalonia.Controls;
using NSW.Avalonia.Models;
using NSW.Core;
using NSW.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace NSW.Avalonia.Services;

public static class Pfs0Builder
{
    private const uint MagicPfs0 = 0x30534650;
    public const int ExefsHashBlockSize = 0x10000;
    public const int LogoHashBlockSize = 0x1000;
    public const int MetaHashBlockSize = 0x1000;
    public const int PaddingSize = 0x200;


    public static void BuildStreaming(string displayName, IEnumerable<(string Name, Action<Stream, Action<long>> Writer, long EstimatedSize, string Label)> files, Stream outputStream, IProgress<(int pct, string label)>? progress = null, CancellationToken ct = default)
    {
        if (!outputStream.CanSeek)
            throw new InvalidOperationException("outputStream must be seekable");

        var fileList = files.ToList();

        var stringTable = new List<byte>();
        var stringOffsets = new List<uint>();
        foreach (var (name, _, _, _) in fileList)
        {
            stringOffsets.Add((uint)stringTable.Count);
            stringTable.AddRange(System.Text.Encoding.UTF8.GetBytes(name));
            stringTable.Add(0);
        }

        ulong fullHeaderSize = (ulong)(Marshal.SizeOf<Pfs0Header>() + Marshal.SizeOf<Pfs0FileEntry>() * fileList.Count + stringTable.Count);
        ulong alignedHeaderSize = AlignUp(fullHeaderSize + 1, 0x20);
        ulong headerPadding = alignedHeaderSize - fullHeaderSize;

        var header = new Pfs0Header
        {
            Magic = MagicPfs0,
            NumFiles = (uint)fileList.Count,
            StringTableSize = (uint)(stringTable.Count + (int)headerPadding)
        };

        WriteStruct(outputStream, header);

        long entryTablePos = outputStream.Position;
        for (int i = 0; i < fileList.Count; i++)
        {
            WriteStruct(outputStream, new Pfs0FileEntry
            {
                Offset = 0,
                Size = 0,
                StringTableOffset = stringOffsets[i]
            });
        }

        outputStream.Write(stringTable.ToArray());
        outputStream.Write(new byte[headerPadding]);

        long totalEstimated = fileList.Sum(f => f.EstimatedSize);
        long totalWritten = 0;
        string currentLabel = "";
        var reportSw = Stopwatch.StartNew();
        var startTime = Stopwatch.GetTimestamp();

        var window = new Queue<(long ts, long written)>();
        const double windowSec = 10.0;

        void onRead(long bytesRead)
        {
            totalWritten += bytesRead;
            if (reportSw.ElapsedMilliseconds >= 100)
            {
                long now = Stopwatch.GetTimestamp();
                window.Enqueue((now, totalWritten));

                double freq = Stopwatch.Frequency;
                while (window.Count > 1 && (now - window.Peek().ts) / freq > windowSec)
                    window.Dequeue();

                double mibPerSec = 0;
                double etaSec = 0;

                if (window.Count >= 2)
                {
                    var (ts, written) = window.Peek();
                    double secSpan = (now - ts) / freq;
                    long bytesSpan = totalWritten - written;

                    double avgSpeed = totalWritten / ((now - startTime) / freq);
                    double windowSpeed = secSpan > 0 ? bytesSpan / secSpan : 0;
                    double progressRatio = totalEstimated > 0 ? (double)totalWritten / totalEstimated : 0;
                    double blendedSpeed = avgSpeed * (1 - progressRatio) + windowSpeed * progressRatio;

                    mibPerSec = blendedSpeed / (1024.0 * 1024.0);
                    etaSec = blendedSpeed > 0 ? (totalEstimated - totalWritten) / blendedSpeed : 0;
                }

                double elapsedSec = (now - startTime) / freq;
                var elapsed = TimeSpan.FromSeconds(elapsedSec);
                var totalEta = TimeSpan.FromSeconds(elapsedSec + Math.Max(0, etaSec));

                int pct = totalEstimated > 0 ? (int)(totalWritten * 100 / totalEstimated) : 0;
                var r = Common.CalculateProgress(totalWritten, totalEstimated, displayName);
                progress?.Report((pct, $"{r.label} | {mibPerSec:F1} MiB/s | {elapsed:mm\\:ss} / {totalEta:mm\\:ss}"));
                reportSw.Restart();
            }
        }

        var actualOffsets = new ulong[fileList.Count];
        var actualSizes = new ulong[fileList.Count];
        ulong relOffset = 0;

        for (int i = 0; i < fileList.Count; i++)
        {
            ct.ThrowIfCancellationRequested();
            var (name, writer, _, label) = fileList[i];

            currentLabel = label;
            actualOffsets[i] = relOffset;
            long fileStartPos = outputStream.Position;

            writer(outputStream, onRead);

            ulong written = (ulong)(outputStream.Position - fileStartPos);
            actualSizes[i] = written;
            relOffset += written;
        }

        progress?.Report((100, currentLabel));

        long endPos = outputStream.Position;
        outputStream.Position = entryTablePos;

        for (int i = 0; i < fileList.Count; i++)
        {
            WriteStruct(outputStream, new Pfs0FileEntry
            {
                Offset = actualOffsets[i],
                Size = actualSizes[i],
                StringTableOffset = stringOffsets[i]
            });
        }

        outputStream.Position = endPos;
        outputStream.Flush();
    }

    private static ulong AlignUp(ulong value, ulong align) => value + align - 1 & ~(align - 1);

    private static void WriteStruct<T>(Stream stream, T value) where T : struct
    {
        Span<byte> buffer = stackalloc byte[Unsafe.SizeOf<T>()];
        MemoryMarshal.Write(buffer, in value);
        stream.Write(buffer);
    }
}