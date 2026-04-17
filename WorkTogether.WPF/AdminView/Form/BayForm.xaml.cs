using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using WorkTogether.Data.Models;
using WorkTogether.Data.Repository;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour FormBay.xaml
    /// </summary>
    public partial class BayForm : UserControl, IForm<Bay>
    {
        private PageList _page;
        private BayRepository _repository;
        private UnitRepository _unitRepository;
        PageList IForm<Bay>.page => _page;
        EntityRepository<Bay> IForm<Bay>.repository => _repository;


        private Bay? _SelectedData = null;
        public Bay? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                reload();
            }
        }

        public BayForm(PageList page)
        {
            _page = page;
            _repository = new BayRepository(_page.window.context);
            _unitRepository = new UnitRepository(_page.window.context);
            InitializeComponent();
        }


        public void reload()
        {
            if (_SelectedData == null)
                return;
            TxtLabel.Text = _SelectedData.Label;
            TxtNbrUnit.Text = _SelectedData.Units.Count.ToString();
            TxtUnitLabel.Text = _SelectedData.UnitPrefix;

            TxtNbrUnit.IsReadOnly = true;
            Delete.Visibility = Visibility.Visible;
            Clear.Visibility = Visibility.Visible;
            TitleForm.Text = "Modifier une baie";
        }

        public void clear()
        {
            TxtLabel.Clear();
            TxtNbrUnit.Text = "42";
            TxtUnitLabel.Text = "U";
            _SelectedData = null;
            TxtNbrUnit.IsReadOnly = false;
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
            TitleForm.Text = "Créer une nouvelle baie";
            ((IForm<Bay>)this).loadList();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtLabel.Text.Trim();
            string UnitLabel = TxtUnitLabel.Text.Trim();

            if (_SelectedData == null)
                _SelectedData = new Bay();


            _SelectedData.Label = label;
            _SelectedData.UnitPrefix = UnitLabel;

            _repository.save(_SelectedData);

            int x = 0;
            if (_SelectedData.NumberUnit == 0)
                x = System.Convert.ToInt32(TxtNbrUnit.Text.Trim());
            else
                x = _SelectedData.NumberUnit;

            bool isNew = (_SelectedData.NumberUnit == 0);
            for (int i = 1; i <= x; i++)
            {
                Unit? u = null;
                if(isNew)
                {
                    u = new Unit();
                    u.Bay = _SelectedData;
                    u.HaveProblem = false;
                }
                else
                    u = _SelectedData.Units.ElementAt(i - 1);
                u.Label = UnitLabel + i.ToString().PadLeft(x.ToString().Length, '0');
                _unitRepository.save(u);
            }

            clear();
        }

        public void Delete_Click(object sender, RoutedEventArgs e) => IForm<Bay>.Static_Delete(this);

        public void Clear_Click(object sender, RoutedEventArgs e) => clear();
    }
}
