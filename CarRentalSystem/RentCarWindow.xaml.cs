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
    /// Interaction logic for RentCarWindow.xaml
    /// </summary>
    public partial class RentCarWindow : Window
    {
        string firstname, lastname, email, phoneNumber, address,
                carBrand, carID, driverLicenseID;
        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating the database Connection
        SqlConnection connection;
        //Creating the Sql command
        SqlCommand command;

        private void CbCarID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string Query = "SELECT * FROM CarDetails where CarID = '"+ CbCarID.Text+ "'";
                command = new SqlCommand(Query, connection);
                //command.ExecuteNonQuery();
                SqlDataReader myreader = command.ExecuteReader();

                while (myreader.Read())
                {
                    //string CarBrand = myreader.GetString(1);
                    //string CarModel = myreader.GetString(2);
                    //string TransmissionType = myreader.GetString(3);
                    //string VIN = myreader.GetString(4);
                    //string CarColor = myreader.GetString(5);

                    txtCarBrand.Text = myreader["CarBrand"].ToString();
                    txtCarModel.Text = myreader["CarModel"].ToString();
                    txtVIN.Text = myreader["VIN"].ToString();
                    txtTransmissionType.Text = myreader["TransmissionType"].ToString();

                }
                connection.Close();

            }
            catch (Exception ex)
            {

            }
        }

        void fill_combo()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string Query = "SELECT * FROM CarDetails";
                command = new SqlCommand(Query, connection);
                //command.ExecuteNonQuery();
                SqlDataReader myreader = command.ExecuteReader();

                while (myreader.Read())
                {
                    int ID = myreader.GetInt32(0);
                    CbCarID.Items.Add(ID);
                }
                connection.Close();

            }
            catch (Exception ex)
            {

            }
        }
        

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RentForm.Visibility = Visibility.Visible;
        }

        public RentCarWindow()
        {
            InitializeComponent();
            fill_combo();
        }

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            this.RentForm.Visibility = Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LandingWindow landingWindow = new LandingWindow();
            landingWindow.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.RentForm.Visibility = Visibility.Hidden;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtCarBrand.Text = "";
            txtAddress.Text = "";
            txtDriverLicenseID.Text = "";
        }


        /// <summary>
        /// Save Rented Car into another Table and delete it from the present Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
            firstname = txtFirstName.Text;
            lastname = txtLastName.Text;
            email = txtEmail.Text;
            phoneNumber = txtPhoneNumber.Text;
            carBrand = txtCarBrand.Text;
            driverLicenseID = txtDriverLicenseID.Text;
            address = txtAddress.Text;
            
            try
            {

                connection = new SqlConnection(connectionString);
                connection.Open();

                string insertQuery = "INSERT INTO Rent (FirstName, LastName, phoneNumber,Email,DriverLicenseID,CarID,Address) VALUES ('" + firstname + "','" + lastname + "','" + phoneNumber + "','" + email + "','" + driverLicenseID + "','" + address + "')";

                command = new SqlCommand(insertQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Successfully Rented");

                connection = new SqlConnection(connectionString);
                connection.Open();
                string deleteQuery = "DELETE FROM CarDetails Where CarID = '" + carID + "'";
                command = new SqlCommand(deleteQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Delete successfull");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
