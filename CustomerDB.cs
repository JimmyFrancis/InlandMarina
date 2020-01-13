using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlandMarina.ClassLibrary
{
    public static class CustomerDB
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            Customer cust; // for reading
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string query = "SELECT ID, FirstName, LastName, Phone, City FROM [Customer]";
                               
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        cust = new Customer();

                        cust.ID = (int)reader["ID"];
                        cust.FirstName = (string)reader["FirstName"];
                        cust.LastName = (string)reader["LastName"];
                        cust.Phone = (string)reader["Phone"];
                        cust.City = (string)reader["City"];

                        customers.Add(cust);
                    }
                }
            }
            return customers;
        }
    }
}
