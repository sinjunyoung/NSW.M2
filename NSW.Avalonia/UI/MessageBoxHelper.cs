using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using System.Threading.Tasks;
using Res = NSW.Core.Properties.Resources;

namespace NSW.Avalonia.UI;

public static class MessageBoxHelper
{
    public static async Task ShowInfo(string msg)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
        {
            ContentTitle = Res.Msg_Title_Info,
            ContentMessage = msg,
            ButtonDefinitions = ButtonEnum.Ok,
            Icon = Icon.Info,
            WindowStartupLocation = global::Avalonia.Controls.WindowStartupLocation.CenterOwner
        });
        await box.ShowAsync();
    }

    public static async Task ShowWarning(string msg)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
        {
            ContentTitle = Res.Msg_Title_Warning,
            ContentMessage = msg,
            ButtonDefinitions = ButtonEnum.Ok,
            Icon = Icon.Warning,
            WindowStartupLocation = global::Avalonia.Controls.WindowStartupLocation.CenterOwner
        });
        await box.ShowAsync();
    }

    public static async Task ShowError(string msg)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
        {
            ContentTitle = Res.Msg_Title_Error,
            ContentMessage = msg,
            ButtonDefinitions = ButtonEnum.Ok,
            Icon = Icon.Error,
            WindowStartupLocation = global::Avalonia.Controls.WindowStartupLocation.CenterOwner
        });
        await box.ShowAsync();
    }

    public static async Task<bool> ShowQuestion(string msg)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams
        {
            ContentTitle = Res.Msg_Title_Question,
            ContentMessage = msg,
            ButtonDefinitions = ButtonEnum.YesNo,
            Icon = Icon.Question,
            WindowStartupLocation = global::Avalonia.Controls.WindowStartupLocation.CenterOwner
        });

        var result = await box.ShowAsync();
        return result == ButtonResult.Yes;
    }
}