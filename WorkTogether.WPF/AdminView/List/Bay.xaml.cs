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
using BayData = WorkTogether.Data.Models.Bay;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Bay.xaml
    /// </summary>
    public partial class Bay : UserControl, IList<BayData>
    {
        private PageList _page;
        PageList IList<BayData>.page => _page;

        private BayData _data;
        public BayData Selected_Data => _data;

        public Bay(PageList page)
        {
            _page = page;
            _data = new BayData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as BayData;

            if (_data != null)
                _page.setSelectedData<BayData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.BaySet
                .Include(b => b.Units)
                .ToList();
        }
    }
}
