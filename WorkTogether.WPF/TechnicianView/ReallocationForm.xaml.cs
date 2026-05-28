using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WorkTogether.WPF.TechnicianView
{
    /// <summary>
    /// Logique d'interaction pour ReallocationForm.xaml
    /// </summary>
    public partial class ReallocationForm : UserControl, IForm<Unit>
    {
        private PageList _page;
        private UnitRepository _repository;
        private Unit? _selectedData = null;
        private Unit? _selectedUnit = null;
        private ServiceCallType? _reallocationType;
        private BookingUnitRepository _buRepository;
        
        public List<Unit> Units { get; set; }
        PageList IForm.Page => _page;
        EntityRepository<Unit> IForm<Unit>.Repository => _repository;

        public Unit? SelectedData
        {
            get => _selectedData;
            set
            {
                _selectedData = value;
                Reload();
            }
        }

        public Unit? SelectedUnit
        {
            get => _selectedUnit;
            set
            {
                _selectedUnit = value;
            }
        }

        public ReallocationForm(PageList page)
        {
            InitializeComponent(); 
            DataContext = this;
            _page = page;
            _repository = new UnitRepository(_page.Window.Context);
            _buRepository = new BookingUnitRepository(_page.Window.Context);
            _reallocationType = new ServiceCallTypeRepository(_page.Window.Context).FindForReallocation();
            LoadAvailableUnits();
        }

        private void LoadAvailableUnits()
        {
            Units = _repository.FindAvailable();
            SelectedUnit = Units.FirstOrDefault();
        }

        public void Save()
        {
            Unit? newUnit = SelectedUnit;
            Unit? oldUnit = _selectedData;

            if (newUnit == null 
                || oldUnit == null 
                || oldUnit.CurrentBookingUnit == null)
                return;

            DateTime now = DateTime.Now;

            BookingUnit oldBookingUnit = oldUnit.CurrentBookingUnit;
            
            BookingUnit newBookingUnit = new BookingUnit
            {
                Start = now,
                End = oldUnit.CurrentBookingUnit.End,  // Même fin que l'original
                BookingId = oldUnit.CurrentBookingUnit.BookingId,  // Même booking
                UnitId = newUnit.Id  // Nouvelle unité
            };
            
            oldBookingUnit.End = now.AddDays(-1);
            newUnit.BookingUnits.Add(newBookingUnit);
            
            _buRepository.Save(newBookingUnit);
            _buRepository.Save(oldBookingUnit);
            
            Clear();
        }

        public void Reload()
        {
            if (_selectedData == null)
                return;
            UnitPanel.Visibility = Visibility.Visible;
            Btn.Visibility = Visibility.Visible;
            TitleForm.Text = "Sélectionnez une unité de remplacement :";
        }

        public void Clear()
        {
            _selectedData = null;
            TitleForm.Text = "Sélectionnez une unité avant de continuer :";
            UnitPanel.Visibility = Visibility.Collapsed;
            Btn.Visibility = Visibility.Collapsed;
            LoadAvailableUnits();
            ((IForm<Unit>)this).LoadList();
        }
        
        private void AddError(string message)
        {
            Error.Text = message;
            ErrorBanner.Visibility = Visibility.Visible;
        }

        private void ClearError()
        {
            ErrorBanner.Visibility = Visibility.Collapsed;
        }
        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearError();
                Save();
            } catch (Exception ex)
            {
                AddError(ex.Message.ToString());
            }
        }
        
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            Clear();
        }
    }
}