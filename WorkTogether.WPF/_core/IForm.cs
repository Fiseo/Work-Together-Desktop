using System.Windows;
using WorkTogether.Data;

namespace WorkTogether.WPF
{
    public interface IForm<E>
        where E : DbEntity
    {
        PageList page { get; }
        E? SelectedData { get; set; }
        void reload();
        void Save_Click(object sender, RoutedEventArgs e);
        void loadList()
        {
            IList<E>? list = page.GetList<E>();
            if(list != null)
                list.load();
        }
    }
}