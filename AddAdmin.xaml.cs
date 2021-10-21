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
    //    public AddAdmin()
    //    {
    //        InitializeComponent();
    //        using (var context = new AviakompaniyaEntities())
    //        {
    //            //Flight_Number.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Flight_Number).FirstOrDefault().ToString();
    //            Fly_Date.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Date).FirstOrDefault()?.ToString();
    //            Fly_Time.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Time).FirstOrDefault()?.ToString();
    //            Fly_Town.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Fly_Town).FirstOrDefault()?.ToString();
    //            Arrival_Date.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Date).FirstOrDefault()?.ToString();
    //            Arrival_Town.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Town).FirstOrDefault()?.ToString();
    //            Arrival_Time.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Arrival_Time).FirstOrDefault()?.ToString();
    //            Aircraft_Number.Text = context.Flights.Where(x => x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number).Select(x => x.Aircraft_Number).FirstOrDefault()?.ToString();
    //        }
    //    }
    //    const int lengthOfFlightNumber = 10;
    //    const int lengthOfFlyDate = 10;
    //    const int lengthOfFlyTime = 5;
    //    const int lengthOfFlyTown = 40;
    //    const int lengthOfArrivalDate = 10;
    //    const int lengthOfArrivalTime = 5;
    //    const int lengthOfArrivalTown = 40;
    //    const int lengthOfAircraftNumber = 10;
    //    public bool CheckFlightsInformation(string stringToCheck) => (stringToCheck.Length < lengthOfFlightNumber) && stringToCheck.All(c => Char.IsLetter(c));

       private void BtnSave_Click(object sender, RoutedEventArgs e)
       {
    //        //if (!(CheckFlightsInformation(Flight_Number.Text)))
    //        //{
    //        //    Flight_Number.ToolTip = "Некорректно введен номер самолета.";
    //        //    var backgroundColor = new BrushConverter();
    //        //    Flight_Number.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        //}
    //        //else
    //        //{
    //        //    Flight_Number.Background = Brushes.Transparent;
    //        //    Flight_Number.ToolTip = null;
    //        //}
    //        if (!(CheckFlightsInformation(Fly_Date.Text)))
    //        {
    //            Fly_Date.ToolTip = "Некорректно введена дата вылета.";
    //            var backgroundColor = new BrushConverter();
    //            Fly_Date.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Fly_Date.Background = Brushes.Transparent;
    //            Fly_Date.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Fly_Time.Text)))
    //        {
    //            Fly_Time.ToolTip = "Некорректно введено время вылета.";
    //            var backgroundColor = new BrushConverter();
    //            Fly_Time.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Fly_Time.Background = Brushes.Transparent;
    //            Fly_Time.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Fly_Town.Text)))
    //        {
    //            Fly_Town.ToolTip = "Некорректно введен город вылета";
    //            var backgroundColor = new BrushConverter();
    //            Fly_Town.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Fly_Town.Background = Brushes.Transparent;
    //            Fly_Town.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Arrival_Date.Text)))
    //        {
    //            Arrival_Date.ToolTip = "Некорректно введена дата прилета.";
    //            var backgroundColor = new BrushConverter();
    //            Arrival_Date.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Arrival_Date.Background = Brushes.Transparent;
    //            Arrival_Date.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Arrival_Town.Text)))
    //        {
    //            Arrival_Town.ToolTip = "Некорректно введен город прилета.";
    //            var backgroundColor = new BrushConverter();
    //            Arrival_Town.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Arrival_Town.Background = Brushes.Transparent;
    //            Arrival_Town.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Arrival_Time.Text)))
    //        {
    //            Arrival_Time.ToolTip = "Некорректно введено время прилета.";
    //            var backgroundColor = new BrushConverter();
    //            Arrival_Time.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Arrival_Time.Background = Brushes.Transparent;
    //            Arrival_Time.ToolTip = null;
    //        }
    //        if (!(CheckFlightsInformation(Aircraft_Number.Text)))
    //        {
    //            Aircraft_Number.ToolTip = "Некорректно введен номер самолета.";
    //            var backgroundColor = new BrushConverter();
    //            Aircraft_Number.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
    //        }
    //        else
    //        {
    //            Aircraft_Number.Background = Brushes.Transparent;
    //            Aircraft_Number.ToolTip = null;
    //            using (var context = new AviakompaniyaEntities())
    //            {

    //                //(from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Flight_Number = Flight_Number.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Date = Fly_Date.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Time = Fly_Time.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Fly_Town = Fly_Town.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Date = Arrival_Date.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Town = Arrival_Town.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Arrival_Time = Arrival_Time.Text);
    //                (from x in context.Flights where x.Flight_Number == FlightsRecord.flightsRecord.Flight_Number select x).ToList().ForEach(x => x.Aircraft_Number = Aircraft_Number.Text);
    //                context.SaveChanges();
    //            }
    //        }
       }
    }
}
        






















            