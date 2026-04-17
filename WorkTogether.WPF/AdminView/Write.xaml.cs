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

        private void click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "dashboard";

            switch (tag)
            {
                case "user":
                    //_window.mainFrame.Content = new User(_window);
                    break;
                case "bay":
                    PageList page = new PageList("Modification des Baies", _window);
                    page.setList<Bay>(new List.ListBay(page));
                    page.setForm<Bay>(new Form.FormBay(page));
                    _window.mainFrame.Content = page;
                    break;
                case "civility":
                    page = new PageList("Modification des Civilités", _window);
                    page.setList<Civility>(new List.ListCivility(page));
                    page.setForm<Civility>(new Form.FormCivility(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Modification des Offres", _window);
                    page.setList<Offer>(new List.ListOffer(page));
                    page.setForm<Offer>(new Form.FormOffer(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Modification des Civilités", _window);
                    page.setList<ServiceCallType>(new List.ListServiceCallType(page));
                    page.setForm<ServiceCallType>(new Form.FormServiceCallType(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
