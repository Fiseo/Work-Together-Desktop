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
using WorkTogether.Data;
using WorkTogether.Data.Repository;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class CivilityList : UserControl, IList<Civility>
    {
        private PageList _page;
        private EntityRepository<Civility> _repository;

        PageList IList<Civility>.page => _page;
        EntityRepository<Civility> IList<Civility>.repository => _repository;


        private Civility _data;
        public Civility Selected_Data => _data;

        public CivilityList(PageList page)
        {
            _page = page;
            _data = new Civility();
            _repository = new CivilityRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Civility;

            if (_data != null)
                _page.setSelectedData<Civility>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
