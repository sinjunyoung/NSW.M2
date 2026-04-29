using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using NSW.Avalonia.ViewModels;
using NSW.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Res = NSW.Core.Properties.Resources;

namespace NSW.Avalonia.UI;

public partial class FileManagerControl : UserControl
{
    public Button ExtraButton => btnExtra;
    public Action? ExtraButtonClicked;

    public ObservableCollection<GameFile> GameFiles { get; set; } = [];
    public event Action? FileListChanged;

    public FileManagerControl()
    {
        InitializeComponent();
        this.DataContext = this;

        lvFiles.AddHandler(DragDrop.DragOverEvent, LvFiles_DragOver, RoutingStrategies.Bubble);
        lvFiles.AddHandler(DragDrop.DropEvent, LvFiles_Drop, RoutingStrategies.Bubble);

        GameFiles.CollectionChanged += (s, e) => UpdateDropHint();
        UpdateDropHint();
    }

    public static bool KeyExists() => KeySetProvider.Instance.KeySet != null;

    public void RecalcKeyMissingFiles(Action onCompleted)
    {
        var targets = GameFiles.Where(f => f.IsKeyMissing).ToList();
        if (targets.Count == 0) { onCompleted(); return; }

        var keySet = KeySetProvider.Instance.KeySet;
        if (keySet == null) { onCompleted(); return; }

        int remaining = targets.Count;
        foreach (var vm in targets)
        {
            string capturedPath = vm.FilePath;
            Task.Run(() =>
            {
                string result = Core.Utils.DetectFileType(capturedPath, keySet);
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    vm.FileType = result;
                    if (Interlocked.Decrement(ref remaining) == 0)
                        onCompleted();
                });
            });
        }
    }

    private void UpdateDropHint()
    {
        dropHint.IsVisible = GameFiles.Count == 0;




        FileListChanged?.Invoke();
    }

    private async void BtnAddFile_Click(object sender, RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null) return;

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = Res.Dialog_SelectGameFile,
            AllowMultiple = true,
            FileTypeFilter =
            [
            new FilePickerFileType(Res.Filter_SwitchFiles)
            {
                Patterns = ["*.nsp", "*.xci", "*.nsz", "*.xcz"]
            },
            new FilePickerFileType(Res.Filter_AllFiles)
            {
                Patterns = ["*.*"]
            }
        ]
        });

        if (files.Count > 0)
        {
            var fileNames = files.Select(f => f.Path.LocalPath).ToArray();
            AddFiles(fileNames);
        }
    }

    private void BtnRemoveFile_Click(object sender, RoutedEventArgs e)
    {
        var selected = lvFiles.SelectedItems.Cast<GameFile>().ToList();

        if (selected.Count == 0) return;

        Dispatcher.UIThread.Post(() =>
        {
            foreach (var item in selected)
            {
                GameFiles.Remove(item);
            }
        });
    }

    private void BtnRemoveAllFiles_Click(object sender, RoutedEventArgs e) => GameFiles.Clear();

    private void BtnExtra_Click(object sender, RoutedEventArgs e) => ExtraButtonClicked?.Invoke();

    private void LvFiles_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete) BtnRemoveFile_Click(sender, new RoutedEventArgs());
    }

    private void LvFiles_DragOver(object? sender, DragEventArgs e)
    {
        if (e.DataTransfer.TryGetFiles()?.Length > 0)
            e.DragEffects = DragDropEffects.Copy;
        else
            e.DragEffects = DragDropEffects.None;
    }

    private void LvFiles_Drop(object? sender, DragEventArgs e)
    {
        var storageItems = e.DataTransfer.TryGetFiles();

        if (storageItems != null)
        {
            var paths = storageItems
                .Select(item => item.Path.LocalPath)
                .Where(path => !string.IsNullOrEmpty(path));

            AddFiles(paths);
        }
    }

    private async void AddFiles(IEnumerable<string> paths)
    {
        bool keyMissing = !KeyExists();
        bool warnShown = false;
        var keySet = KeySetProvider.Instance.KeySet;

        foreach (var path in paths)
        {
            string ext = Path.GetExtension(path).ToLowerInvariant();
            if (ext is not (".nsp" or ".xci" or ".nsz" or ".xcz")) continue;
            if (GameFiles.Any(f => f.FilePath.Equals(path, StringComparison.OrdinalIgnoreCase))) continue;

            if (keyMissing)
            {
                if (!warnShown)
                {
                    await MessageBoxHelper.ShowWarning(Res.Main_Err_NoKeys);
                    warnShown = true;
                }
                GameFiles.Add(new GameFile(path) { FileType = Res.Status_NoKey });
            }
            else
            {
                var vm = new GameFile(path) { FileType = Res.Status_Analyzing };
                GameFiles.Add(vm);

                string capturedPath = path;
                await Task.Run(async () =>
                {
                    string result = Core.Utils.DetectFileType(capturedPath, keySet);
                    await Dispatcher.UIThread.InvokeAsync(() => vm.FileType = result);
                });
            }
        }
    }
}