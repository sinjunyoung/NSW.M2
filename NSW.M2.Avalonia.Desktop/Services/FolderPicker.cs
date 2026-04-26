using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Services;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Desktop.Services;

public class FolderPicker : IFolderPicker
{
    public async Task<string?> PickFolderAsync(string title, string? defaultPath = null)
    {
        var mainWindow = (global::Avalonia.Application.Current?.ApplicationLifetime as global::Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime)?.MainWindow;

        if (mainWindow == null)
            return null;

        var folders = await mainWindow.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
        {
            Title = title,
            AllowMultiple = false
        });

        return folders.Count > 0 ? folders[0].TryGetLocalPath() : null;
    }
}