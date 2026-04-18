using System.Windows;
using WorkTogether.Data;

namespace WorkTogether.WPF
{
    public interface IForm
    {
        PageList Page { get; }
        void Reload();
        void Clear();
        void LoadList();
        void Save();
        void Delete();

    }

    public interface IForm<E>: IForm
        where E : DbEntity
    {
        EntityRepository<E> Repository { get; }
        E? SelectedData { get; set; }

        void IForm.LoadList()
        {
            IList<E>? list = Page.GetList<E>();
            if (list != null)
                list.Load();
        }

        void IForm.Delete()
        {
            if (SelectedData == null)
                return;
            Repository.Delete(SelectedData);
            Clear();
        }
    }
}