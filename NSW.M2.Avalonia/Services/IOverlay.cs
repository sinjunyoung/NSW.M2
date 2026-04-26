using NSW.M2.Avalonia.Enums;

namespace NSW.M2.Avalonia.Services;

public interface IOverlay
{
    void Show();

    void Hide(HiddenState state);

    bool Visible { get; }
}
