using Avalonia.Controls;
using NSW.M2.Avalonia.Enums;
using NSW.M2.Avalonia.Services;
using System;
namespace NSW.M2.Avalonia.UI
{
    public abstract class BaseOverlay : UserControl, IOverlay
    {
        public abstract bool Visible { get; }

        public abstract void Hide(HiddenState state);

        public abstract void Show();

        public event EventHandler Showing;
        public event EventHandler<HiddenEventArgs> Hidden;
        public event EventHandler Click;

        protected virtual void OnShowing(EventArgs e) => Showing?.Invoke(this, e);

        protected virtual void OnHidden(HiddenEventArgs e)
        {
            Hidden?.Invoke(this, e);
        }

        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);

        protected virtual void MovePrevious() { }

        protected virtual void MoveNext() { }

        protected virtual void SelectCurrent() { }

    }

    public sealed class HiddenEventArgs : EventArgs
    {
        public static readonly new HiddenEventArgs Empty = new() { State = HiddenState.Close };

        public HiddenState State { get; set; }
    }
}