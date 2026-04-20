using System.Windows;

namespace NSW.M2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var culture = System.Globalization.CultureInfo.CurrentUICulture;

        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;

        M2.Properties.Resources.Culture = culture;

        // 영어 (기본 fallback)
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("en-US");

        // 한국어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("ko-KR");

        // 일본어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("ja-JP");

        // 중국어 간체
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("zh-CN");

        // 중국어 번체
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("zh-TW");

        // 프랑스어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("fr-FR");

        // 독일어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("de-DE");

        // 스페인어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("es-ES");

        // 이탈리아어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("it-IT");

        // 포르투갈어(브라질)
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("pt-BR");

        // 러시아어
        //M2.Properties.Resources.Culture = new System.Globalization.CultureInfo("ru-RU");
        base.OnStartup(e);
    }
}