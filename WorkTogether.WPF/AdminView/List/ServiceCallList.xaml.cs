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
    /// Logique d'interaction pour ServiceCall.xaml
    /// </summary>
    public partial class ServiceCallList : UserControl, IList<ServiceCall>
    {
        private PageList _page;
        private EntityRepository<ServiceCall> _repository;

        PageList IList<ServiceCall>.page => _page;
        EntityRepository<ServiceCall> IList<ServiceCall>.repository => _repository;


        private ServiceCall _data;
        public ServiceCall Selected_Data => _data;

        public ServiceCallList(PageList page)
        {
            _page = page;
            _data = new ServiceCall();
            _repository = new ServiceCallRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as ServiceCall;

            if (_data != null)
                _page.setSelectedData<ServiceCall>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
