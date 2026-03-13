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
using UnitData = WorkTogether.Data.Models.Unit;

namespace WorkTogether.WPF.AdminView.ReadPage
{
    /// <summary>
    /// Logique d'interaction pour Bay.xaml
    /// </summary>
    public partial class Bay : UserControl
    {
        private AdminWindow _window;
        public Bay(AdminWindow window)
        {
            _window = window;
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            DataGrid.ItemsSource = _window.context.BaySet
                .Include(b =>b.Units)
                .ToList();
        }
    }
}
