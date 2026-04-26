using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Services;

public static class DialogHelper
{
    static IStorageProvider? StorageProvider;

    public static async Task<IEnumerable<string>> OpenFilesAsync(string initialDirectory, params List<FilePickerFileType> filters)
    {
        var storageProvider = GetStorageProvider();
        if (storageProvider == null)
            return [];

        var fileFilters = filters ?? [FilePickerFileTypes.All];
        var filePickerService = FilePickerServiceFactory.Create?.Invoke(storageProvider);
        if (filePickerService == null)
            return [];

        fileFilters = filePickerService.ProcessFileTypes(fileFilters);
        var filterOptions = new FileFilterOptions
        {
            DisplayName = fileFilters.FirstOrDefault()?.Name ?? "Select files",
            Extensions = fileFilters.FirstOrDefault()?.Patterns?
                .Select(p => p.Replace("*", string.Empty))
                .ToArray() ?? []
        };

        return await filePickerService.PickFilesAsync("Select files", initialDirectory, filterOptions);
    }

    private static IStorageProvider? GetStorageProvider()
    {
        if (StorageProvider != null)
            return StorageProvider;

        var lifetime = global::Avalonia.Application.Current?.ApplicationLifetime;
        if (lifetime is IClassicDesktopStyleApplicationLifetime desktop)
            StorageProvider = desktop.MainWindow?.StorageProvider;
        else if (lifetime is ISingleViewApplicationLifetime singleView)
            StorageProvider = TopLevel.GetTopLevel(singleView.MainView)?.StorageProvider;

        return StorageProvider;
    }

    public static void SetStorageProvider(IStorageProvider provider) => StorageProvider = provider;

    public static void ResetStorageProvider() => StorageProvider = null;
}