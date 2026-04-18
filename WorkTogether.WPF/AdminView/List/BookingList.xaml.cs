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
    /// Logique d'interaction pour Booking.xaml
    /// </summary>
    public partial class BookingList : UserControl, IList<Booking>
    {
        private PageList _page;
        private EntityRepository<Booking> _repository;
        PageList IList<Booking>.Page => _page;
        EntityRepository<Booking> IList<Booking>.Repository => _repository;


        private Booking _data;
        public Booking Selected_Data => _data;

        public BookingList(PageList page)
        {
            _page = page;
            _data = new Booking();
            _repository = new BookingRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Booking;

            if (_data != null)
                _page.SetSelectedData<Booking>(_data);
        }

        public void Load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
