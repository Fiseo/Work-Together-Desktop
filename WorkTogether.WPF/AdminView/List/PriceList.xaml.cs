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
using WorkTogether.Data.Models;
using WorkTogether.Data.Repository;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour PriceList.xaml
    /// </summary>
    public partial class PriceList : UserControl, IList<Price>
    {
        private PageList _page;
        private EntityRepository<Price> _repository;

        PageList IList<Price>.Page => _page;
        EntityRepository<Price> IList<Price>.Repository => _repository;


        private Price _data;
        public Price Selected_Data => _data;

        public PriceList(PageList page)
        {
            _page = page;
            _data = new Price();
            _repository = new PriceRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Price;

            if (_data != null && _data.IsDeleteable())
                _page.SetSelectedData<Price>(_data);
        }

        public void Load()
        {
            List<Price> prices = _repository.FindAll();
            DataGrid.ItemsSource = prices;
        }
    }
}
