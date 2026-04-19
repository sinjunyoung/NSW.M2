# Switch Container Merger / Splitter (GUI)

A lightweight GUI tool for merging and splitting Nintendo Switch container files.

Uses a streaming pipeline to process files without creating temporary data on disk.

<img width="1228" height="961" alt="image" src="https://github.com/user-attachments/assets/d1360006-91b3-42b5-bc69-213b243949b1" />

---

## Features

### Merge split files

- Combine split container parts into a single file
- Drag & drop support
- Automatic format detection

### Split container files

- Split large container files into smaller parts
- Configurable part size

---

## Supported Formats

- NSP (merge / split)
- XCI (merge / split)
- NSZ (merge / split, auto-decompressed)
- XCZ (merge / split, auto-decompressed)

**All operations produce NSP output.**

---

## Automatic Decompression

When using compressed formats:

- NSZ files are decompressed automatically
- XCZ files are decompressed automatically

Decompression happens during processing.

---

## Streaming Processing

Uses a streaming pipeline that:

- Processes data during merge or split
- Avoids temporary files
- Reduces disk usage
- Improves performance

### Traditional workflow

1. Decompress NSZ/XCZ
2. Create temporary NSP
3. Merge or split

This tool performs everything in a single step.

---

## Use Cases

- Working with split NSP/XCI files
- Handling compressed NSZ/XCZ containers
- Processing very large files
- Automation workflows

---

## Technical Notes

- Built with **libhac**
- Streaming I/O architecture
- Optimized for large files
- Lightweight GUI

---

## Legal Notice

This project does **not** include any encryption keys.  
Users must provide their own keys if required.

This project is intended for **research and development purposes only**.

---

## License

MIT License
