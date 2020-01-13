using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlandMarina.ClassLibrary
{
    public static class LeaseDB
    {
        public static List<Lease> GetLeases()
        {
            List<Lease> leases = new List<Lease>();

            Lease lease; // for reading
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string query = "SELECT ID, SlipID, CustomerID FROM [Lease]";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        lease = new Lease();

                        lease.ID = (int)reader["ID"];
                        lease.SlipID = (int)reader["SlipID"];
                        lease.CustomerID = (int)reader["CustomerID"];



                        leases.Add(lease);
                    }
                }
            }
            return leases;
        }
    }
}
