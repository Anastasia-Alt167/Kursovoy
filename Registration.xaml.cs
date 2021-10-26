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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public static class PassangerRecord
    {
        public static Passengers passangerRecord;
    }
    public static class AdminRecord
    {
        public static Admins adminRecord;
    }
    public partial class Registration : Page
    {
        public Registration()
        {
           // InitializeComponent();
        }
        const int minLengthOfUserName = 2;
        const int maxLengthOfUserName = 25;
        const int minLengthOfUserSurname = 4;
        const int maxLengthOfUserSurname = 25;
        const int minLengthOfUserMiddleName = 4;
        const int maxLengthOfUserMiddleName = 25;
        
       
        const int minLengthOfUserLoginReg = 5;
        const int maxLengthOfUserLoginReg = 25;
        const int minLengthOfUserPasswordReg = 5;
        const int maxLengthOfUserPasswordReg = 60;
        
        
        public bool CheckNameInformation(string stringToCheck) => (stringToCheck.Length > minLengthOfUserName) && (stringToCheck.Length < maxLengthOfUserName) && stringToCheck.All(c => Char.IsLetter(c));
        public bool CheckSurnameInformation(string stringToCheck) => (stringToCheck.Length > minLengthOfUserSurname) && (stringToCheck.Length < maxLengthOfUserSurname) && stringToCheck.All(c => Char.IsLetter(c));
        public bool CheckMiddleNameInformation(string stringToCheck) => (stringToCheck.Length > minLengthOfUserMiddleName) && (stringToCheck.Length < maxLengthOfUserMiddleName) && stringToCheck.All(c => Char.IsLetter(c));

        private void ButtonReg_Click(object sender, RoutedEventArgs e) 
        {
            string UserName = Name.Text.Trim().ToLower();
            string UserSurname = Surname.Text.Trim().ToLower();
            string UserMiddleName = MiddleName.Text.Trim().ToLower();
           
     
            string UserLoginReg = LoginReg.Text.Trim().ToLower();
            string UserPasswordReg = PasswordReg.Password.Trim();

            if (!(CheckNameInformation(Name.Text)))  //if (UserName.Length <= minLengthOfUserName || UserName.Length >= maxLengthOfUserName || !Regex.IsMatch(UserName, @"[\dа-я]"))
            {
                Name.ToolTip = $"Слишком короткий {minLengthOfUserName} символов или больше {maxLengthOfUserName} символов.";
                var backgroundColor = new BrushConverter();
                Name.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
            }
            else
            {
                Name.Background = Brushes.Transparent;
                Name.ToolTip = null;
                if (!(CheckSurnameInformation(Surname.Text))) //if (UserSurname.Length <= minLengthOfUserSurname || UserSurname.Length >= maxLengthOfUserSurname || !Regex.IsMatch(UserSurname, @"[\dа-я]"))
                { 
                    Surname.ToolTip = $"Слишком короткий {minLengthOfUserSurname} символов или больше {maxLengthOfUserSurname} символов.";
                    var backgroundColor = new BrushConverter();
                    Surname.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                { 
                Surname.Background = Brushes.Transparent;
                Surname.ToolTip = null;
                    if (!(CheckMiddleNameInformation(MiddleName.Text)))  // if (UserMiddleName.Length <= minLengthOfUserMiddleName || UserMiddleName.Length >= maxLengthOfUserMiddleName || !Regex.IsMatch(UserMiddleName, @"[\dа-я]"))
                    {
                    MiddleName.ToolTip = $"Слишком короткий {minLengthOfUserMiddleName} символов или больше {maxLengthOfUserMiddleName} символов.";
                    var backgroundColor = new BrushConverter();
                    MiddleName.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                    { 
                MiddleName.Background = Brushes.Transparent;
                MiddleName.ToolTip = null;
                if (UserLoginReg.Length <= minLengthOfUserLoginReg || UserLoginReg.Length >= maxLengthOfUserLoginReg || !Regex.IsMatch(UserLoginReg, @"^[\da-z]+$"))
                {
                    LoginReg.ToolTip = $"Логин слишком короткий {minLengthOfUserLoginReg} символов или больше {maxLengthOfUserLoginReg} символов.";
                    var backgroundColor = new BrushConverter();
                    LoginReg.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                }
                else
                {
                    LoginReg.Background = Brushes.Transparent;
                    LoginReg.ToolTip = null;
                            if (UserPasswordReg.Length <= minLengthOfUserPasswordReg || UserPasswordReg.Length >= maxLengthOfUserPasswordReg || !Regex.IsMatch(UserPasswordReg, @"^[\da-z]+$"))
                            {
                                PasswordReg.ToolTip = $"Пароль слишком короткий {minLengthOfUserPasswordReg} символов или больше {maxLengthOfUserPasswordReg} символов.";
                                var backgroundColor = new BrushConverter();
                                PasswordReg.Background = (Brush)backgroundColor.ConvertFrom("#FFFF5E5B");
                            }
                            else
                            {
                                PasswordReg.Background = Brushes.Transparent;
                                PasswordReg.ToolTip = null;
                                Passengers regUser = null;
                                using (var context = new AviakompaniyaEntities())
                                {

                                    regUser = context.Passengers.Where(check => check.Login == UserLoginReg).FirstOrDefault();
                                    if (regUser == null)
                                    {
                                        var user = new Passengers()
                                        {
                                            Login = UserLoginReg,
                                            Password = UserPasswordReg,
                                            Surname = UserSurname,
                                            Name = UserName,
                                            Middle_Name = UserMiddleName,
                                            Date_of_Birth = null
                                        };
                                        context.Passengers.Add(user);
                                        context.SaveChanges();

                                        PassangerRecord.passangerRecord = context.Passengers.Where(x => x.Login == UserLoginReg).Select(x => x).FirstOrDefault();

                                        Uri SearchTicket = new Uri("SearchTicket.xaml", UriKind.Relative);
                                        this.NavigationService.Navigate(SearchTicket);
                                    }
                                    else

                                        MessageBox.Show("Этот логин уже зарегестрирован");

                                }
                            }  }
                    }
                }
            }
        }

        private void Button_KReg_Click(object sender, RoutedEventArgs e)
        {
            Uri Authorization = new Uri("Authorization.xaml", UriKind.Relative);
            this.NavigationService.Navigate(Authorization);
        }
    }
}

