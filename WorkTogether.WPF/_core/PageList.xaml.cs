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
        
        public IWindow Window {  get; }
        private object? _list = null;
        private object? _form = null;

        public PageList(string titre, IWindow window)
        {
            InitializeComponent();
            TitleLabel.Text = titre;
            Window = window;

        }

        public void SetList<E>(IList<E> list) where E : DbEntity
        {
            _list = list;
            ListFrame.Content = list;
        }

        public IList<E>? GetList<E>() where E : DbEntity
        {
            if (_list == null)
                return null;
            return (IList<E>)_list;
        }

        public void SetForm<E>(IForm<E> form) where E : DbEntity
        {
            _form = form;
            FormFrame.Content = form;
        }

        public IForm<E>? GetForm<E>() where E : DbEntity
        {
            if (_form == null)
                return null;
            return (IForm<E>)_form;
        }

        public void SetSelectedData<E>(E entity) where E : DbEntity
        {
            IForm<E>? f = GetForm<E>();
            if (f != null)
                f.SelectedData = entity;
        }
    }
}
