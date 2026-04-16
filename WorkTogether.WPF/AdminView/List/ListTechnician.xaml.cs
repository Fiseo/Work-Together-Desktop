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
    /// Logique d'interaction pour Technician.xaml
    /// </summary>
    public partial class ListTechnician : UserControl, IList<Technician>
    {
        private PageList _page;
        private EntityRepository<Technician> _repository;

        PageList IList<Technician>.page => _page;
        EntityRepository<Technician> IList<Technician>.repository => _repository;


        private Technician _data;
        public Technician Selected_Data => _data;

        public ListTechnician(PageList page)
        {
            _page = page;
            _data = new Technician();
            _repository = new TechnicianRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Technician;

            if (_data != null)
                _page.setSelectedData<Technician>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
