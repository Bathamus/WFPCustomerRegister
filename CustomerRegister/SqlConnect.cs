using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CustomerRegister
{
    public class SqlConnect
    {
        public SqlConnection SqlConnection { get; set; }
        private string connectionString { get; set; }

        public void ConnectionOpen()
        {
            connectionString = @"Server=(localdb)\mssqllocaldb;Database=CustomerRegisterDb;Trusted_Connection=Yes;";
            SqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlConnection.Open();
            }
            catch
            {
                MessageBox.Show("Could not connect to database");
            }
        }
        public void ConnectionClose()
        {
            SqlConnection.Close();
        }

        public ConnectionState State()
        {
            return SqlConnection.State;
        }
    }
}
