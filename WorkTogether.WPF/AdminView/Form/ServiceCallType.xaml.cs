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
using ServiceCallTypeData = WorkTogether.Data.Models.ServiceCallType;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour ServiceCallType.xaml
    /// </summary>
    public partial class ServiceCallType : UserControl, IForm<ServiceCallTypeData>
    {
        private PageList _page;
        private EntityRepository<ServiceCallTypeData> _repository;
        PageList IForm<ServiceCallTypeData>.page => _page;
        EntityRepository<ServiceCallTypeData> IForm<ServiceCallTypeData>.repository => _repository;

        private ServiceCallTypeData? _SelectedData = null;
        public ServiceCallTypeData? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                reload();
            }
        }

        public ServiceCallType(PageList page)
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
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
            TitleForm.Text = "Créer un nouveau type d'intervention";
            ((IForm<ServiceCallTypeData>)this).loadList();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            string label = TxtNewLabel.Text.Trim();

            if (string.IsNullOrEmpty(label))
                return;

            if (_SelectedData == null)
            {
                var serviceCallType = new ServiceCallTypeData
                {
                    Label = label
                };
                _page.window.context.ServiceCallTypeSet.Add(serviceCallType);
            }
            else
            {
                _SelectedData.Label = label;
                _page.window.context.ServiceCallTypeSet.Update(_SelectedData);
            }

            _page.window.context.SaveChanges();
            clear();
        }

        public void Delete_Click(object sender, RoutedEventArgs e) => IForm<ServiceCallTypeData>.Static_Delete(this);

        public void Clear_Click(object sender, RoutedEventArgs e) => clear();
    }
}
