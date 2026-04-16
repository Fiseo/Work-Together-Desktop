using System.Windows;
using WorkTogether.Data;

namespace WorkTogether.WPF
{
    public interface IForm<E>
        where E : DbEntity
    {
        PageList page { get; }
        EntityRepository<E> repository { get; }
        E? SelectedData { get; set; }
        void reload();
        void clear();
        void Save_Click(object sender, RoutedEventArgs e);
        static void Static_Delete(IForm<E> Form)
        {
            if (Form.SelectedData == null)
                return;
            Form.repository.delete(Form.SelectedData);
            Form.clear();
        }
        void Delete_Click(object sender, RoutedEventArgs e) => Static_Delete(this);
        void Clear_Click(object sender, RoutedEventArgs e) => clear();
        void loadList()
        {
            IList<E>? list = page.GetList<E>();
            if(list != null)
                list.load();
        }
    }
}