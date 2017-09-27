

using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CustomerRegister
{
    public class DbCommands
    {
        public ObservableCollection<Customer> GetAllCustomers()
        {
            var customersList = new ObservableCollection<Customer>();
            SqlConnect connection = new SqlConnect();
            connection.ConnectionOpen();

            if (connection != null && connection.State() == ConnectionState.Open)
            {
                var command = new SqlCommand("SELECT * FROM Customer", connection.SqlConnection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customersList.Add(ReadSingleRow((IDataRecord)reader));
                }

                connection.ConnectionClose();
            }
            else
            {
                MessageBox.Show("Cannot connect to database!");
            }

            return customersList;
        }

        public void AddCustomerToDb(Customer customer)
        {
            SqlConnect connection = new SqlConnect();
            connection.ConnectionOpen();

            connection.ConnectionClose();

            //string Get_Data = "SELECT * FROM Customer";

            //SqlCommand cmd = new SqlCommand();
            //cmd. = Get_Data;

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable("emp");
            //sda.Fill(dt);

            //dataGrid1.ItemsSource = dt.DefaultView;
        }

        private Customer ReadSingleRow(IDataRecord record)
        {
            return new Customer
            {
                CustomerId = record.GetInt32(0),
                FirstName = record.GetString(1)
            };
        }
    }
}
