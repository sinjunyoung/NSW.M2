using Microsoft.Win32;
using NSW.Core.Enums;
using NSW.Core.UI;
using NSW.M2.Services;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Wpf.Ui.Controls;
using Path = System.IO.Path;
using Res = NSW.M2.Properties.Resources;

namespace NSW.M2;

public partial class MainWindow : FluentWindow
{
    #region Fields & Properties

    public string AppVersion
    {
        get
        {
            string version = Utils.ToAppVersionString();
            return $"{this.Title} - Ver {version}";
        }
    }

    private static readonly string KeysPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prod.keys");

    private readonly Stopwatch _totalSw = new();
    private CancellationTokenSource? _cts;

    #endregion

    public MainWindow()
    {
        InitializeComponent();

        txtOutput.TextChanged += (_, _) => outputHint.Visibility = string.IsNullOrEmpty(txtOutput.Text) ? Visibility.Visible : Visibility.Collapsed;
        txtOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
    }

    private void BtnBrowseOutput_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFolderDialog { Title = Res.Main_SelectFolder };
        if (dlg.ShowDialog() == true) txtOutput.Text = dlg.FolderName;
    }

    private async void BtnMergeStart_Click(object sender, RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            btnMergeStart.Content = Res.Button_MergeStart;
            return;
        }

        _cts = new CancellationTokenSource();
        logBox.Document.Blocks.Clear();

        if (!TryGetBuildRequest(out var req, out string errorMsg))
        {
            MessageBoxHelper.ShowWarning(errorMsg);
            return;
        }

        if(!Directory.Exists(req.OutputDir))
            Directory.CreateDirectory(req.OutputDir);

        SetWorking(true);
        _totalSw.Restart();

        var progress = new Progress<(int pct, string label)>(p =>
        {
            this.progress.Value = p.pct >= 0 ? p.pct : 0;
            progressLabel.Text = p.pct >= 0 ? $"{p.label} ({p.pct}%)" : p.label;
            progressTime.Text = string.Format(Res.Main_Log_Elapsed, _totalSw.Elapsed.ToString(@"mm\:ss"));
        });

        try
        {
            await Task.Run(() =>
            {
                var service = new NspMergeService(KeysPath);
                string finalNsp = service.Merge(req!, progress, LogFromService, _cts.Token);

                Log(string.Format(Res.Main_Log_AllComplete, _totalSw.Elapsed.ToString(@"mm\:ss")), LogLevel.Ok);

                Dispatcher.Invoke(() =>
                {
                    MessageBoxHelper.ShowInfo(string.Format(Res.Main_Msg_Done, finalNsp));
                    Process.Start("explorer.exe", $"\"{req!.OutputDir}\"");
                });
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
            _cts.Dispose();
            _cts = null;
            SetWorking(false);
        }
    }

    private async void BtnSplitStart_Click(object sender, RoutedEventArgs e)
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
            return;
        }

        logBox.Document.Blocks.Clear();

        if (!FileMgr.GameFiles.Any())
        {
            MessageBoxHelper.ShowWarning(Res.Main_Err_NoFiles);
            return;
        }

        string outputDir = txtOutput.Text.Trim();
        if (string.IsNullOrEmpty(outputDir))
        {
            MessageBoxHelper.ShowWarning(Res.Main_Err_NoOutput);
            return;
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        _cts = new CancellationTokenSource();
        logBox.Document.Blocks.Clear();
        SetWorking(true, true); 
        _totalSw.Restart();

        var progress = new Progress<(int pct, string label)>(p =>
        {
            this.progress.Value = p.pct >= 0 ? p.pct : 0;
            progressLabel.Text = p.pct >= 0 ? $"{p.label} ({p.pct}%)" : p.label;
            progressTime.Text = string.Format(Res.Main_Log_Elapsed, _totalSw.Elapsed.ToString(@"mm\:ss"));
        });

        try
        {
            await Task.Run(() =>
            {
                int resultCount = 0;
                var service = new NspSplitService(KeysPath);

                foreach (var fileVm in FileMgr.GameFiles)
                {
                    _cts.Token.ThrowIfCancellationRequested();

                    Log(string.Format(Res.Main_Log_SplitStart, Path.GetFileName(fileVm.FilePath)), LogLevel.Info);

                    resultCount += service.Split(fileVm.FilePath, outputDir, progress, LogFromService, _cts.Token);
                }

                Log(string.Format(Res.Main_Log_AllSplitDone, _totalSw.Elapsed.ToString(@"mm\:ss")), LogLevel.Ok);

                if (resultCount > 0)
                {
                    Dispatcher.Invoke(() =>
                    {
                        MessageBoxHelper.ShowInfo(Res.Main_Msg_SplitDone);
                        Process.Start("explorer.exe", $"\"{outputDir}\"");
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

    private bool TryGetBuildRequest(out BuildRequest? req, out string errorMsg)
    {
        req = null;
        errorMsg = string.Empty;        

        var baseVm = FileMgr.GameFiles.FirstOrDefault(f => f.FileType.Contains('B'));
        if (baseVm == null)
        {
            errorMsg = Res.Main_Err_NoBase;
            return false;
        }

        string outputDir = txtOutput.Text.Trim();
        if (string.IsNullOrEmpty(outputDir))
        {
            errorMsg = Res.Main_Err_NoOutput;
            return false;
        }

        req = new BuildRequest(baseVm.FilePath, FileMgr.GameFiles.FirstOrDefault(f => f.FileType.Contains('U'))?.FilePath ?? "", [.. FileMgr.GameFiles.Where(f => f.FileType.Contains('D')).Select(f => f.FilePath)], outputDir)
        {
            CompressToNcz = false,
            NczCompressionLevel = 3
        };
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

        Dispatcher.Invoke(() =>
        {
            var para = new Paragraph(new Run(msg))
            {
                Foreground = new SolidColorBrush(color),
                Margin = new Thickness(0),
                LineHeight = 18,
            };
            logBox.Document.Blocks.Add(para);
            logBox.ScrollToEnd();
        });
    }

    private void SetWorking(bool working, bool isSplit = false)
    {
        Dispatcher.Invoke(() =>
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
            progressArea.Visibility = working ? Visibility.Visible : Visibility.Collapsed;
        });
    }
}