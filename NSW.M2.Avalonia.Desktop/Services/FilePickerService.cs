using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Models;
using NSW.M2.Avalonia.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Desktop.Services;

public class FilePickerService(IStorageProvider storageProvider) : FilePickerServiceBase(storageProvider)
{
    public override async Task<IEnumerable<string>> PickFilesAsync(string title, string initialDirectory, FileFilterOptions filterOptions)
    {
        var fileType = new FilePickerFileType(filterOptions.DisplayName)
        {
            Patterns = filterOptions.FileNamePatterns ?? filterOptions.Extensions?.Select(ext => $"*{ext}").ToArray()
        };

        IStorageFolder? startLocation = null;
        if (!string.IsNullOrEmpty(initialDirectory))
        {
            if (!initialDirectory.StartsWith(@"\\") && Directory.Exists(initialDirectory))
                startLocation = await _storageProvider.TryGetFolderFromPathAsync(initialDirectory);
        }

        var files = await _storageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = title,
                AllowMultiple = true,
                FileTypeFilter = [fileType],
                SuggestedStartLocation = startLocation
            });

        return files.Select(f => f.Path.LocalPath);
    }

    public override List<FilePickerFileType> ProcessFileTypes(List<FilePickerFileType> fileTypes) => fileTypes;
}