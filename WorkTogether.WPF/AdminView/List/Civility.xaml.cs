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
using CivilityData = WorkTogether.Data.Models.Civility;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class Civility : UserControl, IList<CivilityData>
    {
        private PageList _page;
        PageList IList<CivilityData>.page => _page;

        private CivilityData _data;
        public CivilityData Selected_Data => _data;

        public Civility(PageList page)
        {
            _page = page;
            _data = new CivilityData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as CivilityData;

            if (_data != null)
                _page.setSelectedData<CivilityData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.CivilitySet.ToList();
        }
    }
}
