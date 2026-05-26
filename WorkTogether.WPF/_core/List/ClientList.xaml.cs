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

namespace WorkTogether.WPF.List
{
    /// <summary>
    /// Logique d'interaction pour StaffList.xaml
    /// </summary>
    public partial class ClientList : UserControl, IList<Client>
    {
        private PageList _page;
        private EntityRepository<Client> _repository;
        PageList IList<Client>.Page => _page;
        EntityRepository<Client> IList<Client>.Repository => _repository;


        private Client _data;
        public Client Selected_Data => _data;

        public ClientList(PageList page)
        {
            _page = page;
            _data = new Individual();
            _repository = new ClientRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Client;

            if (_data != null)
                _page.SetSelectedData<Client>(_data);
        }

        public void Load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }

        public void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            Client client = button.Tag as Client;
            
            PageList page = new PageList("Liste des Réservations de " + client.Label, _page.Window); 
            page.SetList(new BookingList(page, client));
            ((IPage)_page).SetPage(page);
        }
    }
}
