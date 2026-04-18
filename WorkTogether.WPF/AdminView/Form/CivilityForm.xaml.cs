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
using WorkTogether.Data.Repository;
using WorkTogether.Data.Models;
using WorkTogether.WPF._core;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class CivilityForm : UserControl, IForm<Civility>
    {
        private PageList _page;
        private CivilityRepository _repository;
        private Civility? _SelectedData = null;
        private BtnForm _btn;
        PageList IForm.Page => _page;
        EntityRepository<Civility> IForm<Civility>.Repository => _repository;

        public Civility? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                Reload();
            }
        }

        public CivilityForm(PageList page)
        {
            InitializeComponent();
            _page = page;
            _repository = new CivilityRepository(_page.Window.Context);
            _btn = new BtnForm(this);
            Btn.Content = _btn;
        }

        public void Save()
        {
            string label = TxtNewLabel.Text.Trim();

            if (_SelectedData == null)
                _SelectedData = new Civility();

            _SelectedData.Label = label;

            _repository.Save(_SelectedData);
            Clear();
        }

        public void Reload()
        {
            if (_SelectedData == null)
                return;
            TxtNewLabel.Text = _SelectedData.Label;
            _btn.SetEdit();
            TitleForm.Text = "Modifier une civilité";
        }

        public void Clear()
        {
            TxtNewLabel.Clear();
            _SelectedData = null;
            _btn.SetNew();
            TitleForm.Text = "Créer une nouvelle civilité";
            ((IForm<Civility>)this).LoadList();
        }
    }
}
