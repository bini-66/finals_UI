using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using finals_UI.Model.classes;
using finals_UI.Model.Database;

namespace finals_UI.Controller
{
    internal class appointmentController
    {
        public DataSet loadAppointments()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT a.appointmentId, v.plateNumber, a.date, a.time, " +
                "a.appointmentStatus, a.description, c.firstName, c.lastName, c.phone " +
                "FROM appointment a " +
                "INNER JOIN vehicle v ON a.vehicleId = v.vehicleId " +
                "INNER JOIN customer c ON a.customerId = c.customerId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        public DataSet searchAppointments(string search)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT a.appointmentId, v.plateNumber, a.date, a.time, " +
                "a.appointmentStatus, a.description, c.firstName, c.lastName, c.phone " +
                "FROM appointment a " +
                "INNER JOIN vehicle v ON a.vehicleId = v.vehicleId " +
                "INNER JOIN customer c ON a.customerId = c.customerId " +
                "WHERE v.plateNumber LIKE @search OR c.firstName LIKE @search OR c.lastName LIKE @search";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@search", "%" + search + "%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        public DataSet searchCustomer(string search)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT c.customerId AS 'Customer ID', CONCAT(c.firstName, ' ', c.lastName) AS Name, " +
                  "c.phone AS 'Phone Number', v.vehicleId AS 'Vehicle ID', v.plateNumber as 'Vehicle Plate' " +
                  "FROM customer c " +
                  "INNER JOIN vehicle v ON c.customerId = v.customerId " +
                  "WHERE v.plateNumber LIKE @search " +
                  "OR c.firstName LIKE @search " +
                  "OR c.lastName LIKE @search " +
                  "OR c.customerId LIKE @search " +
                  "OR c.phone LIKE @search";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@search", "%" + search + "%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        public List<string> getUnavailableSlots(DateTime date)
        {
            List<string> unavailableSlots = new List<string>();

            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT time FROM appointment WHERE date = @date";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

            //data reader class
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                unavailableSlots.Add(reader["time"].ToString());
            }
            reader.Close();
            con.closeConnection();

            return unavailableSlots;
        }

        public List<KeyValuePair<int,string>> getServices()
        {
            List<KeyValuePair<int, string>> services = new List<KeyValuePair<int, string>>();
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();
                //command class
                string query = "SELECT serviceId, serviceName FROM service";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("serviceId");
                    string name = reader.GetString("serviceName");
                    services.Add(new KeyValuePair<int, string>(id, name));
                }
                reader.Close();
                con.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return services;
        }

        public void saveAppointmentServices(int appointmentId, List<int> selectedServiceIds)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                foreach (int serviceId in selectedServiceIds)
                {
                    string query = "INSERT INTO appointment_service (appointmentId, serviceId) VALUES (@appointmentId, @serviceId)";
                    MySqlCommand com = new MySqlCommand(query, con.getConnection());
                    com.Parameters.AddWithValue("@appointmentId", appointmentId);
                    com.Parameters.AddWithValue("@serviceId", serviceId);
                    com.ExecuteNonQuery();
                }
                con.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public int saveAppointment(string date, string time, string status, string description, int customerId, int vehicleId)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();
                //command class
                string query = "INSERT INTO appointment (date, time, appointmentStatus, description, vehicleId, customerId) " +
                               "VALUES (@date, @time, @status, @description, @vehicleId, @customerId); " +
                               "SELECT LAST_INSERT_ID();";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@date", date);
                com.Parameters.AddWithValue("@time", time);
                com.Parameters.AddWithValue("@status", status);
                com.Parameters.AddWithValue("@description", description);
                com.Parameters.AddWithValue("@vehicleId", vehicleId);
                com.Parameters.AddWithValue("@customerId", customerId);
                com.ExecuteNonQuery();

                int appointmentId = Convert.ToInt32(com.ExecuteScalar());
                con.closeConnection();
                return appointmentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }



    }
}
