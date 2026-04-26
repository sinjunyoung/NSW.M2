using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using NSW.Core.Enums;
using NSW.M2.Avalonia.Services;
using NSW.M2.Avalonia.UI;
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
    }

    private async void BtnBrowseOutput_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        var picker = FolderPickerFactory.Create?.Invoke();

        var path = await picker.PickFolderAsync("");

        if (!string.IsNullOrEmpty(path))
            txtOutput.Text = path;
    }

    private async void BtnMergeStart_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            btnMergeStart.Content = Res.Button_MergeStart;
            return;
        }

        logBox.Clear();

        if (!FileManagerControl.KeyExists())
        {
            string msg = OperatingSystem.IsAndroid() ? Res.Main_Err_NoKeys_Android : Res.Main_Err_NoKeys;
            await MessageBoxHelper.ShowWarning(msg);
            return;
        }

        if (FileMgr.GameFiles.Any(f => f.IsKeyMissing))
        {
            SetWorking(true);
            progressLabel.Text = Res.Main_Log_Recalculating;

            bool completed = false;
            FileMgr.RecalcKeyMissingFiles(() => completed = true);

            while (!completed)
                await Task.Delay(100);
        }

        if (!TryGetMergeInputs(out var inputPaths, out var outputDir, out string errorMsg))
        {
            await MessageBoxHelper.ShowWarning(errorMsg);
            SetWorking(false);
            return;
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        _cts = new CancellationTokenSource();
        SetWorking(true);
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
                var results = NspMergeService.Merge(inputPaths, outputDir, false, 3, 17, progressReporter, LogFromService, _cts.Token);

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
            SetWorking(false);
        }
    }

    private async void BtnSplitStart_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            return;
        }

        logBox.Clear();

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
            SetWorking(true, isSplit: true);
            progressLabel.Text = Res.Main_Log_Recalculating;

            bool completed = false;
            FileMgr.RecalcKeyMissingFiles(() => completed = true);

            while (!completed)
                await Task.Delay(100);
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        _cts = new CancellationTokenSource();
        SetWorking(true, isSplit: true);
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
            SetWorking(false);
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
        var color = level switch
        {
            LogLevel.Ok => Color.FromRgb(100, 200, 100),
            LogLevel.Error => Color.FromRgb(255, 80, 80),
            _ => Color.FromRgb(180, 180, 180),
        };

        Dispatcher.UIThread.Post(() =>
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            logBox.Text += $"[{timestamp}] {msg}{Environment.NewLine}";
            logBox.CaretIndex = logBox.Text?.Length ?? 0;
        });
    }

    private void SetWorking(bool working, bool isSplit = false)
    {
        Dispatcher.UIThread.Post(() =>
        {
            if (working)
            {
                if (isSplit) btnSplitStart.Content = Res.Button_Cancel;
                else btnMergeStart.Content = Res.Button_Cancel;
            }
            else
            {
                btnMergeStart.Content = Res.Button_MergeStart;
                btnSplitStart.Content = Res.Button_SplitStart;
            }

            btnMergeStart.IsEnabled = !working || !isSplit;
            btnSplitStart.IsEnabled = !working || isSplit;

            FileMgr.IsEnabled = !working;
            btnBrowseOutput.IsEnabled = !working;
            txtOutput.IsEnabled = !working;
            progressArea.IsVisible = working;
        });
    }
}