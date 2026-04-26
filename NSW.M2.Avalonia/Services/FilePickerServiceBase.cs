using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Services;

public abstract class FilePickerServiceBase : IFilePickerService
{
    protected readonly IStorageProvider _storageProvider;
    protected FilePickerServiceBase(IStorageProvider storageProvider)
    {
        _storageProvider = storageProvider;
    }

    public abstract Task<IEnumerable<string>> PickFilesAsync(string title, string initialDirectory, FileFilterOptions filterOptions);


    public abstract List<FilePickerFileType> ProcessFileTypes(List<FilePickerFileType> fileTypes);
}