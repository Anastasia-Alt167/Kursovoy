﻿using System;
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
                CbNaimTovCountry.ItemsSource = (from t in context.Town
                                                join f in context.Flights on t.Town_Code equals f.Fly_Town
                                                select new { t.Town1, f.Fly_Town }).ToList();//context.Town.ToList();
                //(from t in context.Town
                // join f in context.Flights on t.Town_Code equals f.Fly_Town
                // select new { t.Town1, f.Fly_Town }).ToList();
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
            // var test = e.AddedItems[0];

            using (var db = new AviakompaniyaEntities())
            {
                NameOfCity p = new NameOfCity(db.Town.FirstOrDefault(x => x.Town_Code == (int)((ComboBox)sender).SelectedValue));
                if (CbNaimTovCountry.SelectedIndex != -1)
                {

                    CbNaimTovCity.ItemsSource = db.Flights.Where(x => x.Fly_Town == (int)((ComboBox)sender).SelectedValue).Select(x => new { x.Town.Town1, x.Arrival_Town }).ToList();

                    CbNaimTovCity.SelectedIndex = -1;
                }

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

        private void PA_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri personalaccount = new Uri("PersonalAccount.xaml", UriKind.Relative);
            this.NavigationService.Navigate(personalaccount);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new AviakompaniyaEntities()) //{ Aircraft_Number = p.Aircraft_Number ,Flight_Number = p.Flight_Number , Airline_Number = t.Airline_Number}
            {
                var isFounded = db.Flights
                    .Join(db.Aircraft1, f => f.Aircraft_Number, a => a.Aircraft_Number, (f, a) => new { a, f })
                    .Join(db.Places, @t => @t.a.Aircraft_Number, p => p.Aircraft_Number, (@t, p) => new { @t, p })
                    .Where(@t =>
                        @t.@t.f.Arrival_Town == (int)CbNaimTovCity.SelectedValue &&
                        @t.@t.f.Fly_Town == (int)CbNaimTovCountry.SelectedValue && !@t.p.Is_Occupated)
                    .FirstOrDefault();
                if (isFounded != null)
                {
                    db.Tickets.Add(new Tickets()
                    {
                        Aircraft_Number = isFounded.p.Aircraft_Number,
                        Flight_Number = isFounded.t.f.Flight_Number,
                        Airline_Number = isFounded.t.a.Airline_Number,
                        Passenger_Number = PassangerRecord.passangerRecord.Passenger_Number,
                        Place_Number = isFounded.p.Place_Number,
                        Row_Number = isFounded.p.Row_Number
                    });
                    isFounded.p.Is_Occupated = true;
                    MessageBox.Show("Место куплено!");
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Мест нет, мы вам перезвоним");
                }
            }
        }
    }

}

