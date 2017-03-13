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
using System.Windows.Shapes;

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for ModifyCarWindow.xaml
    /// </summary>
    public partial class ModifyCarWindow : Window
    {
        //Variables to hold inputs from the user 
        string carBrand, carModel, VIN, transmissionType, carColor, carID;


        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating the database Connection
        SqlConnection connection;
        //Creating the Sql command
        SqlCommand command;



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            carID = txtModifyCar.Text;   
            string query = "SELECT * FROM CarDetails WHERE CarID = @carId";

            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@carId", carID);
            SqlDataReader myReader = command.ExecuteReader();
            
            /*Using SqlDataReader loop through the database and display the data in textbox */
            while (myReader.Read())
            {
                txtCarBrand.Text = myReader["CarBrand"].ToString();
                txtCarModel.Text = myReader["CarModel"].ToString();
                txtVIN.Text = myReader["VIN"].ToString();
                txtTransmissionType.Text = myReader["TransmissionType"].ToString();
                txtCarColor.Text = myReader["CarColor"].ToString();
            } 
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCarBrand.Text = "Car Brand";
            txtCarModel.Text = "Car Model";
            txtVIN.Text = "VIN";
            txtTransmissionType.Text = "Transmission Type";
            txtCarColor.Text = "Car Color";
        }

        public ModifyCarWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LandingWindow landwindow = new LandingWindow();
            landwindow.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Assigning input from the user to the variables declared above
            carBrand = txtCarBrand.Text;
            carModel = txtCarModel.Text;
            VIN = txtVIN.Text;
            transmissionType = txtTransmissionType.Text;
            carColor = txtCarColor.Text;

            try
            {
                //Query to Insert data into the CarDetails table in the CarRental
                string query = "UPDATE CarDetails SET CarBrand = '"+carBrand+"', CarModel = '"+carModel+"',VIN = '"+VIN+"',TransmissionType = '"+transmissionType+"',CarColor = '"+carColor+"' WHERE CarID = '"+carID+"'";

                connection = new SqlConnection(connectionString);
                command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated");
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
