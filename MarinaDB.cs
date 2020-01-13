using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlandMarina.ClassLibrary
{
    public static class MarinaDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS01; Initial Catalog = Marina; Integrated Security = True";
            return new SqlConnection(connectionString);
        }
    }
}
