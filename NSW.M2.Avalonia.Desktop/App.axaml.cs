using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NSW.M2.Avalonia.ViewModels;
using NSW.M2.Avalonia.Views;
using System.Globalization;

namespace NSW.M2.Avalonia.Desktop;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);

        //CultureInfo.CurrentUICulture = new CultureInfo("en-US");
        //CultureInfo.CurrentUICulture = new CultureInfo("ja-JP");
        //CultureInfo.CurrentUICulture = new CultureInfo("de-DE");
    }

    public override void OnFrameworkInitializationCompleted()
    {
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