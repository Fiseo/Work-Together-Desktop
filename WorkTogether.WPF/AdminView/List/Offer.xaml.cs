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
using OfferData = WorkTogether.Data.Models.Offer;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Offer.xaml
    /// </summary>
    public partial class Offer : UserControl, IList<OfferData>
    {
        private PageList _page;
        private OfferRepository _repository;

        PageList IList<OfferData>.page => _page;
        EntityRepository<OfferData> IList<OfferData>.repository => _repository;


        private OfferData _data;
        public OfferData Selected_Data => _data;

        public Offer(PageList page)
        {
            _page = page;
            _data = new OfferData();
            _repository = new OfferRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as OfferData;

            if (_data != null)
                _page.setSelectedData<OfferData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAllActive();
        }
    }
}
