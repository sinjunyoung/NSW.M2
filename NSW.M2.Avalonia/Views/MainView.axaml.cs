using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using NSW.Avalonia.Services;
using NSW.Avalonia.UI;
using NSW.Core.Enums;
using NSW.M2.Avalonia.Services;
using NSW.M2.Avalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Path = System.IO.Path;
using Res = NSW.Core.Properties.Resources;

namespace NSW.M2.Avalonia.Views;

public partial class MainView : UserControl
{
    private readonly Stopwatch _totalSw = new();
    private CancellationTokenSource? _cts;

    private static readonly Bitmap MergeIcon = new (AssetLoader.Open(new Uri("avares://NSW.M2.Avalonia/Assets/Images/Merge.png")));
    private static readonly Bitmap SplitIcon = new (AssetLoader.Open(new Uri("avares://NSW.M2.Avalonia/Assets/Images/Split.png")));
    private static readonly Bitmap CancelIcon = new(AssetLoader.Open(new Uri("avares://NSW.M2.Avalonia/Assets/Images/Cancel.png")));

    public MainView()
    {
        InitializeComponent();

        txtOutput.GetObservable(TextBox.TextProperty).Subscribe(text => {
            if (outputHint != null)
                outputHint.IsVisible = string.IsNullOrEmpty(text);
        });

        if(!OperatingSystem.IsAndroid())
            txtOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
        else
            txtOutput.Text = Path.Combine("/sdcard/Download", "output");
                
        tbMergeText.Text = Res.Button_MergeStart;
        imgMerge.Source = MergeIcon;
        tbSplitText.Text = Res.Button_SplitStart;
        imgSplit.Source = SplitIcon;

        this.AttachedToVisualTree += (s, e) =>
        {
            if (DataContext is MainViewModel vm)
            {
                var config = AppConfig.Instance;
                vm.CompressLevel = config.CompressLevel;
                vm.VerifyCompress = config.VerifyCompress;
            }
        };

        this.DetachedFromVisualTree += (s, e) =>
        {
            if (DataContext is MainViewModel vm)
            {
                var config = AppConfig.Instance;
                config.CompressLevel = (int)vm.CompressLevel;
                config.VerifyCompress = vm.VerifyCompress;
                config.Save();
            }
        };
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);

        if (_cts != null)
        {
            _cts.Cancel();
            _cts.Dispose();
            _cts = null;
        }
    }

    private void BtnWorkSpace_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        string path = txtOutput.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            return;

        try
        {
            if (OperatingSystem.IsWindows())
            {
                Process.Start("explorer.exe", path);
            }
            else if (OperatingSystem.IsLinux())
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "xdg-open",
                    Arguments = path,
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            else if (OperatingSystem.IsMacOS())
            {
                Process.Start("open", path);
            }
            else if (OperatingSystem.IsAndroid())
            {
                
            }
        }
        catch (Exception ex)
        {
            Log($"fail: {ex.Message}", LogLevel.Error);
        }
    }

    private async void BtnBrowseOutput_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = Res.Hint_SelectOutput,
            AllowMultiple = false
        });

        if (folders.Count > 0)
        {
            txtOutput.Text = folders[0].Path.LocalPath;
        }
    }

    private async void BtnMergeStart_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            await SetWorking(false, isSplit: false);
            return;
        }

        logBox.Inlines?.Clear();

        if (!FileManagerControl.KeyExists())
        {
            string msg = OperatingSystem.IsAndroid() ? Res.Main_Err_NoKeys_Android : Res.Main_Err_NoKeys;
            await MessageBoxHelper.ShowWarning(msg);
            return;
        }

        if (FileMgr.GameFiles.Any(f => f.IsKeyMissing))
        {
            await SetWorking(true);
            progressLabel.Text = Res.Main_Log_Recalculating;

            bool completed = false;
            FileMgr.RecalcKeyMissingFiles(() => completed = true);

            while (!completed)
                await Task.Delay(100);
        }

        if (!TryGetMergeInputs(out var inputPaths, out var outputDir, out string errorMsg))
        {
            await MessageBoxHelper.ShowWarning(errorMsg);
            await SetWorking(false);
            return;
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        _cts = new CancellationTokenSource();
        await SetWorking(true);
        _totalSw.Restart();

        var progressReporter = new Progress<(int pct, string label)>(p =>
        {
            Dispatcher.UIThread.Post(() => {
                this.progress.Value = p.pct >= 0 ? p.pct : 0;
                progressLabel.Text = p.pct >= 0 ? $"{p.label} ({p.pct}%)" : p.label;
                progressTime.Text = string.Format(Res.Main_Log_Elapsed, _totalSw.Elapsed.ToString(@"mm\:ss"));
            });
        });

        bool verify = tbVerify.IsChecked == true;
        int compressLevel = (int)sliderCompression.Value;

        try
        {
            await Task.Run(() =>
            {
                var results = NspMergeService.Merge(inputPaths, outputDir, compressLevel, verify, progressReporter, LogFromService, _cts.Token);

                if (results != null && results.Count > 0)
                {
                    Log(string.Format(Res.Main_Log_AllComplete, _totalSw.Elapsed.ToString(@"mm\:ss")), LogLevel.Ok);

                    Dispatcher.UIThread.Post(async () =>
                    {
                        await MessageBoxHelper.ShowInfo(string.Format(Res.Main_Msg_Done, string.Join("\n", results.Select(Path.GetFileName))));
                    });
                }
            }, _cts.Token);
        }
        catch (OperationCanceledException)
        {
            Log(Res.Button_Cancel, LogLevel.Error);
        }
        catch (Exception ex)
        {
            Log($"{Res.Log_Error}: {ex.Message}", LogLevel.Error);
        }
        finally
        {
            _cts?.Dispose();
            _cts = null;
            await SetWorking(false);
        }
    }

    private async void BtnSplitStart_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            await SetWorking(false, isSplit: true);
            return;
        }

        logBox.Inlines?.Clear();

        if (!FileMgr.GameFiles.Any())
        {
            await MessageBoxHelper.ShowWarning(Res.Main_Err_NoFiles);
            return;
        }

        string outputDir = txtOutput.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(outputDir))
        {
            await MessageBoxHelper.ShowWarning(Res.Main_Err_NoOutput);
            return;
        }

        if (!FileManagerControl.KeyExists())
        {
            string msg = OperatingSystem.IsAndroid() ? Res.Main_Err_NoKeys_Android : Res.Main_Err_NoKeys;
            await MessageBoxHelper.ShowWarning(msg);
            return;
        }

        if (FileMgr.GameFiles.Any(f => f.IsKeyMissing))
        {
            await SetWorking(true, isSplit: true);
            progressLabel.Text = Res.Main_Log_Recalculating;

            bool completed = false;
            FileMgr.RecalcKeyMissingFiles(() => completed = true);

            while (!completed)
                await Task.Delay(100);
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        _cts = new CancellationTokenSource();
        await SetWorking(true, isSplit: true);
        _totalSw.Restart();

        var progressReporter = new Progress<(int pct, string label)>(p =>
        {
            Dispatcher.UIThread.Post(() => {
                this.progress.Value = p.pct >= 0 ? p.pct : 0;
                progressLabel.Text = p.pct >= 0 ? $"{p.label} ({p.pct}%)" : p.label;
                progressTime.Text = string.Format(Res.Main_Log_Elapsed, _totalSw.Elapsed.ToString(@"mm\:ss"));
            });
        });

        try
        {
            await Task.Run(() =>
            {
                int resultCount = 0;

                foreach (var fileVm in FileMgr.GameFiles)
                {
                    _cts.Token.ThrowIfCancellationRequested();

                    Log(string.Format(Res.Main_Log_SplitStart, Path.GetFileName(fileVm.FilePath)), LogLevel.Info);

                    resultCount += NspSplitService.Split(fileVm.FilePath, outputDir, progressReporter, LogFromService, _cts.Token);
                }

                Log(string.Format(Res.Main_Log_AllSplitDone, _totalSw.Elapsed.ToString(@"mm\:ss")), LogLevel.Ok);

                if (resultCount > 0)
                {
                    Dispatcher.UIThread.Post(async () =>
                    {
                        await MessageBoxHelper.ShowInfo(Res.Main_Msg_SplitDone);
                    });
                }
            }, _cts.Token);
        }
        catch (OperationCanceledException)
        {
            Log(Res.Log_Error + ": " + Res.Button_Cancel, LogLevel.Error);
        }
        catch (Exception ex)
        {
            Log($"{Res.Log_Error}: {ex.Message}", LogLevel.Error);
        }
        finally
        {
            _cts?.Dispose();
            _cts = null;
            await SetWorking(false);
        }
    }

    private bool TryGetMergeInputs(out List<string> inputPaths, out string outputDir, out string errorMsg)
    {
        inputPaths = [];
        outputDir = string.Empty;
        errorMsg = string.Empty;

        if (FileMgr.GameFiles.Any(f => f.IsKeyMissing))
        {
            errorMsg = Res.Main_Err_NoKeys;
            return false;
        }

        if (!FileMgr.GameFiles.Any(f => f.FileType.Contains('B')))
        {
            errorMsg = Res.Main_Err_NoBase;
            return false;
        }

        outputDir = txtOutput.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrEmpty(outputDir))
        {
            errorMsg = Res.Main_Err_NoOutput;
            return false;
        }

        inputPaths = [.. FileMgr.GameFiles.Select(f => f.FilePath)];
        return true;
    }

    private void LogFromService(string msg, LogLevel level) => Log(msg, level);

    private void Log(string msg, LogLevel level = LogLevel.Info)
    {
        var color = LogColor.GetColor(level);

        Dispatcher.UIThread.Post(() =>
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            var run = new global::Avalonia.Controls.Documents.Run($"[{timestamp}] {msg}{Environment.NewLine}")
            {
                Foreground = new SolidColorBrush(color)
            };
            logBox.Inlines ??= [];
            logBox.Inlines.Add(run);

            svLogBox.ScrollToEnd();
        });
    }

    private async Task SetWorking(bool working, bool isSplit = false)
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            if (working)
            {
                if (!isSplit)
                {
                    tbMergeText.Text = Res.Button_Cancel;
                    imgMerge.Source = CancelIcon;
                }
                else
                {
                    tbSplitText.Text = Res.Button_Cancel;
                    imgSplit.Source = CancelIcon;
                }
            }
            else
            {
                tbMergeText.Text = Res.Button_MergeStart;
                imgMerge.Source = MergeIcon;
                tbSplitText.Text = Res.Button_SplitStart;
                imgSplit.Source = SplitIcon;
            }

            btnMergeStart.IsEnabled = !working || (working && !isSplit);
            btnSplitStart.IsEnabled = !working || (working && isSplit);

            FileMgr.IsEnabled = !working;               
            btnWorkSpace.IsEnabled = !working;
            btnBrowseOutput.IsEnabled = !working;
            sliderCompression.IsEnabled = !working;
            tbVerify.IsEnabled = !working;
            txtOutput.IsEnabled = !working;
            progressArea.IsVisible = working;
        });
    }
}