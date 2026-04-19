using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace NSW.Core.ViewModels;

public class GameFile(string filePath) : INotifyPropertyChanged
{
    private string _fileType = "분석중...";

    public string FilePath { get; } = filePath;

    public string FileName => Path.GetFileName(FilePath);

    public string FileType
    {
        get => _fileType;
        set { _fileType = value; OnPropertyChanged(); OnPropertyChanged(nameof(TypeBackground)); OnPropertyChanged(nameof(TypeForeground)); }
    }

    public Brush TypeBackground
    {
        get
        {
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

    public Brush TypeForeground
    {
        get
        {
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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
