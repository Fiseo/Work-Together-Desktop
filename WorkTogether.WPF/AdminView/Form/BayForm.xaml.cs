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
using WorkTogether.WPF._core;

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
        private Bay? _SelectedData = null;
        private BtnForm _btn;

        PageList IForm.Page => _page;
        EntityRepository<Bay> IForm<Bay>.Repository => _repository;

        public Bay? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                Reload();
            }
        }

        public BayForm(PageList page)
        {
            InitializeComponent();
            _page = page;
            _repository = new BayRepository(_page.Window.Context);
            _unitRepository = new UnitRepository(_page.Window.Context);
            _btn = new BtnForm(this);
            Btn.Content = _btn;
        }

        public void Save()
        {
            string label = TxtLabel.Text.Trim();
            string UnitLabel = TxtUnitLabel.Text.Trim();

            if (_SelectedData == null)
                _SelectedData = new Bay();


            _SelectedData.Label = label;
            _SelectedData.UnitPrefix = UnitLabel;

            _repository.Save(_SelectedData);

            int x = 0;
            if (_SelectedData.NumberUnit == 0)
                x = System.Convert.ToInt32(TxtNbrUnit.Text.Trim());
            else
                x = _SelectedData.NumberUnit;

            bool isNew = (_SelectedData.NumberUnit == 0);
            for (int i = 1; i <= x; i++)
            {
                Unit? u = null;
                if (isNew)
                {
                    u = new Unit();
                    u.Bay = _SelectedData;
                    u.HaveProblem = false;
                }
                else
                    u = _SelectedData.Units.ElementAt(i - 1);
                u.Label = UnitLabel + i.ToString().PadLeft(x.ToString().Length, '0');
                _unitRepository.Save(u);
            }

            Clear();
        }

        public void Reload()
        {
            if (_SelectedData == null)
                return;
            TxtLabel.Text = _SelectedData.Label;
            TxtNbrUnit.Text = _SelectedData.Units.Count.ToString();
            TxtUnitLabel.Text = _SelectedData.UnitPrefix;

            TxtNbrUnit.IsReadOnly = true;
            _btn.SetEdit();
            TitleForm.Text = "Modifier une baie";
        }

        public void Clear()
        {
            TxtLabel.Clear();
            TxtNbrUnit.Text = "42";
            TxtUnitLabel.Text = "U";
            _SelectedData = null;
            TxtNbrUnit.IsReadOnly = false;
            _btn.SetNew();
            TitleForm.Text = "Créer une nouvelle baie";
            ((IForm<Bay>)this).LoadList();
        }
    }
}
