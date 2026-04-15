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
using WorkTogether.Data;
using WorkTogether.Data.Repository;
using UnitData = WorkTogether.Data.Models.Unit;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Unit.xaml
    /// </summary>
    public partial class Unit : UserControl, IList<UnitData>
    {
        private PageList _page;
        private EntityRepository<UnitData> _repository;
        PageList IList<UnitData>.page => _page;
        EntityRepository<UnitData> IList<UnitData>.repository => _repository;

        private UnitData _data;
        public UnitData Selected_Data => _data;

        public Unit(PageList page)
        {
            _page = page;
            _data = new UnitData();
            _repository = new UnitRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as UnitData;

            if (_data != null)
                _page.setSelectedData<UnitData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
