using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    public interface IWindow
    {
        WorkTogetherContext Context { get; }
        void Logout();
        void SetPage(IPage page);
    }

    public interface IWindow<U> : IWindow
        where U : User
    {
        U User { get; }
    }
}