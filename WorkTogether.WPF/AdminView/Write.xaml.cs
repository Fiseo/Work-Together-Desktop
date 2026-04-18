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
using WorkTogether.WPF.AdminView.Form;
using WorkTogether.WPF.AdminView.List;

namespace WorkTogether.WPF.AdminView
{
    /// <summary>
    /// Logique d'interaction pour Write.xaml
    /// </summary>
    public partial class Write : UserControl
    {
        private AdminWindow _window;
        public Write(AdminWindow parent)
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
                case "user":
                    //_window.mainFrame.Content = new User(_window);
                    break;
                case "bay":
                    page = new PageList("Modification des Baies", _window);
                    page.SetList<Bay>(new BayList(page));
                    page.SetForm<Bay>(new BayForm(page));
                    _window.mainFrame.Content = page;
                    break;
                case "civility":
                    page = new PageList("Modification des Civilités", _window);
                    page.SetList<Civility>(new CivilityList(page));
                    page.SetForm<Civility>(new CivilityForm(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Modification des Offres", _window);
                    page.SetList<Offer>(new OfferList(page));
                    page.SetForm<Offer>(new OfferForm(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Modification des Civilités", _window);
                    page.SetList<ServiceCallType>(new ServiceCallTypeList(page));
                    page.SetForm<ServiceCallType>(new ServiceCallTypeForm(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
