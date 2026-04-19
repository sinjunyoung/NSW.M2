# Switch Container Merger / Splitter (GUI)

A lightweight graphical utility for working with Nintendo Switch
container formats.

This application provides an easy way to **merge and split container
files** using a fast streaming workflow that avoids creating temporary
files.

------------------------------------------------------------------------

## Features

### Merge split container parts

-   Combine split files into a single container using a simple GUI
-   Drag & drop support
-   Automatic file type detection

### Split large container files

-   Split container files into smaller parts for storage or transfer
-   User-configurable part size

------------------------------------------------------------------------

## Supported Input Formats

  Input Format   Merge   Split   Output
  -------------- ------- ------- --------
  NSP            ✔       ✔       NSP
  XCI            ✔       ✔       NSP
  NSZ            ✔       ✔       NSP
  XCZ            ✔       ✔       NSP

**All operations always produce NSP output.**

------------------------------------------------------------------------

## Automatic Decompression

When compressed formats are used:

-   NSZ files are automatically decompressed\
-   XCZ files are automatically decompressed

Decompression happens **during merge or split**, not beforehand.

------------------------------------------------------------------------

## Streaming Processing (No Temporary Files)

This tool uses a streaming pipeline that:

-   Decompresses **while merging or splitting**
-   Does **not create intermediate temporary files**
-   Minimizes disk usage
-   Speeds up processing

Traditional workflow avoided:

1.  Decompress NSZ/XCZ\
2.  Create temporary NSP\
3.  Merge or split

This application performs everything **in one step**.

------------------------------------------------------------------------

## Designed For

-   Developers working with Switch container formats\
-   Researchers and file format enthusiasts\
-   Low disk space environments\
-   Automation and archival workflows

------------------------------------------------------------------------

## Technical Notes

-   Built with **libhac**
-   Streaming I/O architecture
-   Optimized for very large files
-   Lightweight and simple GUI

------------------------------------------------------------------------

## Legal Notice

This project does **not** include any encryption keys.\
Users must supply their own keys if required.

This project is provided for **research and development purposes only**.

------------------------------------------------------------------------

## License

MIT License
