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
    public partial class TechnicianList : UserControl, IList<Technician>
    {
        private PageList _page;
        private EntityRepository<Technician> _repository;

        PageList IList<Technician>.Page => _page;
        EntityRepository<Technician> IList<Technician>.Repository => _repository;


        private Technician _data;
        public Technician Selected_Data => _data;

        public TechnicianList(PageList page)
        {
            _page = page;
            _data = new Technician();
            _repository = new TechnicianRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Technician;

            if (_data != null)
                _page.SetSelectedData<Technician>(_data);
        }

        public void Load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
