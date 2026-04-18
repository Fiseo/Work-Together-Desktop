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
        public User User { get; }
        public WorkTogetherContext Context { get; }
        public AdminWindow(User user)
        {
            User = user;
            Context = new WorkTogetherContext();
            InitializeComponent();
            usernameLabel.Text = user.Username;
            mainFrame.Content = new Read(this);
        }

        public AdminWindow(User user, WorkTogetherContext context)
        {
            User = user;
            Context = context;
            InitializeComponent();
            usernameLabel.Text = user.Username;
            mainFrame.Content = new Read(this);
        }

        public void Logout()
        {
            var main = new MainWindow(Context);
            main.Show();
            Close();
        }

        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "dashboard";

            switch (tag)
            {
                case "read":
                    mainFrame.Content = new Read(this);
                    break;
                case "write":
                    mainFrame.Content = new Write(this);
                    break;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }
    }
}
