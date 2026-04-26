using NSW.M2.Avalonia.Android.Enums;
using ReactiveUI;
using System;

namespace NSW.M2.Avalonia.Android.ViewModels;

public class FileItem : ReactiveObject
{
    private string _name = string.Empty;
    private string _fullPath = string.Empty;
    private bool _isDirectory;
    private bool _isParentDirectory;
    private long _size;
    private DateTime _modifiedDate;
    private global::Avalonia.Media.Imaging.Bitmap? _thumbnail;
    private FileIconType _iconType;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string FullPath
    {
        get => _fullPath;
        set => this.RaiseAndSetIfChanged(ref _fullPath, value);
    }

    public bool IsDirectory
    {
        get => _isDirectory;
        set => this.RaiseAndSetIfChanged(ref _isDirectory, value);
    }

    public bool IsParentDirectory
    {
        get => _isParentDirectory;
        set => this.RaiseAndSetIfChanged(ref _isParentDirectory, value);
    }

    public long Size
    {
        get => _size;
        set => this.RaiseAndSetIfChanged(ref _size, value);
    }

    public DateTime ModifiedDate
    {
        get => _modifiedDate;
        set => this.RaiseAndSetIfChanged(ref _modifiedDate, value);
    }

    public global::Avalonia.Media.Imaging.Bitmap? Thumbnail
    {
        get => _thumbnail;
        set => this.RaiseAndSetIfChanged(ref _thumbnail, value);
    }

    public FileIconType IconType
    {
        get => _iconType;
        set => this.RaiseAndSetIfChanged(ref _iconType, value);
    }

    public string DisplaySize => IsDirectory ? string.Empty : FormatBytes(Size);

    public bool IsImage
    {
        get
        {
            if (IsDirectory) return false;
            var ext = System.IO.Path.GetExtension(Name).ToLower();
            return ext is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".webp";
        }
    }

    public bool IsVideo
    {
        get
        {
            if (IsDirectory) return false;
            var ext = System.IO.Path.GetExtension(Name).ToLower();
            return ext is ".mkv" or ".mp4" or ".avi" or ".mov" or ".wmv" or ".flv" or ".webm" or ".m4v" or ".3gp";
        }
    }

    public static FileIconType GetIconTypeFromExtension(string filename)
    {
        var ext = System.IO.Path.GetExtension(filename).ToLower();
        return ext switch
        {
            ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".webp" => FileIconType.Image,
            ".mp4" or ".avi" or ".mkv" or ".mov" or ".wmv" => FileIconType.Video,
            ".mp3" or ".wav" or ".flac" or ".m4a" or ".ogg" => FileIconType.Audio,
            ".txt" or ".log" => FileIconType.Text,
            ".pdf" => FileIconType.Pdf,
            ".zip" or ".rar" or ".7z" or ".tar" or ".gz" => FileIconType.Archive,
            ".exe" or ".apk" => FileIconType.Executable,
            ".xml" or ".json" or ".yaml" or ".yml" => FileIconType.Config,
            ".gb" or ".gbc" or ".gba" or ".nes" or ".smc" or ".sfc" or ".n64" or ".nds" => FileIconType.Game,
            _ => FileIconType.File
        };
    }

    private static string FormatBytes(long bytes)
    {
        string[] sizes = ["B", "KB", "MB", "GB"];
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len /= 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}