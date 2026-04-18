using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    public interface IWindow
    {
        WorkTogetherContext Context { get; }
        void Logout();
    }

    public interface IWindow<U> : IWindow
        where U : User
    {
        U User { get; }
    }
}