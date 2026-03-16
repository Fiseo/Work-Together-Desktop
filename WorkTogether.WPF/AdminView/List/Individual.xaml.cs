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
using IndividualData = WorkTogether.Data.Models.Individual;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Individual.xaml
    /// </summary>
    public partial class Individual : UserControl, IList<IndividualData>
    {
        private PageList _page;
        PageList IList<IndividualData>.page => _page;

        private IndividualData _data;
        public IndividualData Selected_Data => _data;

        public Individual(PageList page)
        {
            _page = page;
            _data = new IndividualData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as IndividualData;

            if (_data != null)
                _page.setSelectedData<IndividualData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.IndividualSet
                .Include(i => i.Civility)
                .ToList();
        }
    }
}
