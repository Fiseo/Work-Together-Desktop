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
using WorkTogether.WPF._core.Form;
using WorkTogether.WPF.List;

namespace WorkTogether.WPF.TechnicianView
{
    /// <summary>
    /// Logique d'interaction pour TechnicianWindow.xaml
    /// </summary>
    public partial class TechnicianWindow : Window, IWindow<Technician>
    {
        public Technician User { get; }
        public WorkTogetherContext Context { get; }

        public TechnicianWindow(Technician user, WorkTogetherContext context)
        {
            User = user;
            Context = context;
            InitializeComponent();
            usernameLabel.Text = user.Username;
            PageList page = new PageList("Liste des Clients", this);
            page.SetList(new UnitList(page, true));
            page.SetForm(new ReallocationForm(page));
            SetPage(page);
            
        }
        
        public TechnicianWindow(Technician user): this(user, new WorkTogetherContext())
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
            mainFrame.Content = null;
            mainFrame.Content =  page;
        }
        
        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button)?.Tag?.ToString() ?? "unit";

            PageList? page = null;

            switch (tag)
            {
                case "unit":
                    page = new PageList("Liste des Unités utilisé ayant des problèmes", this);
                    page.SetList(new UnitList(page, true));
                    page.SetForm(new ReallocationForm(page));
                    SetPage(page);
                    break;
                case "serviceCall":
                    page = new PageList("Liste des interventions", this);
                    page.SetList(new ServiceCallList(page, User));
                    page.SetForm(new ServiceCallForm(page, User));
                    SetPage(page);
                    break;
            }
            
        }
        
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }
    }
}
