using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marina
{
    public static class SlipDB
    {
        public static List<Slip> GetSlips()
        {
            List<Slip> slips = new List<Slip>();

            Slip slip; // for reading
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string query = "SELECT ID, Width, Length, DockID FROM [Dock]";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        slip = new Slip();

                        slip.ID = (int)reader["ID"];
                        slip.Width = (int)reader["Width"];
                        slip.Length = (int)reader["Length"];
                        slip.DockID = (int)reader["DockID"];

                        slips.Add(slip);
                    }
                }
            }
            return slips;
        }
    }
}
