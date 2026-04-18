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

namespace WorkTogether.WPF.TechnicianView
{
    /// <summary>
    /// Logique d'interaction pour TechnicianWindow.xaml
    /// </summary>
    public partial class TechnicianWindow : Window, IWindow<Technician>
    {
        public Technician User { get; }
        public WorkTogetherContext Context { get; }
        public TechnicianWindow(Technician user)
        {
            User = user;
            Context = new WorkTogetherContext();
            InitializeComponent();
        }

        public TechnicianWindow(Technician user, WorkTogetherContext context)
        {
            User = user;
            Context = context;
            InitializeComponent();
        }

        public void Logout()
        {
            var main = new MainWindow(Context);
            main.Show();
            Close();
        }
    }
}
