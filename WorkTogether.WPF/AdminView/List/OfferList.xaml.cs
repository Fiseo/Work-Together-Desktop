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
    /// Logique d'interaction pour Offer.xaml
    /// </summary>
    public partial class OfferList : UserControl, IList<Offer>
    {
        private PageList _page;
        private OfferRepository _repository;

        PageList IList<Offer>.page => _page;
        EntityRepository<Offer> IList<Offer>.repository => _repository;


        private Offer _data;
        public Offer Selected_Data => _data;

        public OfferList(PageList page)
        {
            _page = page;
            _data = new Offer();
            _repository = new OfferRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Offer;

            if (_data != null)
                _page.setSelectedData<Offer>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAllActive();
        }
    }
}
