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
using WorkTogether.WPF.AdminView.WritePage;

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
                    _window.mainFrame.Content = new Civility(_window);
                    break;
                case "offer":
                    //_window.mainFrame.Content = new Offer(_window);
                    break;
                case "serviceCall":
                    //_window.mainFrame.Content = new ServiceCall(_window);
                    break;
            }
        }
    }
}
