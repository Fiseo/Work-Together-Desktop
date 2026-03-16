using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkTogether.Data;
using WorkTogether.Data.Models;
using WorkTogether.WPF.AdminView;

namespace WorkTogether.WPF
{
    /// <summary>
    /// Logique d'interaction pour PageList.xaml
    /// </summary>
    public partial class PageList : UserControl
    {
        
        public IWindow window {  get; }
        private object? list = null;
        private object? form = null;

        public PageList(string titre, IWindow window)
        {
            InitializeComponent();
            TitleLabel.Text = titre;
            this.window = window;

        }

        public void setList<E>(IList<E> list) where E : DbEntity
        {
            this.list = list;
            ListFrame.Content = list;
        }

        public IList<E>? GetList<E>() where E : DbEntity
        {
            if (list == null)
                return null;
            return (IList<E>)list;
        }

        public void setForm<E>(IForm<E> form) where E : DbEntity
        {
            this.form = form;
            FormFrame.Content = form;
        }

        public IForm<E>? GetForm<E>() where E : DbEntity
        {
            if (form == null)
                return null;
            return (IForm<E>)form;
        }

        public void setSelectedData<E>(E entity) where E : DbEntity
        {
            IForm<E>? f = GetForm<E>();
            if (f != null)
                f.SelectedData = entity;
        }
    }
}
