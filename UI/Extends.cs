using System.Windows.Threading;

namespace NSW.Core.UI;

public static class Extends
{ 
    public static void AutoResizeColumns(this System.Windows.Controls.GridView gridView)
    {
        Dispatcher.CurrentDispatcher.InvokeAsync(() =>
        {
            foreach (var col in gridView.Columns)
            {
                col.Width = double.NaN;
                col.Width = col.ActualWidth;
                col.Width = double.NaN;
            }
        }, DispatcherPriority.Loaded);
    }
}