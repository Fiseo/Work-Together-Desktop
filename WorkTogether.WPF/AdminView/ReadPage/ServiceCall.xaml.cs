using Microsoft.EntityFrameworkCore;
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

namespace WorkTogether.WPF.AdminView.ReadPage
{
    /// <summary>
    /// Logique d'interaction pour ServiceCall.xaml
    /// </summary>
    public partial class ServiceCall : UserControl
    {
        private AdminWindow _window;
        public ServiceCall(AdminWindow window)
        {
            _window = window;
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            DataGrid.ItemsSource = _window.context.ServiceCallSet
                .Include(s => s.Technician)
                .Include(s => s.Unit.Bay)
                .Include(s => s.Type)
                .ToList();
        }
    }
}
