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

        private void click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "dashboard";

            switch (tag)
            {
                case "bay":
                    PageList? page = new PageList("Liste des Baies", _window);
                    page.setList<Bay>(new ListBay(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Liste des Interventions", _window);
                    page.setList<ServiceCall>(new ListServiceCall(page));
                    _window.mainFrame.Content = page;
                    break;
                case "booking":
                    page = new PageList("Liste des Réservations", _window);
                    page.setList<Booking>(new ListBooking(page));
                    _window.mainFrame.Content = page;
                    break;
                case "user":
                    page = new PageList("Liste des Utilisateurs", _window);
                    page.setList<User>(new ListUser(page));
                    _window.mainFrame.Content = page;
                    break;
                case "technician":
                    page = new PageList("Liste des Techniciens", _window);
                    page.setList<Technician>(new ListTechnician(page));
                    _window.mainFrame.Content = page;
                    break;
                case "individual":
                    page = new PageList("Liste des Particuliers", _window);
                    page.setList<Individual>(new ListIndividual(page));
                    _window.mainFrame.Content = page;
                    break;
                case "unit":
                    page = new PageList("Liste des Unités", _window);
                    page.setList<Unit>(new ListUnit(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCallType":
                    page = new PageList("Liste des Types d'interventions", _window);
                    page.setList<ServiceCallType>(new ListServiceCallType(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Liste des Offres", _window);
                    page.setList<Offer>(new ListOffer(page));
                    _window.mainFrame.Content = page;
                    break;
                case "civility":
                    page = new PageList("Liste des Civilités", _window);
                    page.setList<Civility>(new ListCivility(page));
                    _window.mainFrame.Content = page;
                    break;
                case "accountant":
                    page = new PageList("Liste des Comptables", _window);
                    page.setList<Accountant>(new ListAccountant(page));
                    _window.mainFrame.Content = page;
                    break;
                case "company":
                    page = new PageList("Liste des Entreprises", _window);
                    page.setList<Company>(new ListCompany(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
