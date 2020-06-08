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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    /// 

  
    public partial class AuthPage : Page
    {
        private string connectionString;
        
        public AuthPage()
        {
            InitializeComponent();
             connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                //   MessageBox.Show ($"Сервер: {connection.DataSource}; База данных: {connection.State.ToString()};Состояние: подключено.");
            }

            catch (SqlException)

            {

                MessageBox.Show("Подключение не выполнено!");

            }
        }

       

        private void Login(object sender, RoutedEventArgs e)
        {

            string query = "SELECT Login, Password, Role FROM dbo.Polzovateli_1$ Where login = @Login AND password = @Password";
            

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", LoginBox.Text);
            command.Parameters.AddWithValue("@Password", PassBox.Text);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

           
            while (reader.Read())
            { string Role = reader[2].ToString();
                switch (Role)
                {

                case "Менеджер":
                    NavigationService.Navigate(new Page1());
                    break;
                case "2":

                    break;
            }
                
                MessageBox.Show("Вход выполнен"); return;
            }
            MessageBox.Show("Вход не выполнен");

            
           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
