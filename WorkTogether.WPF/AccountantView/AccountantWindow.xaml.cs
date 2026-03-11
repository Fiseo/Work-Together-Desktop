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
using System.Windows.Shapes;
using WorkTogether.Data;
using WorkTogether.Data.Models;

namespace WorkTogether.WPF.AccountantView
{
    /// <summary>
    /// Logique d'interaction pour AccountantWindow.xaml
    /// </summary>
    partial class AccountantWindow : AbstractWindow<Accountant>
    {
        public AccountantWindow(Accountant user, WorkTogetherContext? context = null) : base(user, context)
        {
            InitializeComponent();
        }
    }
}
