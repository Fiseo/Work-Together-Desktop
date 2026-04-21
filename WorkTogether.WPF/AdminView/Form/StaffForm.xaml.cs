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
using System.Xml.Linq;
using WorkTogether.Data;
using WorkTogether.Data.Models;
using WorkTogether.Data.Repository;
using WorkTogether.WPF._core;

namespace WorkTogether.WPF.AdminView.Form
{
    /// <summary>
    /// Logique d'interaction pour UserForm.xaml
    /// </summary>
    public partial class StaffForm : UserControl, IForm<Staff>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private PageList _page;
        private StaffRepository _repository; 
        private Staff? _selectedData = null;
        private Civility? _selectedCivility;
        private BtnForm _btn;
        private TechnicianRepository _technicianRepository;
        private AccountantRepository _accountantRepository;
        public List<Civility> Civilities { get; set; }
        public Civility? SelectedCivility
        {
            get => _selectedCivility;
            set
            {
                _selectedCivility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCivility)));
            }
        }


        PageList IForm.Page => _page;
        EntityRepository<Staff> IForm<Staff>.Repository => _repository;

        public Staff? SelectedData
        {
            get => _selectedData;
            set
            {
                _selectedData = value;
                Reload();
            }
        }

        public StaffForm(PageList page)
        {
            InitializeComponent();
            DataContext = this;
            _page = page;
            _repository = new StaffRepository(_page.Window.Context);
            _technicianRepository = new TechnicianRepository(_page.Window.Context);
            _accountantRepository = new AccountantRepository(_page.Window.Context);
            Civilities =  new CivilityRepository(_page.Window.Context).FindAll().ToList();
            SelectedCivility = Civilities.FirstOrDefault();
            _btn = new BtnForm(this);
            Btn.Content = _btn;
        }

        public void Save()
        {
            string name = TxtName.Text;
            string firstName = TxtFirstName.Text;
            string email = TxtEmail.Text;
            string password = BCrypt.Net.BCrypt.HashPassword(TxtPassword.Password);
            Civility civility = SelectedCivility;

            if (_selectedData == null)
            {
                if (IsTechnician.IsChecked == true)
                    _selectedData = new Technician
                    {
                        Password = password
                    };
                else
                    _selectedData = new Accountant
                    {
                        Password = password
                    };
            }

            _selectedData.LastName = name;
            _selectedData.FirstName = firstName;
            _selectedData.Email = email;
            _selectedData.Civility = civility;
            _selectedData.Username = name + " " + firstName;

            if (_selectedData.GetType() == typeof(Technician))
                _technicianRepository.Save((Technician)_selectedData);
            else
                _accountantRepository.Save((Accountant)_selectedData);
            Clear();
        }

        public void Reload()
        {
            if (_selectedData == null)
                return;
            TxtName.Text = _selectedData.LastName;
            TxtFirstName.Text = _selectedData.FirstName;
            TxtEmail.Text = _selectedData.Email;
            SelectedCivility = _selectedData.Civility;
            UnchangeableValues.Visibility = Visibility.Collapsed;
            _btn.SetEdit();
            string title = "Modifier un ";
            if (_selectedData.GetType() == typeof(Technician))
                title = title + "technicien";
            else
                title = title + "comptable";
            TitleForm.Text = title;
        }

        public void Clear()
        {
            TxtName.Clear();
            TxtFirstName.Clear();
            TxtEmail.Clear();
            TxtPassword.Clear();
            UnchangeableValues.Visibility = Visibility.Visible;
            _selectedData = null;
            _btn.SetNew();
            TitleForm.Text = "Créer une nouveau staff";
            ((IForm<Staff>)this).LoadList();
        }
    }
}
