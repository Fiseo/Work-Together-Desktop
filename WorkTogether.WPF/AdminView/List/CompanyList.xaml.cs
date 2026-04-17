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
    /// Logique d'interaction pour Company.xaml
    /// </summary>
    public partial class CompanyList : UserControl, IList<Company>
    {
        private PageList _page;
        private EntityRepository<Company> _repository;

        PageList IList<Company>.page => _page;
        EntityRepository<Company> IList<Company>.repository => _repository;


        private Company _data;
        public Company Selected_Data => _data;

        public CompanyList(PageList page)
        {
            _page = page;
            _data = new Company();
            _repository = new CompanyRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Company;

            if (_data != null)
                _page.setSelectedData<Company>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
