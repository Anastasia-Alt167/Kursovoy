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
using System.Data;


namespace Kursovoy
{
    public class NameOfCity
    {
        public static Town name;
        public NameOfCity(Town nameOfCity)
        {
            name = nameOfCity;
        }
    }
    /// <summary>
    /// Логика взаимодействия для SearchTicket.xaml
    /// </summary>
    public partial class SearchTicket : Page
    {
        int countOfAdults = 1;
        int countOfChildren = 0;
        int countOfBaby = 0;
        public SearchTicket()
        {
            InitializeComponent();
            countOfAdultChildreanRoomButton.Content = $"Взрослых: {countOfAdults}   Детей: {countOfChildren}   Младенцев: {countOfBaby}";
            textAdults.Text = countOfAdults.ToString();
            textChildren.Text = countOfChildren.ToString();
            textBaby.Text = countOfBaby.ToString();
            buttonCalendar.Content = "Когда";
            DateTime date = DateTime.Now;
            Calendar.DisplayDateStart = date;
            using (var context = new AviakompaniyaEntities())
            {
                CbNaimTovCountry.ItemsSource = context.Town.ToList();
            }
        }
        private bool flagButton = false;
        private void ClickButtonCalendar(object sender, RoutedEventArgs e)
        {
            flagButton = !flagButton;
            Calendar.Visibility = flagButton ? Visibility.Visible : Visibility.Collapsed;
        }
        DateTime firsDate;
        DateTime lastDate;

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            firsDate = Calendar.SelectedDates.OrderBy(k => k).First();
            lastDate = Calendar.SelectedDates.OrderBy(k => k).Last();
            buttonCalendar.Content = firsDate.ToString("M") + " - " + lastDate.ToString("M");
        }

        private void CbNaimTovCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var test = e.AddedItems[0];
            NameOfCity p = new NameOfCity((Town)test);
            using (var db = new AviakompaniyaEntities())
            {
                CbNaimTovCity.ItemsSource = db.Town.Where(x => x.Town1 != NameOfCity.name.Town1).Select(x => x).ToList();
            }
        }

        private void Count_Of_Adults_Children_Baby(int countOfAdults, int countOfChildren, int countOfBaby)
        {
            countOfAdultChildreanRoomButton.Content = $"Взрослых: {countOfAdults}   Детей: {countOfChildren}   Младенцев: {countOfBaby}";
        }
        private bool flagButton1 = false;
        private void countOfAdultChildreanRoomButton_Click(object sender, RoutedEventArgs e)
        {
            flagButton1 = !flagButton1;
            borderCountOfAdultChildrenBaby.Visibility = flagButton1 ? Visibility.Visible : Visibility.Collapsed;
        }
        private void Button_Adults_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfAdults > 1)
                countOfAdults--;
            textAdults.Text = countOfAdults.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);
        }
        private void Button_Adults_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfAdults < 15)
                countOfAdults++;
            textAdults.Text = countOfAdults.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);
        }
        private void Button_Children_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfChildren > 0)
                countOfChildren--;
            textChildren.Text = countOfChildren.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);
        }
        private void Button_Children_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfChildren < 15)
                countOfChildren++;
            textChildren.Text = countOfChildren.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);
        }
        private void Button_Baby_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfBaby > 0)
                countOfBaby--;
            textBaby.Text = countOfBaby.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);

        }
        private void Button_Baby_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (countOfBaby < 15)
                countOfBaby++;
            textBaby.Text = countOfBaby.ToString();
            Count_Of_Adults_Children_Baby(countOfAdults, countOfChildren, countOfBaby);
        }

        private void CbNaimTovCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
