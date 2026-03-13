using Google.Protobuf.WellKnownTypes;
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
using System.Windows.Shapes;
using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF.AdminView
{
    /// <summary>
    /// Logique d'interaction pour AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window, IWindow<User>
    {
        public User user { get; }
        public WorkTogetherContext context { get; }
        public AdminWindow(User user)
        {
            this.user = user;
            context = new WorkTogetherContext();
            InitializeComponent();
            usernameLabel.Text = user.Username;
            mainFrame.Content = new Read();
        }

        public AdminWindow(User user, WorkTogetherContext context)
        {
            this.user = user;
            this.context = context;
            InitializeComponent();
            usernameLabel.Text = user.Username;
            mainFrame.Content = new Read();
        }

        public void logout()
        {
            var main = new MainWindow(context);
            main.Show();
            Close();
        }

        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "dashboard";

            switch (tag)
            {
                case "read":
                    mainFrame.Content = new Read();
                    break;
                case "write":
                    mainFrame.Content = new Write();
                    break;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            logout();
        }
    }
}
