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
using ServiceCallTypeData = WorkTogether.Data.Models.ServiceCallType;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour ServiceCallType.xaml
    /// </summary>
    public partial class ServiceCallType : UserControl, IList<ServiceCallTypeData>
    {
        private PageList _page;
        private EntityRepository<ServiceCallTypeData> _repository;

        PageList IList<ServiceCallTypeData>.page => _page;
        EntityRepository<ServiceCallTypeData> IList<ServiceCallTypeData>.repository => _repository;


        private ServiceCallTypeData _data;
        public ServiceCallTypeData Selected_Data => _data;

        public ServiceCallType(PageList page)
        {
            _page = page;
            _data = new ServiceCallTypeData();
            _repository = new ServiceCallTypeRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as ServiceCallTypeData;

            if (_data != null)
                _page.setSelectedData<ServiceCallTypeData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
