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
                    page.setList<Data.Models.Bay>(new Bay(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Liste des Interventions", _window);
                    page.setList<Data.Models.ServiceCall>(new ServiceCall(page));
                    _window.mainFrame.Content = page;
                    break;
                case "booking":
                    page = new PageList("Liste des Réservations", _window);
                    page.setList<Data.Models.Booking>(new Booking(page));
                    _window.mainFrame.Content = page;
                    break;
                case "user":
                    page = new PageList("Liste des Utilisateurs", _window);
                    page.setList<Data.Models.User>(new User(page));
                    _window.mainFrame.Content = page;
                    break;
                case "technician":
                    page = new PageList("Liste des Techniciens", _window);
                    page.setList<Data.Models.Technician>(new Technician(page));
                    _window.mainFrame.Content = page;
                    break;
                case "individual":
                    page = new PageList("Liste des Particuliers", _window);
                    page.setList<Data.Models.Individual>(new Individual(page));
                    _window.mainFrame.Content = page;
                    break;
                case "unit":
                    page = new PageList("Liste des Unités", _window);
                    page.setList<Data.Models.Unit>(new Unit(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCallType":
                    page = new PageList("Liste des Types d'interventions", _window);
                    page.setList<Data.Models.ServiceCallType>(new ServiceCallType(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Liste des Offres", _window);
                    page.setList<Data.Models.Offer>(new Offer(page));
                    _window.mainFrame.Content = page;
                    break;
                case "civility":
                    page = new PageList("Liste des Civilités", _window);
                    page.setList<Data.Models.Civility>(new Civility(page));
                    _window.mainFrame.Content = page;
                    break;
                case "accountant":
                    page = new PageList("Liste des Comptables", _window);
                    page.setList<Data.Models.Accountant>(new Accountant(page));
                    _window.mainFrame.Content = page;
                    break;
                case "company":
                    page = new PageList("Liste des Entreprises", _window);
                    page.setList<Data.Models.Company>(new Company(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
