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
using TechnicianData = WorkTogether.Data.Models.Technician;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Technician.xaml
    /// </summary>
    public partial class Technician : UserControl, IList<TechnicianData>
    {
        private PageList _page;
        private EntityRepository<TechnicianData> _repository;

        PageList IList<TechnicianData>.page => _page;
        EntityRepository<TechnicianData> IList<TechnicianData>.repository => _repository;


        private TechnicianData _data;
        public TechnicianData Selected_Data => _data;

        public Technician(PageList page)
        {
            _page = page;
            _data = new TechnicianData();
            _repository = new TechnicianRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as TechnicianData;

            if (_data != null)
                _page.setSelectedData<TechnicianData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
