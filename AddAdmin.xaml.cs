using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Globalization;
using System.Text.RegularExpressions;


namespace Kursovoy
{
    /// <summary>
    /// Логика взаимодействия для AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Page
    {
        public static class FlightsRecord
        {
            public static Flights flightsRecord;
        }
        public AddAdmin()
        {
            //InitializeComponent();
            //using (var context = new AviakompaniyaEntities())
            //{
                
            //    Flight_Number.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Flight_Number).FirstOrDefault().ToString();
            //    Fly_Date.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Date).FirstOrDefault().ToString();
            //    Fly_Time.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Time).FirstOrDefault().ToString();
            //    Fly_Town.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Town).FirstOrDefault().ToString();
            //    Arrival_Date.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Date).FirstOrDefault().ToString();
            //    Arrival_Town.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Town).FirstOrDefault().ToString();
            //    Arrival_Time.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Time).FirstOrDefault().ToString();
            //    Aircraft_Number.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Aircraft_Number).FirstOrDefault().ToString();
            //}
          
        }
        // const int lengthOfFlightNumber = 10;
        // const int lengthOfFlyDate = 10;
        // const int lengthOfFlyTime = 5;
        // const int lengthOfFlyTown = 40;
        // const int lengthOfArrivalDate = 10;
        // const int lengthOfArrivalTime = 5;
        // const int lengthOfArrivalTown = 40;
        // const int lengthOfAircraftNumber = 10;
        // public bool CheckFlightsInformation(string stringToCheck) => (stringToCheck.Length < lengthOfFlightNumber) && stringToCheck.All(c => Char.IsLetter(c));

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string Flight_Number1 = Flight_Number.Text.Trim().ToLower();
            string Fly_Date1 = Fly_Date.Text.Trim().ToLower();
            string Fly_Time1 = Fly_Time.Text.Trim().ToLower();
            string Fly_Town1 = Fly_Town.Text.Trim().ToLower();
            string ArrivalDate1 = Fly_Date.Text.Trim().ToLower();
            string ArrivalTime1 = Fly_Time.Text.Trim().ToLower();
            string ArrivalTown1 = Fly_Town.Text.Trim().ToLower();
            string AircraftNumber1 = Fly_Town.Text.Trim().ToLower();

            if (!Regex.IsMatch(Flight_Number1, @"[\d0-9]"))
            {

                Flight_Number.ToolTip = "Некорректно введена дата вылета.";
                var backgroundColor = new BrushConverter();
                Flight_Number.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                Flight_Number.Background = Brushes.Transparent;
                Flight_Number.ToolTip = null;

                if (!Regex.IsMatch(Fly_Date1, @"[\d0-9]"))
                {

                    Fly_Date.ToolTip = "Некорректно введена дата вылета.";
                    var backgroundColor = new BrushConverter();
                    Fly_Date.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    Fly_Date.Background = Brushes.Transparent;
                    Fly_Date.ToolTip = null;

                    if (!Regex.IsMatch(Fly_Date1, @"[\d0-9]"))
                    {
                        Fly_Time.ToolTip = "Некорректно введено время вылета.";
                        var backgroundColor = new BrushConverter();
                        Fly_Time.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                    }
                    else
                    {
                        Fly_Time.Background = Brushes.Transparent;
                        Fly_Time.ToolTip = null;

                        if (!Regex.IsMatch(Fly_Town1, @"[\d0-9]"))
                        {
                            Fly_Town.ToolTip = "Некорректно введен город вылета";
                            var backgroundColor = new BrushConverter();
                            Fly_Town.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                        }
                        else
                        {
                            Fly_Town.Background = Brushes.Transparent;
                            Fly_Town.ToolTip = null;

                            if (!Regex.IsMatch(ArrivalDate1, @"[\d0-9]"))
                            {
                                Arrival_Date.ToolTip = "Некорректно введена дата прилета.";
                                var backgroundColor = new BrushConverter();
                                Arrival_Date.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                Arrival_Date.Background = Brushes.Transparent;
                                Arrival_Date.ToolTip = null;

                                if (!Regex.IsMatch(ArrivalTime1, @"[\d0-9]"))
                                {
                                    Arrival_Town.ToolTip = "Некорректно введен город прилета.";
                                    var backgroundColor = new BrushConverter();
                                    Arrival_Town.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                }
                                else
                                {
                                    Arrival_Town.Background = Brushes.Transparent;
                                    Arrival_Town.ToolTip = null;

                                    if (!Regex.IsMatch(ArrivalTown1, @"[\d0-9]"))
                                    {
                                        Arrival_Time.ToolTip = "Некорректно введено время прилета.";
                                        var backgroundColor = new BrushConverter();
                                        Arrival_Time.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                    }
                                    else
                                    {
                                        Arrival_Time.Background = Brushes.Transparent;
                                        Arrival_Time.ToolTip = null;

                                        if (!Regex.IsMatch(AircraftNumber1, @"[\d0-9]"))
                                        {
                                            Aircraft_Number.ToolTip = "Некорректно введен номер самолета.";
                                            var backgroundColor = new BrushConverter();
                                            Aircraft_Number.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                                        }
                                        else
                                        {
                                            Aircraft_Number.Background = Brushes.Transparent;
                                            Aircraft_Number.ToolTip = null;
                                            Flights addFlight = null;
                                            using (var context = new AviakompaniyaEntities())

                                            {
                                                string lor = Flight_Number1.ToString();
                                                int r = Convert.ToInt32(lor);
                                                addFlight = context.Flights.Where(check => check.Flight_Number == r).FirstOrDefault();
                                                if (addFlight == null)
                                                {



                                                    string lom = Fly_Date.Text.ToString();
                                                    DateTime v = Convert.ToDateTime(lom);

                                                    string lon = Fly_Town.Text.ToString();
                                                    int t = Convert.ToInt32(lon);


                                                    var format = new[] { "%h", "hh\\:mm" };
                                                    var m = TimeSpan.ParseExact(Fly_Time.Text, format, CultureInfo.InvariantCulture);

                                                    string lop = Arrival_Date.Text.ToString();
                                                    DateTime p = Convert.ToDateTime(lop);

                                                    string lou = Arrival_Town.Text.ToString();
                                                    int u = Convert.ToInt32(lou);

                                                    var format1 = new[] { "%h", "hh\\:mm" };
                                                    var d = TimeSpan.ParseExact(Arrival_Time.Text, format1, CultureInfo.InvariantCulture);

                                                    string loa = Aircraft_Number.Text.ToString();
                                                    int a = Convert.ToInt32(loa);

                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Flight_Number = r);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Date = v);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Time = m);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Town = t);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Date = p);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Town = u);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Time = d);
                                                    //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Aircraft_Number = a );
                                                    //context.SaveChanges();
                                                    var flght = new Flights()
                                                    {
                                                        Flight_Number = r,
                                                        Fly_Date = v,
                                                        Fly_Time = m,
                                                        Fly_Town = t,
                                                        Arrival_Date = p,
                                                        Arrival_Town = u,
                                                        Arrival_Time = d,
                                                        Aircraft_Number = a

                                                    };
                                                    context.Flights.Add(flght);
                                                    context.SaveChanges();

                                                    FlightsRecord.flightsRecord = context.Flights.Where(x => x.Flight_Number == r).Select(x => x).FirstOrDefault();

                                                    Uri Admin = new Uri("Admin.xaml", UriKind.Relative);
                                                    this.NavigationService.Navigate(Admin);
                                                }
                                                else

                                                    MessageBox.Show("Этот рейс уже существует");

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Uri admin = new Uri("Admin.xaml", UriKind.Relative);
            this.NavigationService.Navigate(admin);
           
        }

        private void TownClick(object sender, RoutedEventArgs e)
        {
            Uri ttowns = new Uri("Ttowns.xaml", UriKind.Relative);
            this.NavigationService.Navigate(ttowns);
        }
    }
}
        
            
        

       
    























