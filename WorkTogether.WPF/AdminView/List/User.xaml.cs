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
using UserData = WorkTogether.Data.Models.User;

namespace WorkTogether.WPF.AdminView.List
{
    /// <summary>
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class User : UserControl, IList<UserData>
    {
        private PageList _page;
        PageList IList<UserData>.page => _page;

        private UserData _data;
        public UserData Selected_Data => _data;

        public User(PageList page)
        {
            _page = page;
            _data = new UserData();
            InitializeComponent();
            load();
        }

        public void Data_Selected(object sender, RoutedEventArgs e)
        {
            _data = DataGrid.SelectedItem as UserData;

            if (_data != null)
                _page.setSelectedData<UserData>(_data);
        }

        public void load()
        {
            DataGrid.ItemsSource = _page.window.context.UserSet.ToList();
        }
    }
}
