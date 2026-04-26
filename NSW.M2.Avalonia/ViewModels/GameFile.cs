using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using ReactiveUI;

namespace NSW.M2.Avalonia.ViewModels;

public class GameFile(string filePath) : ReactiveUI.ReactiveObject, INotifyPropertyChanged
{
    private string _fileType = Core.Properties.Resources.Status_Analyzing;

    public string FilePath { get; } = filePath;
    public string FileName => Path.GetFileNameWithoutExtension(FilePath);
    public string Extension => Path.GetExtension(FilePath).TrimStart('.');

    public string FileSize
    {
        get
        {
            try
            {
                var info = new FileInfo(FilePath);
                if (!info.Exists) return "-";
                long bytes = info.Length;
                if (bytes >= 1_073_741_824) return $"{bytes / 1_073_741_824.0:F1} GB";
                if (bytes >= 1_048_576) return $"{bytes / 1_048_576.0:F1} MB";
                return $"{bytes / 1024.0:F1} KB";
            }
            catch { return "-"; }
        }
    }

    public string FileType
    {
        get => _fileType;
        set
        {
            this.RaiseAndSetIfChanged(ref _fileType, value);
            this.RaisePropertyChanged(nameof(TypeBackground));
            this.RaisePropertyChanged(nameof(TypeForeground));
        }
    }

    public bool IsKeyMissing => _fileType == Core.Properties.Resources.Status_NoKey;

    public IBrush TypeBackground
    {
        get
        {
            if (IsKeyMissing)
                return new SolidColorBrush(Color.FromArgb(60, 220, 50, 50));

            if (_fileType == "?")
                return new SolidColorBrush(Color.FromArgb(60, 200, 160, 0));

            bool hasBase = FileType.Contains('B');
            bool hasUpdate = FileType.Contains('U');
            bool hasDlc = FileType.Contains('D');
            int count = (hasBase ? 1 : 0) + (hasUpdate ? 1 : 0) + (hasDlc ? 1 : 0);

            if (count > 1) return new SolidColorBrush(Color.FromArgb(50, 120, 0, 212));
            if (hasBase) return new SolidColorBrush(Color.FromArgb(50, 0, 120, 212));
            if (hasUpdate) return new SolidColorBrush(Color.FromArgb(50, 16, 124, 16));
            if (hasDlc) return new SolidColorBrush(Color.FromArgb(50, 200, 130, 0));

            return new SolidColorBrush(Color.FromArgb(30, 255, 255, 255));
        }
    }

    public IBrush TypeForeground
    {
        get
        {
            if (IsKeyMissing)
                return new SolidColorBrush(Color.FromRgb(255, 100, 100));

            if (_fileType == "?")
                return new SolidColorBrush(Color.FromRgb(255, 210, 80));

            bool hasBase = FileType.Contains('B');
            bool hasUpdate = FileType.Contains('U');
            bool hasDlc = FileType.Contains('D');
            int count = (hasBase ? 1 : 0) + (hasUpdate ? 1 : 0) + (hasDlc ? 1 : 0);

            if (count > 1) return new SolidColorBrush(Color.FromRgb(180, 100, 255));
            if (hasBase) return new SolidColorBrush(Color.FromRgb(100, 180, 255));
            if (hasUpdate) return new SolidColorBrush(Color.FromRgb(100, 210, 100));
            if (hasDlc) return new SolidColorBrush(Color.FromRgb(255, 190, 80));

            return new SolidColorBrush(Color.FromRgb(160, 160, 160));
        }
    }

    public static GameFile FromPath(string path) => new(path);
}