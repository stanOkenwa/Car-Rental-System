using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for DeleteCarWindow.xaml
    /// </summary>
    public partial class DeleteCarWindow : Window
    {
        //Connection string for database connection
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //Creating the Sql Connection
        SqlConnection connection;
        DataSet ds;
        public DeleteCarWindow()
        {
            InitializeComponent();
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LandingWindow landingwindow = new LandingWindow();
            landingwindow.Show();
            this.Hide();


            //Connection string for database connection
            string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
            //Creating the Sql Connection
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //SQL QUERY STATEMENT AND COMMAND WOULD BE IN HERE
            connection.Close();
            







        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string CarId = txtDeleteCar.Text;
            try
            {
                //Query to Insert data into the CarDetails table in the CarRental
                string query = "SELECT * FROM CarDetails WHERE CarID = @carId";
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@carId",CarId);
                SqlDataReader myReader = command.ExecuteReader();

                /*Using SqlDataReader loop through the database and display the data in textbox */
                while (myReader.Read())
                {
                    txtCarBrand.Text = myReader["CarBrand"].ToString();
                    txtCarModel.Text = myReader["CarModel"].ToString();
                    txtVIN.Text = myReader["VIN"].ToString();
                    txtTransmissionType.Text = myReader["TransmissionType"].ToString();
                    txtCarColor.Text = myReader["CarColor"].ToString();

                    //if (!myReader.IsDBNull(0))
                    //{
                    //    try
                    //    {
                    //        ///Converting the image into bitmap
                    //        byte[] photo = (byte[])myReader[0];
                    //        MemoryStream ms = new MemoryStream(photo);
                    //        Bitmap bm = new Bitmap(ms);
                            
                    //    }
                    //}
                    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Query to Insert data into the CarDetails table in the CarRental
                string query = "DELETE FROM CarDetails Where CarID = '"+txtDeleteCar.Text+"'";
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                if(txtDeleteCar.Text =="")
                {
                    MessageBox.Show("Please type in a Car ID");
                }
                else
                {
                    MessageBox.Show("Successfully Deleted");
                }
            }
            catch{ }
        }
    }
}
