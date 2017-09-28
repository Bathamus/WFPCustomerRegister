

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
            var insertCommand = "INSERT INTO CUSTOMER (FirstName, LastName, Address, PhoneNumber," +
                                " Email, DateOfBirth, CompanyName, NewsLetter, AdditionalNotes) values " +
                                "(@firstName, @lastName, @address, @phoneNumber," +
                                " @email, @dateOfBirth, @companyName, @newsLetter, @additionalNotes)";

            SqlConnect connection = new SqlConnect();
            connection.ConnectionOpen();

            if (connection != null && connection.State() == ConnectionState.Open)
            {
                var command = new SqlCommand(insertCommand, connection.SqlConnection);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@address", customer.Address);
                command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@dateOfBirth", customer.DateOfBirth);
                command.Parameters.AddWithValue("@companyName", customer.CompanyName);
                command.Parameters.AddWithValue("@newsLetter", customer.NewsLetter);
                command.Parameters.AddWithValue("@additionalNotes", customer.AdditionalNotes);
                command.ExecuteNonQuery();
                connection.ConnectionClose();
            }
            else
            {
                MessageBox.Show("Cannot connect to database!");
            }
        }

        private Customer ReadSingleRow(IDataRecord record)
        {
            return new Customer
            {
                CustomerId = record.GetInt32(0),
                FirstName = record.GetString(1),
                LastName = record.GetString(2),
                Address = record.GetString(3),
                PhoneNumber = record.GetString(4),
                Email = record.GetString(5),
                DateOfBirth = record.GetDateTime(6),
                CompanyName = record.GetString(7),
                NewsLetter = record.GetBoolean(8),
                AdditionalNotes = record.GetString(9)
            };
        }
    }
}
