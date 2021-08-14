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
        public AddAdmin()
        {
            InitializeComponent();
        }
        public string ConStr = @"Data Source=A_BOOK\SQLEXPRESS; Initial Catalog=KursProject; Integrated Security=True;";

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Flight_Number.Text))
                MessageBox.Show("Укажите номер рейса");
            else
            {
                int FN = 0;
                try
                {
                    FN = Convert.ToInt32(Flight_Number.Text);
                }
                catch
                {
                    MessageBox.Show("Введите число");
                }
                finally
                {
                    if (FN < 0)
                        MessageBox.Show("Укажите верно");
                    else
                    {
                        if (string.IsNullOrWhiteSpace(Fly_Date.Text))
                            MessageBox.Show("Укажите дату вылета");
                        else
                        {
                            if (string.IsNullOrWhiteSpace(Fly_Time.Text))
                                MessageBox.Show("Укажите время вылета");
                            else
                            {
                                if (string.IsNullOrWhiteSpace(Fly_Town.Text))
                                    MessageBox.Show("Укажите город вылета");
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(Arrival_Date.Text))
                                        MessageBox.Show("Укажите дату прилета");
                                    else
                                    {
                                        if (string.IsNullOrWhiteSpace(Arrival_Town.Text))
                                            MessageBox.Show("Укажите город прилета");
                                        else
                                        {
                                            if (string.IsNullOrWhiteSpace(Arrival_Time.Text))
                                                MessageBox.Show("Укажите время прилета");
                                            else

                                              if (string.IsNullOrWhiteSpace(Aircraft_Number.Text))
                                                MessageBox.Show("Укажите номер самолета");
                                            else
                                            {
                                                int AN = 0;
                                                try
                                                {
                                                    AN = Convert.ToInt32(Flight_Number.Text);
                                                }
                                                catch
                                                {
                                                    MessageBox.Show("Введите число");
                                                }
                                                finally
                                                {

                                                    using (SqlConnection CN = new SqlConnection(ConStr))
                                                    {
                                                        CN.Open();
                                                        SqlCommand CMMND = new SqlCommand("INSERT INTO AviakompaniyaEntities VALUES (@Flight_Number, @Fly_Date, @Fly_Time, @Fly_Town, @Arrival_Date, @Arrival_Town, @Arrival_Time, @Aircraft_Number, " +
                                                            "NULL)", CN);
                                                        CMMND.Parameters.Add("@Flight_Number", SqlDbType.NVarChar).Value = Flight_Number.Text;
                                                        CMMND.Parameters.Add("@Fly_Date", SqlDbType.Date).Value = Fly_Date.Text;
                                                        CMMND.Parameters.Add("@Fly_Time", SqlDbType.Time).Value = Fly_Time.Text;
                                                        CMMND.Parameters.Add("@Fly_Town", SqlDbType.Int).Value = Fly_Town.Text;
                                                        CMMND.Parameters.Add("@Arrival_Date", SqlDbType.Date).Value = Arrival_Date.Text;
                                                        CMMND.Parameters.Add("@Arrival_Town", SqlDbType.Int).Value = Arrival_Town.Text;
                                                        CMMND.Parameters.Add("@Arrival_Time", SqlDbType.Time).Value = Arrival_Time.Text;
                                                        CMMND.Parameters.Add("@Aircraft_Number", SqlDbType.Int).Value = Aircraft_Number.Text;

                                                        CMMND.ExecuteNonQuery();
                                                        CN.Close();
                                                        MessageBox.Show("Информация сохранена");
                                                        Uri addadmin = new Uri("AddAdmin.xaml", UriKind.Relative);
                                                        this.NavigationService.Navigate(addadmin);
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
            }
        }
    }
}