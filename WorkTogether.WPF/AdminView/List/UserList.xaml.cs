using System;
using System.Collections.Generic;
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
using WorkTogether.Data.Repository;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class UserList : UserControl, IList<User>
    {
        private PageList _page;
        private EntityRepository<User> _repository;

        PageList IList<User>.page => _page;
        EntityRepository<User> IList<User>.repository => _repository;


        private User _data;
        public User Selected_Data => _data;

        public UserList(PageList page)
        {
            _page = page;
            _data = new User();
            _repository = new UserRepository(_page.window.context);
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as User;

            if (_data != null)
                _page.setSelectedData<User>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _repository.findAll();
        }
    }
}
