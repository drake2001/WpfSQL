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
using System.Configuration;
using System.Data.SqlClient;

namespace WpfSQL.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private string connectionString;
        private string query;
        public Page2()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool passtrue = false;
            if (PassBox.Text == PassBox2.Text)
            {
                passtrue = true;

                if (LoginBox.Text != null && PassBox.Text != null && FamilyBox.Text != null && passtrue == true && NameBox.Text != null && otchestvoBox.Text != null)
                {
                    try
                    {
                        string query = "INSERT INTO [dbo].[Polzovateli_1$] ([Login],[Password],[Фамилия],[Имя],[отчество],[Role]) VALUES ( @Login, @Password, @Фамилия, @Имя , @отчество, @Role)";


                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        command.Parameters.AddWithValue("@Login", LoginBox.Text);
                        command.Parameters.AddWithValue("@Password", PassBox.Text);
                        command.Parameters.AddWithValue("@Фамилия", FamilyBox.Text);
                        command.Parameters.AddWithValue("@Имя", NameBox.Text);
                        command.Parameters.AddWithValue("@отчество", otchestvoBox.Text);
                        command.Parameters.AddWithValue("@Role", "Заказчик");
                        command.ExecuteNonQuery();
                        MessageBox.Show("Пользователь зарегестрирован");
                        NavigationService.Navigate(new AuthPage());
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }

                }
                else
                {
                    MessageBox.Show("Вы не заполнили все поля");
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
            
            
        }
    }
}
