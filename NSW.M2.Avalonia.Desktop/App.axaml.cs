using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NSW.M2.Avalonia.Desktop.Services;
using NSW.M2.Avalonia.Services;
using NSW.M2.Avalonia.ViewModels;
using NSW.M2.Avalonia.Views;

namespace NSW.M2.Avalonia.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        FilePickerServiceFactory.Create = (provider) => new FilePickerService(provider);
        FolderPickerFactory.Create = () => new FolderPicker();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

}