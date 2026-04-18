using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    public interface IWindow
    {
        WorkTogetherContext context { get; }
        void logout();
    }

    public interface IWindow<U> : IWindow
        where U : User
    {
        U user { get; }
    }
}