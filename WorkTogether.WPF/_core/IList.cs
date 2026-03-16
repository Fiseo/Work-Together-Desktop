using System.Windows;
using WorkTogether.Data;

namespace WorkTogether.WPF
{
    public interface IList<E>
        where E : DbEntity
    {
        PageList page { get; }
        E Selected_Data { get; }
        void Data_Selected(object sender, RoutedEventArgs e);
        void load();
    }
}