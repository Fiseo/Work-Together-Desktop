using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WorkTogether.Data.Models;
using WorkTogether.Data.Repository;

namespace WorkTogether.WPF._core.Form
{
    /// <summary>
    /// Logique d'interaction pour ServiceCallForm.xaml
    /// </summary>
    public partial class ServiceCallForm : UserControl, IForm<ServiceCall>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PageList _page;
        private ServiceCallRepository _repository; 
        private ServiceCall? _selectedData = null;
        private ServiceCallType? _selectedType;
        private Unit? _selectedUnit;
        private BtnForm _btn;
        private Technician _staff;
        public List<Unit> Units { get; set; }
        public List<ServiceCallType> Types { get; set; }
        public ServiceCallType? SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedType)));
            }
        }
        public Unit? SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                _selectedUnit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUnit)));
            }
        }


        PageList IForm.Page => _page;
        EntityRepository<ServiceCall> IForm<ServiceCall>.Repository => _repository;

        public ServiceCall? SelectedData
        {
            get => _selectedData;
            set
            {
                _selectedData = value;
                Reload();
            }
        }
        
        public ServiceCallForm(PageList page, Technician staff)
        {
            InitializeComponent();
            DataContext = this;
            _page = page;
            _repository = new ServiceCallRepository(_page.Window.Context);
            Types = new ServiceCallTypeRepository(_page.Window.Context).FindAll().ToList();
            Units =  new UnitRepository(_page.Window.Context).FindAll().ToList();
            SelectedType = Types.FirstOrDefault();
            SelectedUnit = Units.FirstOrDefault();
            _staff = staff;
            _btn = new BtnForm(this);
            Btn.Content = _btn;
        }

        public void Save()
        {
            Unit unit = SelectedUnit;
            ServiceCallType type = SelectedType;
            Technician technican = _staff;
            DateTime? date = SelectedDate.SelectedDate;
            
            if (date == null)
                throw new Exception("La date de mise en place ne peut être null !");

            if (_selectedData == null)
                _selectedData = new ServiceCall();
            
            _selectedData.Unit = unit;
            _selectedData.Type = type;
            _selectedData.Technician = technican;
            _selectedData.Date = ((DateTime)date);
            
            _repository.Save(_selectedData);
            Clear();
        }

        public void Reload()
        {
            if (_selectedData == null)
                return;
            SelectedDate.SelectedDate = _selectedData.Date;
            SelectedType = _selectedData.Type;
            SelectedUnit = _selectedData.Unit;
            _btn.SetEdit();
            TitleForm.Text = "Modifier une intervention";
        }

        public void Clear()
        {
            SelectedDate.SelectedDate = DateTime.Now;
            SelectedType = Types.FirstOrDefault();
            SelectedUnit = Units.FirstOrDefault();
            _selectedData = null;
            _btn.SetNew();
            TitleForm.Text = "Créer une nouveau staff";
            ((IForm<ServiceCall>)this).LoadList();
        }
    }
}
