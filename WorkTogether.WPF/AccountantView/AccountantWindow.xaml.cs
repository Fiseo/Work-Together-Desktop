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
using WorkTogether.WPF.List;

namespace WorkTogether.WPF.AccountantView
{
    /// <summary>
    /// Logique d'interaction pour AccountantWindow.xaml
    /// </summary>
    partial class AccountantWindow : Window, IWindow<Accountant>
    {
        public Accountant User { get; }
        public WorkTogetherContext Context { get; }

        public AccountantWindow(Accountant user, WorkTogetherContext context)
        {
            User = user;
            Context = context;
            InitializeComponent();
            usernameLabel.Text = user.Username;
            PageList page = new PageList("Liste des Clients", this);
            page.SetList(new ClientList(page));
            mainFrame.Content = page;
        }
        
        public AccountantWindow(Accountant user): this(user, new WorkTogetherContext())
        {
        }

        public void Logout()
        {
            var main = new MainWindow(Context);
            main.Show();
            Close();
        }

        public void SetPage(IPage page)
        {
            mainFrame.Content =  page;
        }

        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "client";

            PageList? page = null;

            switch (tag)
            {
                case "client":
                    page = new PageList("Liste des Clients", this);
                    page.SetList(new ClientList(page));
                    mainFrame.Content = page;
                    break;
                case "offer":
                    page = new PageList("Liste des Offres", this);
                    page.SetList(new OfferList(page));
                    mainFrame.Content = page;
                    break;
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }
    }
}
