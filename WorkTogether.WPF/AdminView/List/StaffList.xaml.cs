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
using WorkTogether.Data.Repository;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour StaffList.xaml
    /// </summary>
    public partial class StaffList : UserControl, IList<Staff>
    {
        private PageList _page;
        private EntityRepository<Staff> _repository;
        PageList IList<Staff>.Page => _page;
        EntityRepository<Staff> IList<Staff>.Repository => _repository;


        private Staff _data;
        public Staff Selected_Data => _data;

        public StaffList(PageList page)
        {
            _page = page;
            _data = new Technician();
            _repository = new StaffRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Staff;

            if (_data != null)
                _page.SetSelectedData<Staff>(_data);
        }

        public void Load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
