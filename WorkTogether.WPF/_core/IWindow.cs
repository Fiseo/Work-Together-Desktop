using System.Windows;
using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF
{
    public interface IWindow<U>
        where U : User
    {
        U user { get;}
        WorkTogetherContext context { get; }
        void logout();
    }
}