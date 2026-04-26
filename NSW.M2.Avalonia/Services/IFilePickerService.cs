using Avalonia.Platform.Storage;
using NSW.M2.Avalonia.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Services;

public interface IFilePickerService
{
    Task<IEnumerable<string>> PickFilesAsync(string title, string initialDirectory, FileFilterOptions filterOptions);
    List<FilePickerFileType> ProcessFileTypes(List<FilePickerFileType> fileTypes);
}