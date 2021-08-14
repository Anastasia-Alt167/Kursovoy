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
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
            DGAvia.ItemsSource = AviakompaniyaEntities.GetContext().Flights.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Uri addadmin = new Uri("AddAdmin.xaml", UriKind.Relative);
            this.NavigationService.Navigate(addadmin);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri authorization = new Uri("Authorization.xaml", UriKind.Relative);
            this.NavigationService.Navigate(authorization);
        }

        

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {
            var flightsForRemoving = DGAvia.SelectedItems.Cast<Flights>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {flightsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AviakompaniyaEntities.GetContext().Flights.RemoveRange(flightsForRemoving);
                    AviakompaniyaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGAvia.ItemsSource = AviakompaniyaEntities.GetContext().Flights.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }
        }
    }
    
}
