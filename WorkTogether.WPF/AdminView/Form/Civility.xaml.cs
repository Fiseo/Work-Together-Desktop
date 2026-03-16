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

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class Civility : UserControl, IForm<CivilityData>
    {
        private PageList _page;
        PageList IForm<CivilityData>.page => _page;

        private CivilityData? _SelectedData = null;
        public CivilityData? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                reload();
            }
        }

        public Civility(PageList page)
        {
            _page = page;
            InitializeComponent();
        }


        public void reload()
        {
            throw new NotImplementedException();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();

            if (string.IsNullOrEmpty(label))
                return;

            if (_SelectedData == null)
            {
                var civility = new CivilityData
                {
                    Label = label
                };
                _page.window.context.CivilitySet.Add(civility);
            }
            else
            {
                _SelectedData.Label = label;
                _page.window.context.CivilitySet.Update(_SelectedData);
            }

            _page.window.context.SaveChanges();
            TxtNewLabel.Clear();
            ((IForm<CivilityData>)this).loadList();
        }
    }
}
