using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NSW.M2.Avalonia.Android.Models;

public class RangeObservableCollection<T> : ObservableCollection<T>
{
    private bool _suppressNotification = false;

    public void BeginUpdate() => _suppressNotification = true;

    public void EndUpdate()
    {
        _suppressNotification = false;

        OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(
            System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
    }

    protected override void OnCollectionChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (!_suppressNotification)
            base.OnCollectionChanged(e);
    }

    public void ReplaceAll(IEnumerable<T> items)
    {
        BeginUpdate();
        Clear();

        foreach (var item in items)
            Add(item);

        EndUpdate();
    }
}