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
    /// Logique d'interaction pour ServiceCallType.xaml
    /// </summary>
    public partial class ListServiceCallType : UserControl, IList<ServiceCallType>
    {
        private PageList _page;
        private EntityRepository<ServiceCallType> _repository;

        PageList IList<ServiceCallType>.page => _page;
        EntityRepository<ServiceCallType> IList<ServiceCallType>.repository => _repository;


        private ServiceCallType _data;
        public ServiceCallType Selected_Data => _data;

        public ListServiceCallType(PageList page)
        {
            _page = page;
            _data = new ServiceCallType();
            _repository = new ServiceCallTypeRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as ServiceCallType;

            if (_data != null)
                _page.setSelectedData<ServiceCallType>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
