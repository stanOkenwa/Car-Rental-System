using System.Windows;
using System.Data.SqlClient;

namespace CarRentalSystem
{
    /// <summary>
    /// Interaction logic for AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {

        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating Sql command
        SqlCommand command;

        //Variables to hold inputs from the user 
        string carBrand, carModel, VIN, transmissionType, carColor;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtCarBrand.Clear();
            txtCarModel.Clear();
            txtTransmissionType.Clear();
            txtVIN.Clear();
            txtCarColor.Clear();
        }

        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LandingWindow landingwindow = new LandingWindow();
            landingwindow.Show();
            this.Hide();
        }

        /// <summary>
        /// Click event for the save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //Assigning input from the user to the variables declared above
            carBrand = txtCarBrand.Text;
            carModel = txtCarModel.Text;
            VIN = txtVIN.Text;
            transmissionType = txtTransmissionType.Text;
            carColor = txtCarColor.Text;

            //Validating to check if fields are empty
            if (txtCarBrand.Text == "" || txtCarColor.Text == "" || txtCarModel.Text == "" || txtTransmissionType.Text == "" || txtVIN.Text == "")
            {
                MessageBox.Show("Fields Cannot be empty");
            }
            else
            {
                try
                {
                    //Query to Insert data into the CarDetails table in the CarRental
                    string query = "INSERT INTO CarDetails (CarBrand,CarModel,VIN,TransmissionType,CarColor,ImgName,img)VALUES('" + carBrand + "','" + carModel + "','" + VIN + "','" + transmissionType + "','" + carColor + "')";

                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(query, connection);               
                    //command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Car Successfully added");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
