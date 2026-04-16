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
                    //_window.mainFrame.Content = new Bay(_window);
                    break;
                case "civility":
                    PageList page = new PageList("Modification des Civilités", _window);
                    page.setList<Data.Models.Civility>(new List.Civility(page));
                    page.setForm<Data.Models.Civility>(new Form.Civility(page));
                    _window.mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Modification des Offres", _window);
                    page.setList<Data.Models.Offer>(new List.Offer(page));
                    page.setForm<Data.Models.Offer>(new Form.Offer(page));
                    _window.mainFrame.Content = page;
                    break;
                case "serviceCall":
                    page = new PageList("Modification des Civilités", _window);
                    page.setList<Data.Models.ServiceCallType>(new List.ServiceCallType(page));
                    page.setForm<Data.Models.ServiceCallType>(new Form.ServiceCallType(page));
                    _window.mainFrame.Content = page;
                    break;
            }
        }
    }
}
