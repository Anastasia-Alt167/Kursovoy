using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PersonalAccount.xaml
    /// </summary>
    public partial class PersonalAccount : Page
    {
        public PersonalAccount()
        {

            InitializeComponent();
            using (var context = new AviakompaniyaEntities())
            {
                Name.Text = context.Passengers.Where(x => x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number).Select(x => x.Name).FirstOrDefault()?.ToString();

                Surname.Text = context.Passengers.Where(x => x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number).Select(x => x.Surname).FirstOrDefault()?.ToString();
                MiddleName.Text = context.Passengers.Where(x => x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number).Select(x => x.Middle_Name).FirstOrDefault()?.ToString();
                //data
                LoginRed.Text = context.Passengers.Where(x => x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number).Select(x => x.Login).FirstOrDefault()?.ToString();
                PasswordRed.Password = context.Passengers.Where(x => x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number).Select(x => x.Password).FirstOrDefault()?.ToString();
            }
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Uri PersonalAccount = new Uri("SearchTicket.xaml", UriKind.Relative);
            this.NavigationService.Navigate(PersonalAccount);
        }

        const int lengthOfFullName = 100;
        const int minLengthOfUserLoginRed = 5;
        const int maxLengthOfUserLoginRed = 25;
        const int minLengthOfUserPasswordRed = 5;
        const int maxLengthOfUserPasswordRed = 60;

        public bool CheckUserInformation(string stringToCheck) => (stringToCheck.Length < lengthOfFullName) && stringToCheck.All(c => Char.IsLetter(c));

        private void Enter_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(CheckUserInformation(Name.Text)))
            {
                Name.ToolTip = "Некорректно введено имя.";
                var backgroundColor = new BrushConverter();
                Name.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                Name.Background = Brushes.Transparent;
                Name.ToolTip = null;
                if (!(CheckUserInformation(Surname.Text)))
                {
                    Surname.ToolTip = "Некорректно введена фамилия.";
                    var backgroundColor = new BrushConverter();
                    Surname.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    Surname.Background = Brushes.Transparent;
                    Surname.ToolTip = null;
                    if (!(CheckUserInformation(MiddleName.Text)))
                    {
                        MiddleName.ToolTip = "Incorrectly entered name.";
                        var backgroundColor = new BrushConverter();
                        MiddleName.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                    }
                    else
                    {
                        MiddleName.Background = Brushes.Transparent;
                        MiddleName.ToolTip = null;
                        if (LoginRed.Text.Length <= minLengthOfUserLoginRed || LoginRed.Text.Length >= maxLengthOfUserLoginRed || !Regex.IsMatch(LoginRed.Text, @"^[\da-z]+$"))
                        {
                            LoginRed.ToolTip = "Некорректный логин.";
                            var backgroundColor = new BrushConverter();
                            LoginRed.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                        }
                        else
                            LoginRed.Background = Brushes.Transparent;
                        LoginRed.ToolTip = null;
                        if (PasswordRed.Password.Length <= minLengthOfUserPasswordRed || PasswordRed.Password.Length >= maxLengthOfUserPasswordRed || !Regex.IsMatch(PasswordRed.Password, @"^[\da-z]+$"))
                        {
                            PasswordRed.ToolTip = "Некорректный пароль.";
                            var backgroundColor = new BrushConverter();
                            PasswordRed.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                        }
                        else

                        {
                            PasswordRed.Background = Brushes.Transparent;
                            PasswordRed.ToolTip = null;
                            using (var context = new AviakompaniyaEntities())
                            {
                                (from x in context.Passengers where x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number select x).ToList().ForEach(x => x.Name = Name.Text);
                                (from x in context.Passengers where x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number select x).ToList().ForEach(x => x.Surname = Surname.Text);
                                (from x in context.Passengers where x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number select x).ToList().ForEach(x => x.Middle_Name = MiddleName.Text);
                                (from x in context.Passengers where x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number select x).ToList().ForEach(x => x.Login = LoginRed.Text);
                                (from x in context.Passengers where x.Passenger_Number == PassangerRecord.passangerRecord.Passenger_Number select x).ToList().ForEach(x => x.Password = PasswordRed.Password);
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
        }
    }

}