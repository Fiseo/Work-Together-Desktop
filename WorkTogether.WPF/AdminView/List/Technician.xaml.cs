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
using TechnicianData = WorkTogether.Data.Models.Technician;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Technician.xaml
    /// </summary>
    public partial class Technician : UserControl, IList<TechnicianData>
    {
        private PageList _page;
        PageList IList<TechnicianData>.page => _page;

        private TechnicianData _data;
        public TechnicianData Selected_Data => _data;

        public Technician(PageList page)
        {
            _page = page;
            _data = new TechnicianData();
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
            DataGrid.ItemsSource = _page.window.context.TechnicianSet
                .Include(t => t.Civility)
                .ToList();
        }
    }
}
