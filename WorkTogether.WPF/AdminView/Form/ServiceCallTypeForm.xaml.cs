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
    /// Logique d'interaction pour ServiceCallType.xaml
    /// </summary>
    public partial class ServiceCallTypeForm : UserControl, IForm<ServiceCallType>
    {
        private PageList _page;
        private ServiceCallTypeRepository _repository;
        PageList IForm<ServiceCallType>.page => _page;
        EntityRepository<ServiceCallType> IForm<ServiceCallType>.repository => _repository;

        private ServiceCallType? _SelectedData = null;
        public ServiceCallType? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                reload();
            }
        }

        public ServiceCallTypeForm(PageList page)
        {
            _page = page;
            _repository = new ServiceCallTypeRepository(_page.window.context);
            InitializeComponent();
        }


        public void reload()
        {
            if (_SelectedData == null)
                return;
            TxtNewLabel.Text = _SelectedData.Label;
            Delete.Visibility = Visibility.Visible;
            Clear.Visibility = Visibility.Visible;
            TitleForm.Text = "Modifier un type d'intervention";
        }

        public void clear()
        {
            TxtNewLabel.Clear();
            _SelectedData = null;
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
            TitleForm.Text = "Créer un nouveau type d'intervention";
            ((IForm<ServiceCallType>)this).loadList();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();

            if (string.IsNullOrEmpty(label))
                return;

            if (_SelectedData == null)
                _SelectedData = new ServiceCallType();

            _SelectedData.Label = label;

            _repository.Save(_SelectedData);
            clear();
        }

        public void Delete_Click(object sender, RoutedEventArgs e) => IForm<ServiceCallType>.Static_Delete(this);

        public void Clear_Click(object sender, RoutedEventArgs e) => clear();
    }
}
