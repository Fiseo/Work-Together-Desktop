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
using AccountantData = WorkTogether.Data.Models.Accountant;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Accountant.xaml
    /// </summary>
    public partial class Accountant : UserControl, IList<AccountantData>
    {
        private PageList _page;
        private EntityRepository<AccountantData> _repository;
        PageList IList<AccountantData>.page => _page;
        EntityRepository<AccountantData> IList<AccountantData>.repository => _repository;


        private AccountantData _data;
        public AccountantData Selected_Data => _data;

        public Accountant(PageList page)
        {
            _page = page;
            _data = new AccountantData();
            _repository = new AccountantRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as AccountantData;

            if (_data != null)
                _page.setSelectedData<AccountantData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
