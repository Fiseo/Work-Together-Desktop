using Microsoft.EntityFrameworkCore;
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
using WorkTogether.Data.Repository;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Bay.xaml
    /// </summary>
    public partial class BayList : UserControl, IList<Bay>
    {
        private PageList _page;
        private EntityRepository<Bay> _repository;
        PageList IList<Bay>.page => _page;
        EntityRepository<Bay> IList<Bay>.repository => _repository;


        private Bay _data;
        public Bay Selected_Data => _data;

        public BayList(PageList page)
        {
            _page = page;
            _data = new Bay();
            _repository = new BayRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Bay;

            if (_data != null)
                _page.setSelectedData<Bay>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
