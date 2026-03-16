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
using ServiceCallData = WorkTogether.Data.Models.ServiceCall;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour ServiceCall.xaml
    /// </summary>
    public partial class ServiceCall : UserControl, IList<ServiceCallData>
    {
        private PageList _page;
        PageList IList<ServiceCallData>.page => _page;

        private ServiceCallData _data;
        public ServiceCallData Selected_Data => _data;

        public ServiceCall(PageList page)
        {
            _page = page;
            _data = new ServiceCallData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as ServiceCallData;

            if (_data != null)
                _page.setSelectedData<ServiceCallData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.ServiceCallSet
                .Include(s => s.Technician)
                .Include(s => s.Unit.Bay)
                .Include(s => s.Type)
                .ToList();
        }
    }
}
