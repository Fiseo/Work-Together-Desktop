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
using CivilityData = WorkTogether.Data.Models.Civility;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour Civility.xaml
    /// </summary>
    public partial class Civility : UserControl, IForm<CivilityData>
    {
        private PageList _page;
        private CivilityRepository _repository;
        PageList IForm<CivilityData>.page => _page;
        EntityRepository<CivilityData> IForm<CivilityData>.repository => _repository;


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
            _repository = new CivilityRepository(_page.window.context);
            InitializeComponent();
        }


        public void reload()
        {
            if (_SelectedData == null)
                return;
            TxtNewLabel.Text = _SelectedData.Label;
            Delete.Visibility = Visibility.Visible;
            Clear.Visibility = Visibility.Visible;
            TitleForm.Text = "Modifier une civilité";
        }

        public void clear()
        {
            TxtNewLabel.Clear();
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
            TitleForm.Text = "Créer une nouvelle civilité";
            ((IForm<CivilityData>)this).loadList();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();

            if (_SelectedData == null)
            {
                _SelectedData = new CivilityData
                {
                    Label = label
                };
            }
            else
                _SelectedData.Label = label;

            _repository.save(_SelectedData);
            clear();
        }

        public void Delete_Click(object sender, RoutedEventArgs e) => IForm<CivilityData>.Static_Delete(this);

        public void Clear_Click(object sender, RoutedEventArgs e) => clear();
    }
}
