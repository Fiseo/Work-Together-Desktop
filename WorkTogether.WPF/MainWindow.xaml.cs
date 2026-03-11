using Microsoft.EntityFrameworkCore;
using System.Text;
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

namespace WorkTogether.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkTogetherContext context;
        public MainWindow()
        {
            InitializeComponent();
            this.context = new WorkTogetherContext();
        }

        private void click(object sender, RoutedEventArgs e)
        {
            string email = emailField.Text;
            string password = passwordField.Password;

            errorBanner.Visibility = Visibility.Collapsed;

            // Vérifier si les champs sont vides
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                errorField.Text = "Veuillez remplir tous les champs !";
                errorBanner.Visibility = Visibility.Visible;
                return;
            }

            // Chercher l'utilisateur grace à son email
            var user = this.context.UserSet.FirstOrDefault(u => u.Email == email);

            // Vérifier l'utilisateur et le mot de passe hashé
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                //TODO : Mettre un message disant "vous êtes bien connecté" ou un truc du genre
                Window? dashboard = null;
                if (user is Technician)
                    dashboard = new TechnicianWindow((Technician)user, context);
                else if (user is Accountant)
                    dashboard = new AccountantWindow((Accountant)user);
                else if (!(user is Client))
                    dashboard = new AdminWindow(user);
                else
                {
                    errorField.Text = "Il est impossible de se connecter avec un compte client !";
                    errorBanner.Visibility = Visibility.Visible;
                    return;
                }

                dashboard.Show();
                this.Close();
            }
            else
            {
                errorField.Text = "Email ou mot de passe incorrect.";
                errorBanner.Visibility = Visibility.Visible;
            }
        }
    }
}