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
using BookingData = WorkTogether.Data.Models.Booking;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Booking.xaml
    /// </summary>
    public partial class Booking : UserControl, IList<BookingData>
    {
        private PageList _page;
        private EntityRepository<BookingData> _repository;
        PageList IList<BookingData>.page => _page;
        EntityRepository<BookingData> IList<BookingData>.repository => _repository;


        private BookingData _data;
        public BookingData Selected_Data => _data;

        public Booking(PageList page)
        {
            _page = page;
            _data = new BookingData();
            _repository = new BookingRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as BookingData;

            if (_data != null)
                _page.setSelectedData<BookingData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
