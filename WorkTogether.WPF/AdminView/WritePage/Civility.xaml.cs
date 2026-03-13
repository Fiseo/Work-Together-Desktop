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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CivilityData = WorkTogether.Data.Models.Civility;

namespace WorkTogether.WPF.AdminView.WritePage
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class Civility : UserControl
    {
        private AdminWindow _window;
        private CivilityData? _civility;
        public Civility(AdminWindow window)
        {
            _window = window;
            InitializeComponent();
            Load();
        }

        private void Data_Selected(object sender, RoutedEventArgs e)
        {
            _civility = DataGrid.SelectedItem as CivilityData;

            if ( _civility != null )
                TxtNewLabel.Text = _civility.Label;
        }

        private void Load()
        {
            DataGrid.ItemsSource = _window.context.CivilitySet.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();

            if (string.IsNullOrEmpty(label))
                return;

            if (_civility == null)
            {
                var civility = new CivilityData
                {
                    Label = label
                };
                _window.context.CivilitySet.Add(civility);
            }
            else
            {
                _civility.Label = label;
                _window.context.CivilitySet.Update(_civility);
            }

            _window.context.SaveChanges();
            TxtNewLabel.Clear();
            Load();
        }
    }
}
