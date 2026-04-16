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

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour Offer.xaml
    /// </summary>
    public partial class FormOffer : UserControl, IForm<Offer>
    {
        private PageList _page;
        private EntityRepository<Offer> _repository;
        PageList IForm<Offer>.page => _page;
        EntityRepository<Offer> IForm<Offer>.repository => _repository;

        private Offer? _SelectedData = null;
        public Offer? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                reload();
            }
        }

        public FormOffer(PageList page)
        {
            _page = page;
            _repository = new OfferRepository(_page.window.context);
            InitializeComponent();
        }

        public void reload()
        {
            if (_SelectedData == null)
                return;
            TxtNewLabel.Text = _SelectedData.Label;
            TxtNewUnits.Text = System.Convert.ToString(_SelectedData.UnitProvided);
            TxtNewReduction.Text = System.Convert.ToString(_SelectedData.Discount);
            TxtNewDescription.Text = _SelectedData.Description;
            TitleForm.Text = "Modifier une offre";
        }
        
        public void clear()
        {
            TxtNewLabel.Clear();
            TxtNewUnits.Clear();
            TxtNewReduction.Clear();
            TxtNewDescription.Clear();
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
            TitleForm.Text = "Créer une nouvelle offre";
            ((IForm<Offer>)this).loadList();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();
            int UnitProvided = System.Convert.ToInt32(TxtNewUnits.Text.Trim());
            int Discount = System.Convert.ToInt32(TxtNewReduction.Text.Trim());
            string Description = TxtNewDescription.Text.Trim();


            if (_SelectedData != null)
            {
                _SelectedData.IsActive = false;
                _repository.save(_SelectedData);
            }
            _SelectedData = new Offer();

            _SelectedData.Label = label;
            _SelectedData.UnitProvided = UnitProvided;
            _SelectedData.Discount = Discount;
            _SelectedData.Description = Description;
            _SelectedData.IsActive = true;

            _repository.save(_SelectedData);
            clear();
            TitleForm.Text = "Créer une nouvelle offre";
            ((IForm<Offer>)this).loadList();
        }

        public void Delete_Click(object sender, RoutedEventArgs e) => IForm<Offer>.Static_Delete(this);

        public void Clear_Click(object sender, RoutedEventArgs e) => clear();
    }
}
