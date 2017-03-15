using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating the Sql Connection
        SqlConnection connection;
        SqlCommand command;
        public Search()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.listView.Visibility = Visibility.Visible;
            connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string Query = "SELECT * FROM CarDetails where CarBrand = '" + txtSearch.Text + "'";

                command = new SqlCommand(Query, connection);
                //command.ExecuteNonQuery();
                SqlDataReader myreader = command.ExecuteReader();

                listView.Items.Clear();
                while (myreader.Read())
                {
                    int ID = myreader.GetInt32(0);
                    string carBrand = myreader.GetString(1);
                    string carModel = myreader.GetString(2);
                    string VIN = myreader.GetString(3);
                    string TransmissionType = myreader.GetString(4);
                    string carColor = myreader.GetString(5);
                    listView.Items.Add(ID+" "+carBrand+" "+carModel+" "+VIN+" "+TransmissionType+" "+carColor);
                }
                connection.Close();
            }
            catch (Exception ex){ }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            LandingWindow landingwindow = new LandingWindow();
            landingwindow.Show();
            this.Close();
        }
    }
}
