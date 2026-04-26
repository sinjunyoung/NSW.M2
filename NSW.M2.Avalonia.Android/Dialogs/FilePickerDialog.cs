using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Media;
using Avalonia.Platform.Storage;
using Avalonia.Threading;
using NSW.M2.Avalonia.Android.ViewModels;
using NSW.M2.Avalonia.Android.Views;
using NSW.M2.Avalonia.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UltimateEnd.Android.Dialogs
{
    public class FilePickerDialog
    {
        public static bool IsOpen => _currentOverlay != null;

        private static Grid? _currentOverlay;
        private static Control? _previousFocusedControl;

        public static async Task<List<string>?> ShowAsync(string title, string[] extensions, IStorageProvider storageProvider, string? initialDirectory = null)
        {
            var tcs = new TaskCompletionSource<List<string>?>();

            var viewModel = new CustomFilePickerViewModel(storageProvider, extensions, title, initialDirectory);
            var control = new CustomFilePickerControl
            {
                DataContext = viewModel
            };

            control.FilesSelected += (s, paths) =>
            {
                CloseDialog();
                tcs.TrySetResult(paths);
            };

            control.Cancelled += (s, e) =>
            {
                CloseDialog();
                tcs.TrySetResult(null);
            };

            control.Hidden += (s, e) =>
            {
                if (e.State == HiddenState.Cancel || e.State == HiddenState.Close)
                {
                    CloseDialog();
                    if (!tcs.Task.IsCompleted)
                        tcs.TrySetResult(null);
                }
            };

            ShowDialog(control);

            return await tcs.Task;
        }

        private static void ShowDialog(CustomFilePickerControl content)
        {
            if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
            {
                var mainView = singleView.MainView;

                Panel? panel = null;

                if (mainView is UserControl userControl)
                    panel = userControl.Content as Panel;

                if (panel == null && mainView is Panel directPanel)
                    panel = directPanel;

                if (panel == null) return;

                var topLevel = TopLevel.GetTopLevel(mainView);

                _previousFocusedControl = topLevel?.FocusManager?.GetFocusedElement() as Control;

                var overlayGrid = new Grid
                {
                    Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)),
                    ZIndex = 9999,
                    [Grid.RowProperty] = 0,
                    [Grid.RowSpanProperty] = int.MaxValue,
                    [Grid.ColumnProperty] = 0,
                    [Grid.ColumnSpanProperty] = int.MaxValue
                };

                var dialog = new Border
                {
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(12),
                    Margin = new Thickness(20),
                    BoxShadow = new BoxShadows(
                        new BoxShadow
                        {
                            OffsetY = 4,
                            Blur = 16,
                            Color = Color.FromArgb(64, 0, 0, 0)
                        }),
                    Child = content
                };

                overlayGrid.Children.Add(dialog);

                overlayGrid.PointerPressed += (s, e) =>
                {
                    if (e.Source == overlayGrid)
                    {
                        content.Hide(HiddenState.Cancel);
                        e.Handled = true;
                    }
                };

                overlayGrid.ZIndex = 9999;
                panel.Children.Add(overlayGrid);

                Dispatcher.UIThread.Post(() => content.Show(), DispatcherPriority.Loaded);

                _currentOverlay = overlayGrid;
            }
        }

        private static void CloseDialog()
        {
            if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
            {
                var mainView = singleView.MainView;

                if (mainView is UserControl userControl && userControl.Content is Panel panel)
                {
                    if (_currentOverlay != null)
                        panel.Children.Remove(_currentOverlay);

                    _currentOverlay = null;
                }

                var controlToFocus = _previousFocusedControl;
                _previousFocusedControl = null;

                if (controlToFocus != null)
                    Dispatcher.UIThread.Post(() => controlToFocus.Focus(), DispatcherPriority.Loaded);
            }
        }
    }
}