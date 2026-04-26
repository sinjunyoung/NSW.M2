using System.Threading.Tasks;

namespace NSW.M2.Avalonia.Services;

public interface IFolderPicker
{
    Task<string?> PickFolderAsync(string title, string? defaultPath = null);
}