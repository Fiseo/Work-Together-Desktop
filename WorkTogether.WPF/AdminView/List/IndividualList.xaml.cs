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

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour Individual.xaml
    /// </summary>
    public partial class IndividualList : UserControl, IList<Individual>
    {
        private PageList _page;
        private EntityRepository<Individual> _repository;

        PageList IList<Individual>.Page => _page;
        EntityRepository<Individual> IList<Individual>.Repository => _repository;


        private Individual _data;
        public Individual Selected_Data => _data;

        public IndividualList(PageList page)
        {
            _page = page;
            _data = new Individual();
            _repository = new IndividualRepository(_page.Window.Context);
            InitializeComponent();
            Load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as Individual;

            if (_data != null)
                _page.SetSelectedData<Individual>(_data);
        }

        public void Load()
        {
            DataGrid.ItemsSource = _repository.FindAll();
        }
    }
}
