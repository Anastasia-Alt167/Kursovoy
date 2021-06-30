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

namespace Kursovoy
{
    public static class RecordOfUsers { public static Passengers recordOfUsers; }
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Uri registration = new Uri("Registration.xaml", UriKind.Relative);
            this.NavigationService.Navigate(registration);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Passengers passengers = null;
            using (var context = new AviakompaniyaEntities())
            {
                passengers = (Passengers)context.Passengers.Where(x => x.Login == Login.Text && x.Password == Password.Password).FirstOrDefault();
            };
            if (passengers != null)
            {
                using (var context = new AviakompaniyaEntities())
                {
                    RecordOfUsers.recordOfUsers = context.Passengers.Where(x => x.Login == Login.Text).Select(x => x).FirstOrDefault();
                }
                Uri searchticket = new Uri("SearchTicket.xaml", UriKind.Relative);
                this.NavigationService.Navigate(searchticket);
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
    }
}
