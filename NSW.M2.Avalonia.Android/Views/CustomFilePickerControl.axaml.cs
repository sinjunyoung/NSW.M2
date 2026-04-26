using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.VisualTree;
using NSW.M2.Avalonia.Android.Models;
using NSW.M2.Avalonia.Android.ViewModels;
using NSW.M2.Avalonia.Enums;
using NSW.M2.Avalonia.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Android.Views
{
    public partial class CustomFilePickerControl : BaseOverlay
    {
        private CustomFilePickerViewModel? ViewModel => DataContext as CustomFilePickerViewModel;
        public event EventHandler<List<string>?>? FilesSelected;
        public event EventHandler? Cancelled;

        private Grid? _mainGrid;
        private ItemsControl? _fileItemsControl;
        private int _selectedIndex = 0;

        public override bool Visible => _mainGrid?.IsVisible ?? false;

        public CustomFilePickerControl() => InitializeComponent();

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);

            _mainGrid = this.FindControl<Grid>("MainGrid");
            _fileItemsControl = this.FindControl<ItemsControl>("FileItemsControl");
        }

        public override void Show()
        {
            OnShowing(EventArgs.Empty);

            if (_mainGrid != null)
                _mainGrid.IsVisible = true;

            Focusable = true;
            Focus();

            _selectedIndex = 0;

            Dispatcher.UIThread.Post(() => UpdateSelection(), DispatcherPriority.Loaded);
        }

        public override void Hide(HiddenState state)
        {
            if (_mainGrid != null)
                _mainGrid.IsVisible = false;

            OnHidden(new HiddenEventArgs { State = state });
        }

        protected override void MovePrevious()
        {
            if (ViewModel?.Files == null || ViewModel.Files.Count == 0)
                return;

            _selectedIndex = Math.Max(0, _selectedIndex - 1);

            try
            {
                UpdateSelection();
            }
            catch { }
        }

        protected override void MoveNext()
        {
            if (ViewModel?.Files == null || ViewModel.Files.Count == 0) return;

            _selectedIndex = Math.Min(ViewModel.Files.Count - 1, _selectedIndex + 1);

            try
            {
                UpdateSelection();
            }
            catch { }
        }

        protected override async void SelectCurrent()
        {
            if (ViewModel?.Files == null || _selectedIndex < 0 || _selectedIndex >= ViewModel.Files.Count)
                return;

            var selectedFile = ViewModel.Files[_selectedIndex];

            if (selectedFile.IsDirectory)
            {
                await ViewModel.OnItemTapped(selectedFile);
                _selectedIndex = 0;
                await Task.Delay(100);
                Dispatcher.UIThread.Post(() => UpdateSelection(), DispatcherPriority.Loaded);
            }
            else
            {
                await ViewModel.OnItemTapped(selectedFile); // 토글 처리
                UpdateSelection();
            }
        }

        private void UpdateSelection()
        {
            if (ViewModel?.Files == null || _fileItemsControl == null) return;

            var borders = _fileItemsControl.GetVisualDescendants()
                .OfType<Border>()
                .Where(b => b.Name == "FileItemBorder")
                .ToList();

            if (borders.Count == 0) return;

            for (int i = 0; i < borders.Count; i++)
            {
                var border = borders[i];
                bool isSelected = i < ViewModel.Files.Count && ViewModel.SelectedFiles.Contains(ViewModel.Files[i]);
                bool isCurrent = i == _selectedIndex && ViewModel.Files[i].IsDirectory;

                if (isCurrent)
                {
                    border.Background = Brushes.Gray;
                    border.BringIntoView();
                }
                else if (isSelected)
                    border.Background = Brushes.DimGray;
                else
                    border.Background = Brushes.Transparent;
            }
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);

            if (ViewModel != null)
            {
                _ = ViewModel.InitializeAsync();
                _selectedIndex = 0;
                Dispatcher.UIThread.Post(() => UpdateSelection(), DispatcherPriority.Loaded);
            }
        }

        private void OnCancelClick(object? sender, RoutedEventArgs e)
        {
            Cancelled?.Invoke(this, EventArgs.Empty);

            Hide(HiddenState.Cancel);
        }

        private async void OnFileTapped(object? sender, TappedEventArgs e)
        {
            if (sender is Border border && border.DataContext is FileItem item)
            {
                var index = ViewModel?.Files?.IndexOf(item) ?? -1;
                if (index >= 0)
                {
                    _selectedIndex = index;
                    UpdateSelection();

                    if (item.IsDirectory)
                    {
                        await ViewModel!.OnItemTapped(item);
                        _selectedIndex = 0;
                        Dispatcher.UIThread.Post(() => UpdateSelection(), DispatcherPriority.Loaded);
                    }
                    else
                    {
                        await ViewModel!.OnItemTapped(item);
                        UpdateSelection();
                    }
                }
            }
        }

        private async void OnBreadcrumbClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is BreadcrumbItem item && ViewModel != null)
            {
                await ViewModel.OnBreadcrumbTapped(item);
                _selectedIndex = 0;
                Dispatcher.UIThread.Post(() => UpdateSelection(), DispatcherPriority.Loaded);
            }
        }

        private async void OnItemLoaded(object? sender, RoutedEventArgs e)
        {
            if (sender is Border border && border.DataContext is FileItem item && ViewModel != null)
                await ViewModel.LoadThumbnailForItem(item);
        }

        private void OnConfirmClick(object? sender, RoutedEventArgs e)
        {
            var paths = ViewModel?.GetSelectedFilePaths();
            FilesSelected?.Invoke(this, paths);
            Hide(HiddenState.Close);
        }
    }
}