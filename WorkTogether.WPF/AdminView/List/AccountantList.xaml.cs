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
    /// Logique d'interaction pour Accountant.xaml
    /// </summary>
    public partial class AccountantList : UserControl, IList<Accountant>
    {
        private PageList _page;
        private EntityRepository<Accountant> _repository;
        PageList IList<Accountant>.page => _page;
        EntityRepository<Accountant> IList<Accountant>.repository => _repository;


        private Accountant _data;
        public Accountant Selected_Data => _data;

        public AccountantList(PageList page)
        {
            _page = page;
            _data = new Accountant();
            _repository = new AccountantRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Accountant;

            if (_data != null)
                _page.setSelectedData<Accountant>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
