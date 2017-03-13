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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.IO;

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
        string strName, imageName;

        //Variables to hold inputs from the user 
        string carBrand, carModel, VIN, transmissionType, carColor;

        //private byte[] _imageBytes = null;

       
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                dialog.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                dialog.ShowDialog();
                {
                    strName = dialog.SafeFileName;
                    imageName = dialog.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    image.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
                }
                dialog = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

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
                    //Initialize a file stream to read the image file
                    FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                    //Initialize a byte array with size of stream
                    byte[] imgByteArr = new byte[fs.Length];

                    //Read data from the file stream and put into the byte array
                    fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                    //Close a file stream
                    fs.Close();

                    //Query to Insert data into the CarDetails table in the CarRental
                    string query = "INSERT INTO CarDetails (CarBrand,CarModel,VIN,TransmissionType,CarColor,ImgName,img)VALUES('" + carBrand + "','" + carModel + "','" + VIN + "','" + transmissionType + "','" + carColor + "','" + strName + "',@img)";

                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    command = new SqlCommand(query, connection);
                    //Pass byte array into database
                    command.Parameters.Add(new SqlParameter("img", imgByteArr));
                    int result = command.ExecuteNonQuery();
                    if (result == 1)
                    {
                        MessageBox.Show("Image added successfully.");
                    }
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
