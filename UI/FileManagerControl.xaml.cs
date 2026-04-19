using Microsoft.Win32;
using NSW.Core.ViewModels;
using NSW.M2;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NSW.Core.UI
{
    public partial class FileManagerControl : UserControl
    {
        private static readonly string KeysPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "prod.keys");
        private static LibHac.Common.Keys.KeySet? KeySet => File.Exists(KeysPath) ? LibHac.Common.Keys.ExternalKeyReader.ReadKeyFile(KeysPath) : null;

        public ObservableCollection<GameFile> GameFiles { get; set; } = [];

        public event Action? FileListChanged;

        public FileManagerControl()
        {
            InitializeComponent();
            lvFiles.ItemsSource = GameFiles;
            UpdateDropHint();
        }

        private void UpdateDropHint()
        {
            this.dropHint.Visibility = GameFiles.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        
            if (this.lvFiles.View is GridView gridView)
                gridView.AutoResizeColumns();

            this.FileListChanged?.Invoke();
        }

        private void BtnAddFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Title = "게임 파일 선택",
                Filter = "Switch 파일 (*.nsp;*.xci;*.nsz;*.xcz)|*.nsp;*.xci;*.nsz;*.xcz|모든 파일|*.*",
                Multiselect = true
            };
            if (dlg.ShowDialog() == true) AddFiles(dlg.FileNames);
        }
        private void BtnRemoveFile_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lvFiles.SelectedItems.Cast<GameFile>().ToList())
            {
                GameFiles.Remove(item);
            }
            UpdateDropHint();
        }

        private void BtnRemoveAllFiles_Click(object sender, RoutedEventArgs e)
        {
            GameFiles.Clear();
            UpdateDropHint();
        }

        private void LvFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) BtnRemoveFile_Click(sender, new RoutedEventArgs());
        }

        private void LvFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
            e.Handled = true;
        }

        private void LvFiles_Drop(object sender, DragEventArgs e)
        {
            var files = (string[]?)e.Data.GetData(DataFormats.FileDrop);
            if (files != null) AddFiles(files);
        }

        private void AddFiles(IEnumerable<string> paths)
        {
            var keySet = KeySet;

            foreach (var path in paths)
            {
                string ext = Path.GetExtension(path).ToLowerInvariant();
                if (ext != ".nsp" && ext != ".xci" && ext != ".nsz" && ext != ".xcz") continue;
                if (GameFiles.Any(f => f.FilePath.Equals(path, StringComparison.OrdinalIgnoreCase))) continue;

                var vm = new GameFile(path) { FileType = "분석중..." };
                GameFiles.Add(vm);

                string capturedPath = path;
                _ = Task.Run(() =>
                {
                    string result = Utils.DetectFileType(capturedPath, keySet);
                    Dispatcher.Invoke(() => vm.FileType = result);
                });
            }

            UpdateDropHint();
        }
    }
}