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
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {

        //Connection String for the database
        string connectionString = @"Data Source =.; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False; Initial Catalog = CarRental";
        //creating the database connection
        SqlConnection connection;

        DataSet ds;
        SqlDataAdapter da;
        public LandingWindow()
        {
            InitializeComponent();

        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addcar = new AddCarWindow();
            addcar.Show();
            this.Hide();
        }

        private void btnModifyCar_Click(object sender, RoutedEventArgs e)
        {
            ModifyCarWindow modifycar = new ModifyCarWindow();
            modifycar.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Hide();
        }

        private void btnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            DeleteCarWindow deletecar = new DeleteCarWindow();
            deletecar.Show();
            this.Hide();
        }

        private void btnRentCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RentCarWindow rentcar = new RentCarWindow();
                rentcar.Show();
                this.Hide();

                connection = new SqlConnection(connectionString);
                connection.Open();
                da = new SqlDataAdapter("SELECT * FROM CarDetails", connection);
                ds = new DataSet();
                da.Fill(ds, "emp");
                rentcar.listView.DataContext = ds.Tables["emp"].DefaultView;
                connection.Close();

                connection.Open();
                da = new SqlDataAdapter("SELECT * FROM Rent", connection);
                ds = new DataSet();
                da.Fill(ds, "emp");
                rentcar.listView2.DataContext = ds.Tables["emp"].DefaultView;
                connection.Close();
            }
            catch(SqlException sql) { }
        }

        private void btnSearchCar_Click(object sender, RoutedEventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Close();
        }
    }
}
