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

namespace NSW.M2;

public partial class MainWindow : FluentWindow
{
    public string AppVersion
    {
        get
        {
            if (this.DataContext != null || true) { }
            return "NSW Merge Tool - Ver 2026/04/19";
        }
    }

    private static readonly string KeysPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prod.keys");

    private readonly Stopwatch _totalSw = new();

    public MainWindow()
    {
        InitializeComponent();

        txtOutput.TextChanged += (_, _) => outputHint.Visibility = string.IsNullOrEmpty(txtOutput.Text) ? Visibility.Visible : Visibility.Collapsed;

        txtOutput.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
    }

    private void BtnBrowseOutput_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFolderDialog { Title = "작업 폴더 선택" };
        if (dlg.ShowDialog() == true) txtOutput.Text = dlg.FolderName;
    }

    private async void BtnMergeStart_Click(object sender, RoutedEventArgs e)
    {
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
            progressTime.Text = $"{_totalSw.Elapsed:mm\\:ss} 경과";
        });

        string? finalNsp = null;

        await Task.Run(() =>
        {
            try
            {
                var service = new NspMergeService(KeysPath);
                finalNsp = service.Merge(req!, progress, LogFromService, CancellationToken.None);

                Log($"\n✓ 전체 완료  총 소요: {_totalSw.Elapsed:mm\\:ss}", LogLevel.Ok);

                Dispatcher.Invoke(() =>
                {
                    MessageBoxHelper.ShowInfo($"완료!\n{finalNsp}");
                    Process.Start("explorer.exe", $"\"{req!.OutputDir}\"");
                });
            }
            catch (Exception ex)
            {
                Log($"오류: {ex.Message}", LogLevel.Error);
                Log(ex.StackTrace ?? "", LogLevel.Error);
            }
        });

        SetWorking(false);
    }

    private async void BtnSplitStart_Click(object sender, RoutedEventArgs e)
    {
        logBox.Document.Blocks.Clear();

        if (!FileMgr.GameFiles.Any())
        {
            MessageBoxHelper.ShowWarning("분리할 파일을 목록에 추가하세요.");
            return;
        }

        string outputDir = txtOutput.Text.Trim();
        if (string.IsNullOrEmpty(outputDir))
        {
            MessageBoxHelper.ShowWarning("작업 폴더를 설정하세요.");
            return;
        }

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        SetWorking(true);
        _totalSw.Restart();

        var progress = new Progress<(int pct, string label)>(p =>
        {
            this.progress.Value = p.pct >= 0 ? p.pct : 0;
            progressLabel.Text = p.pct >= 0 ? $"{p.label} ({p.pct}%)" : p.label;
            progressTime.Text = $"{_totalSw.Elapsed:mm\\:ss} 경과";
        });

        await Task.Run(() =>
        {
            try
            {
                var service = new NspSplitService(KeysPath);

                foreach (var fileVm in FileMgr.GameFiles)
                {
                    Log($"\n━━ 분리 분석 시작: {Path.GetFileName(fileVm.FilePath)} ━━", LogLevel.Info);

                    service.Split(
                        fileVm.FilePath,
                        outputDir,
                        progress,
                        LogFromService,
                        CancellationToken.None
                    );
                }

                Log($"\n✓ 모든 분리 작업 완료! 총 소요: {_totalSw.Elapsed:mm\\:ss}", LogLevel.Ok);

                Dispatcher.Invoke(() =>
                {
                    MessageBoxHelper.ShowInfo("분리가 완료되었습니다.");
                    Process.Start("explorer.exe", $"\"{outputDir}\"");
                });
            }
            catch (Exception ex)
            {
                Log($"분리 중 오류 발생: {ex.Message}", LogLevel.Error);
                Log(ex.StackTrace ?? "", LogLevel.Error);
            }
        });

        SetWorking(false);
    }

    private bool TryGetBuildRequest(out BuildRequest? req, out string errorMsg)
    {
        req = null;
        errorMsg = string.Empty;        

        var baseVm = FileMgr.GameFiles.FirstOrDefault(f => f.FileType.Contains('B'));
        if (baseVm == null)
        {
            errorMsg = "본편(BASE)이 포함된 파일을 추가하세요.";
            return false;
        }

        string outputDir = txtOutput.Text.Trim();
        if (string.IsNullOrEmpty(outputDir))
        {
            errorMsg = "작업 폴더를 설정하세요.";
            return false;
        }

        req = new BuildRequest(
            BaseFilePath: baseVm.FilePath,
            UpdateFilePath: FileMgr.GameFiles.FirstOrDefault(f => f.FileType.Contains('U'))?.FilePath ?? "",
            DlcFilePaths: [.. FileMgr.GameFiles.Where(f => f.FileType.Contains('D')).Select(f => f.FilePath)],
            OutputDir: outputDir
        )
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

    private void SetWorking(bool working)
    {
        Dispatcher.Invoke(() =>
        {
            btnMergeStart.IsEnabled = !working;
            btnSplitStart.IsEnabled = !working;
            FileMgr.IsEnabled = !working;
            btnBrowseOutput.IsEnabled = !working;
            txtOutput.IsEnabled = !working;
            progressArea.Visibility = working ? Visibility.Visible : Visibility.Collapsed;
        });
    }
}