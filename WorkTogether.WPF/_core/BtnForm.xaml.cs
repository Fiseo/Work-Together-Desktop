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

namespace WorkTogether.WPF._core
{
    /// <summary>
    /// Logique d'interaction pour BtnForm.xaml
    /// </summary>
    public partial class BtnForm : UserControl
    {
        private IForm _form;
        private string _add;
        private string _edit;
        public BtnForm(IForm form, string add, string edit, string delete)
        {
            _form = form;
            InitializeComponent();
            Create.Content = add;
            _add = add;
            _edit = edit;
            Delete.Content = delete;
            SetNew();
        }

        public BtnForm(IForm form) :this(form, "Ajouter", "Modifer", "Supprimer") { }

        public void SetNew()
        {
            Create.Content = _add;
            Delete.Visibility = Visibility.Collapsed;
            Clear.Visibility = Visibility.Collapsed;
        }

        public void SetEdit()
        {
            Create.Content = _edit;
            Delete.Visibility = Visibility.Visible;
            Clear.Visibility = Visibility.Visible;
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

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearError();
                _form.Save();
            } catch (Exception ex)
            {
                AddError(ex.Message.ToString());
            }
        }

        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearError();
                _form.Delete();
            }
            catch (Exception ex)
            {
                AddError(ex.Message.ToString());
            }
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            _form.Clear();
        }
    }
}
