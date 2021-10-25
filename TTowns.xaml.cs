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
    /// Логика взаимодействия для TTowns.xaml
    /// </summary>
    public partial class TTowns : Page
    {
        public TTowns()
        {
            InitializeComponent();
            DGTowns.ItemsSource = AviakompaniyaEntities.GetContext().Town.ToList();
        }

        private void BackTable(object sender, RoutedEventArgs e)
        {
            Uri addadmin = new Uri("AddAdmin.xaml", UriKind.Relative);
            this.NavigationService.Navigate(addadmin);
        }
    }
}
