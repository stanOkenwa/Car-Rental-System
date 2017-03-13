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

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating Sql command
        SqlCommand command;
        //Creating the Sql connection
        SqlConnection connection;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            string password, username;
            password = txtPassword.Password;
            username = txtUsername.Text;

            if (username.Equals(""))
            {
                MessageBox.Show("Enter username");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Enter password");
            }
            else
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Select * from Admin where Username = '" + username + "' and Password = '" + password + "'";
                command = new SqlCommand(query, connection);
                SqlDataReader myReader = command.ExecuteReader();

                int count = 0;
                while (myReader.Read())
                {
                    count += 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("OK");
                    LandingWindow landingwindow = new LandingWindow();
                    landingwindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("username and password not correct");
                }
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }
    }
}
