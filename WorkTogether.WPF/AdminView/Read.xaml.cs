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
                    //_window.mainFrame.Content = new Bay(_window);
                    break;
                case "serviceCall":
                    //_window.mainFrame.Content = new ServiceCall(_window);
                    break;
                case "booking":
                    //_window.mainFrame.Content = new Booking(_window);
                    break;
                case "user":
                    //_window.mainFrame.Content = new User(_window);
                    break;
                case "technician":
                    //_window.mainFrame.Content = new Technician(_window);
                    break;
                case "individual":
                    //_window.mainFrame.Content = new Individual(_window);
                    break;
                case "unit":
                    //_window.mainFrame.Content = new Unit(_window);
                    break;
                case "serviceCallType":
                    //_window.mainFrame.Content = new ServiceCallType(_window);
                    break;
                case "offer":
                    //_window.mainFrame.Content = new Offer(_window);
                    break;
                case "civility":
                    PageList page = new PageList("Liste des Civilités", _window);
                    page.setList<Data.Models.Civility>(new Civility(page));
                    _window.mainFrame.Content = page;
                    break;
                case "accountant":
                    //_window.mainFrame.Content = new Accountant(_window);
                    break;
                case "company":
                    //_window.mainFrame.Content = new Company(_window);
                    break;
            }
        }
    }
}
