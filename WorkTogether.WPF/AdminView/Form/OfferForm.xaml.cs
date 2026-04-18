using Google.Protobuf.WellKnownTypes;
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
using WorkTogether.Data.Repository;
using WorkTogether.Data.Models;
using WorkTogether.WPF._core;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour Offer.xaml
    /// </summary>
    public partial class OfferForm : UserControl, IForm<Offer>
    {
        private PageList _page;
        private OfferRepository _repository;
        private Offer? _SelectedData = null;
        private BtnForm _btn;
        PageList IForm.Page => _page;
        EntityRepository<Offer> IForm<Offer>.Repository => _repository;
        public Offer? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                Reload();
            }
        }

        public OfferForm(PageList page)
        {
            InitializeComponent();
            _page = page;
            _repository = new OfferRepository(_page.Window.Context);
            _btn = new BtnForm(this);
            Btn.Content = _btn; 
        }

        public void Save()
        {
            string label = TxtNewLabel.Text.Trim();
            int UnitProvided = System.Convert.ToInt32(TxtNewUnits.Text.Trim());
            int Discount = System.Convert.ToInt32(TxtNewReduction.Text.Trim());
            string Description = TxtNewDescription.Text.Trim();


            if (_SelectedData != null)
            {
                _SelectedData.IsActive = false;
                _repository.Save(_SelectedData);
            }
            _SelectedData = new Offer();

            _SelectedData.Label = label;
            _SelectedData.UnitProvided = UnitProvided;
            _SelectedData.Discount = Discount;
            _SelectedData.Description = Description;
            _SelectedData.IsActive = true;

            _repository.Save(_SelectedData);
            Clear();
        }

        public void Reload()
        {
            if (_SelectedData == null)
                return;
            TxtNewLabel.Text = _SelectedData.Label;
            TxtNewUnits.Text = System.Convert.ToString(_SelectedData.UnitProvided);
            TxtNewReduction.Text = System.Convert.ToString(_SelectedData.Discount);
            TxtNewDescription.Text = _SelectedData.Description;
            _btn.SetEdit();
            TitleForm.Text = "Modifier une offre";
        }
        
        public void Clear()
        {
            TxtNewLabel.Clear();
            TxtNewUnits.Clear();
            TxtNewReduction.Text = "100";
            TxtNewDescription.Clear();
            _SelectedData = null;
            _btn.SetNew();
            TitleForm.Text = "Créer une nouvelle offre";
            ((IForm<Offer>)this).LoadList();
        }
    }
}
