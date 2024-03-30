using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Una función que retorne una lista de estudiantes usando un datatable(2 puntos)

            string connectionString = "Data Source=LAB1504-11\\SQLEXPRESS;Initial Catalog=BDMyriam;User Id=MyriamRoxana;" +
                "Password=123456";
        private void Button_Click_DataTable(object sender, RoutedEventArgs e)
        {

            //NameServer, NameDataBase, User, Password

            try { 
            
                //
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);
                


                DataTable dataTable = new DataTable();
                //traduce 
                SqlDataAdapter adapter = new SqlDataAdapter(command);


                adapter.Fill(dataTable);

               

                dvgDemo.ItemsSource = dataTable.DefaultView;

                 connection.Close();

            }

            catch (SqlException ex) {
                MessageBox.Show("No se pudo conectar a la base de datos Error: " + ex.ToString());
            
            }

        }

        private void Button_Click_Reader(object sender, RoutedEventArgs e)
        {
            List<Students> students = new List<Students>(); 
            
            try {


                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Student", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())

                    {
                    //Student es entero :
                     string Studend = reader.GetInt32("Studend").ToString();
                     string FirstName = reader.GetString("FirstName");
                     string LastName = reader.GetString("LastName");

                      students.Add(new Students { FirstName = FirstName, LastName = LastName });
                   }

                connection.Close();

                dvgDemo.ItemsSource = students;
               

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}