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
using CompanyData = WorkTogether.Data.Models.Company;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Company.xaml
    /// </summary>
    public partial class Company : UserControl, IList<CompanyData>
    {
        private PageList _page;
        PageList IList<CompanyData>.page => _page;

        private CompanyData _data;
        public CompanyData Selected_Data => _data;

        public Company(PageList page)
        {
            _page = page;
            _data = new CompanyData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as CompanyData;

            if (_data != null)
                _page.setSelectedData<CompanyData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.CompanySet.ToList();
        }
    }
}
