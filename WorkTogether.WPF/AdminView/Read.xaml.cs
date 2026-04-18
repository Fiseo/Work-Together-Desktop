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
using WorkTogether.Data.Models;
using WorkTogether.WPF.AdminView.List;

namespace WorkTogether.WPF.AdminView
{
    /// <summary>
    /// Logique d'interaction pour Read.xaml
    /// </summary>
    public partial class Read : UserControl
    {
        private AdminWindow _window;
        public Read(AdminWindow parent)
        {
            _window = parent;
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "dashboard";
            PageList? page = null;

            switch (tag)
            {
                case "bay":
                    page = new PageList("Liste des Baies", _window);
                    page.SetList<Bay>(new BayList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Liste des Interventions", _window);
                    page.SetList<ServiceCall>(new ServiceCallList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "booking":
                    page = new PageList("Liste des Réservations", _window);
                    page.SetList<Booking>(new BookingList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "user":
                    page = new PageList("Liste des Utilisateurs", _window);
                    page.SetList<User>(new UserList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "technician":
                    page = new PageList("Liste des Techniciens", _window);
                    page.SetList<Technician>(new TechnicianList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "individual":
                    page = new PageList("Liste des Particuliers", _window);
                    page.SetList<Individual>(new IndividualList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "unit":
                    page = new PageList("Liste des Unités", _window);
                    page.SetList<Unit>(new UnitList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCallType":
                    page = new PageList("Liste des Types d'interventions", _window);
                    page.SetList<ServiceCallType>(new ServiceCallTypeList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Liste des Offres", _window);
                    page.SetList<Offer>(new OfferList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "civility":
                    page = new PageList("Liste des Civilités", _window);
                    page.SetList<Civility>(new CivilityList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "accountant":
                    page = new PageList("Liste des Comptables", _window);
                    page.SetList<Accountant>(new AccountantList(page));
                    _window.mainFrame.Content = page;
                    break;
                case "company":
                    page = new PageList("Liste des Entreprises", _window);
                    page.SetList<Company>(new CompanyList(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
