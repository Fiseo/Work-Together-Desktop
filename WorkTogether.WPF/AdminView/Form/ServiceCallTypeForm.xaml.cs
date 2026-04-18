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
    /// Logique d'interaction pour ServiceCallType.xaml
    /// </summary>
    public partial class ServiceCallTypeForm : UserControl, IForm<ServiceCallType>
    {
        private PageList _page;
        private ServiceCallTypeRepository _repository;
        private BtnForm _btn;
        PageList IForm.Page => _page;
        EntityRepository<ServiceCallType> IForm<ServiceCallType>.Repository => _repository;

        private ServiceCallType? _SelectedData = null;
        public ServiceCallType? SelectedData
        {
            get => _SelectedData;
            set
            {
                _SelectedData = value;
                Reload();
            }
        }

        public ServiceCallTypeForm(PageList page)
        {
            InitializeComponent();
            _page = page;
            _repository = new ServiceCallTypeRepository(_page.Window.Context);
            _btn = new BtnForm(this);
            Btn.Content = _btn;
        }

        public void Save()
        {
            string label = TxtNewLabel.Text.Trim();

            if (_SelectedData == null)
                _SelectedData = new ServiceCallType();

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
            TitleForm.Text = "Modifier un type d'intervention";
        }

        public void Clear()
        {
            TxtNewLabel.Clear();
            _SelectedData = null;
            _btn.SetNew();
            TitleForm.Text = "Créer un nouveau type d'intervention";
            ((IForm<ServiceCallType>)this).LoadList();
        }
    }
}
