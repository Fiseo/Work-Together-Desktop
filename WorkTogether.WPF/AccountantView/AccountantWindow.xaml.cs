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

namespace WorkTogether.WPF.AccountantView
{
    /// <summary>
    /// Logique d'interaction pour AccountantWindow.xaml
    /// </summary>
    partial class AccountantWindow : Window, IWindow<Accountant>
    {
        public Accountant user { get; }
        public WorkTogetherContext context { get; }
        public AccountantWindow(Accountant user)
        {
            this.user = user;
            context = new WorkTogetherContext();
            InitializeComponent();
        }

        public AccountantWindow(Accountant user, WorkTogetherContext context)
        {
            this.user = user;
            this.context = context;
            InitializeComponent();
        }

        public void logout()
        {
            var main = new MainWindow(context);
            main.Show();
            Close();
        }
    }
}
