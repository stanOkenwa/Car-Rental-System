using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for RentCarWindow.xaml
    /// </summary>
    public partial class RentCarWindow : Window
    {
        string firstname, lastname, email, phoneNumber, address,
                carBrand, carID, driverLicenseID,carColor,transmissionType,VIN,carModel;
        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating the database Connection
        SqlConnection connection;
        //Creating the Sql command
        SqlCommand command;

        /// <summary>
        /// Populating data from the database to the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCarID_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string Query = "SELECT * FROM CarDetails where CarID = '" + CbCarID.Text + "'";
                command = new SqlCommand(Query, connection);
                //command.ExecuteNonQuery();
                SqlDataReader myreader = command.ExecuteReader();

                while (myreader.Read())
                {
                    string CarBrand = myreader.GetString(1);
                    string CarModel = myreader.GetString(2);
                    string TransmissionType = myreader.GetString(3);
                    string VIN = myreader.GetString(4);
                    string CarColor = myreader.GetString(5);

                    txtCarBrand.Text = CarBrand;
                    txtCarModel.Text = CarModel;
                    txtVIN.Text = VIN;
                    txtTransmissionType.Text = TransmissionType;
                    txtCarColor.Text = CarColor;

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
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtCarBrand.Clear();
            txtAddress.Clear();
            txtDriverLicenseID.Clear();
            CbCarID.Equals("");
            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtTransmissionType.Clear();
            txtVIN.Clear();
            txtCarColor.Clear();
        }


        /// <summary>
        /// Save Rented Car into another Table and delete it from the present Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (txtFirstName.Text.Equals(""))
            {
                MessageBox.Show("Firstname is reqiured");
            }
            else if (txtLastName.Text.Equals(""))
            {
                MessageBox.Show("Lastname is required");
            }
            else if (txtPhoneNumber.Text.Equals(""))
            {
                MessageBox.Show("Phone Number Field cannot be Empty");
            }
            else if (txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Email is required");
            }
            else if (txtDriverLicenseID.Text.Equals(""))
            {
                MessageBox.Show("Enter Transmission Type");
            }
            else if (txtAddress.Text.Equals(""))
            {
                MessageBox.Show("Enter Car Brand");
            }
            else if (txtCarBrand.Text.Equals(""))
            {
                MessageBox.Show("Enter Car Model");
            }
            else if (txtCarModel.Text.Equals(""))
            {
                MessageBox.Show("Address is required");
            }
            else if (txtTransmissionType.Text.Equals(""))
            {
                MessageBox.Show("Enter the Transmission Type");
            }
            else if (txtVIN.Text.Equals(""))
            {
                MessageBox.Show("Enter Vehicle Identification Number");
            }
            else if (txtCarColor.Text.Equals(""))
            {
                MessageBox.Show("Enter Car Color");
            }
            else
            {
                firstname = txtFirstName.Text;
                lastname = txtLastName.Text;
                email = txtEmail.Text;
                phoneNumber = txtPhoneNumber.Text;
                carBrand = txtCarBrand.Text;
                driverLicenseID = txtDriverLicenseID.Text;
                address = txtAddress.Text;
                carModel = txtCarModel.Text;
                carID = CbCarID.Text;
                carColor = txtCarColor.Text;
                transmissionType = txtTransmissionType.Text;
                VIN = txtVIN.Text;

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    string insertQuery = "INSERT INTO Rent (FirstName, LastName, phoneNumber,Email,DriverLicenseID,Address,CarID,CarBrand,CarModel,TransmissionType,VIN,CarColor) VALUES ('" + firstname + "','" + lastname + "','" + phoneNumber + "','" + email + "','" + driverLicenseID + "','" + address + "','" + carID + "','" + carBrand + "','" + carModel + "','" + transmissionType + "','" + VIN + "','" + carColor + "')";

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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
