using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace finals_UI.Model.Database
{
    internal class dbConnection
    {
        private readonly string cs = "Server=localhost; Port=3308; Database=car_service_db;User ID=root;SslMode=None;";
        private MySqlConnection con;

        // Constructor
        public dbConnection()
        {
            con = new MySqlConnection(cs);
        }

        // Open Connection
        public void openConnection()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                    Console.WriteLine("Database Connected.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
            }
        }

        // Close Connection
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                Console.WriteLine("Connection Closed.");
            }
        }

        // Get Connection Object 
        public MySqlConnection getConnection()
        {
            return con;
        }
   }
}
