
using ReactiveUI;

namespace NSW.M2.Avalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private double _compressLevel;
    public double CompressLevel
    {
        get => _compressLevel;
        set => this.RaiseAndSetIfChanged(ref _compressLevel, value);
    }

    private bool _verifyCompress;
    public bool VerifyCompress
    {
        get => _verifyCompress;
        set => this.RaiseAndSetIfChanged(ref _verifyCompress, value);
    }
}