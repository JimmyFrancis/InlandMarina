using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlandMarina.ClassLibrary
{
    public static class DockDB
    {
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>();

            Dock dock; // for reading
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string query = "SELECT ID, Name, WaterService, ElectricalService FROM [Dock]";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        dock = new Dock();

                        dock.ID = (int)reader["ID"];
                        dock.Name = (string)reader["Name"];
                        dock.WaterService = (bool)reader["WaterService"];
                        dock.ElectricalService = (bool)reader["ElectricalService"];
                        

                        docks.Add(dock);
                    }
                }
            }
            return docks;
        }
    }
}
