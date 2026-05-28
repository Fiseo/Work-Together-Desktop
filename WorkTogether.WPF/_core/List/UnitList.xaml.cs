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
using WorkTogether.Data.Models;
using WorkTogether.WPF.TechnicianView;

namespace WorkTogether.WPF.List
{
    /// <summary>
    /// Logique d'interaction pour Unit.xaml
    /// </summary>
    public partial class UnitList : UserControl, IList<Unit>
    {
        private PageList _page;
        private UnitRepository _repository;
        PageList IList<Unit>.Page => _page;
        EntityRepository<Unit> IList<Unit>.Repository => _repository;
        private bool _problemOnly;

        private Unit _data;
        public Unit Selected_Data => _data;

        public UnitList(PageList page):this(page, false)
        {
        }

        public UnitList(PageList page, bool problemOnly)
        {
            _page = page;
            _data = new Unit();
            _repository = new UnitRepository(_page.Window.Context);
            _problemOnly = problemOnly;
            InitializeComponent();
            Load();
        }
        

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Unit;

            if (_data != null)
                _page.SetSelectedData<Unit>(_data);
        }

        public void Load()
        {
            if (_problemOnly)
            {
                ((IPage)_page).SetPage(new NoUsedUnitWithProblem(_page.Window));
                /*
                List<Unit> units = _repository.FindUsedWithProblem() ?? new List<Unit>();
                if (!units.Any())
                    _repository.FindUsedWithProblem();
                else
                    DataGrid.ItemsSource = units;
                    */
            }
            else
            {
                DataGrid.ItemsSource = _repository.FindAll();
            }
        }
    }
}
