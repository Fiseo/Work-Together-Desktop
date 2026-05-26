using System.Windows;
using WorkTogether.Data;

namespace WorkTogether.WPF;

public interface IPage
{
    IWindow Window { get; }

    void SetPage(IPage page)
    {
        Window.SetPage(page);
    }
}