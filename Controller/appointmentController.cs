using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using finals_UI.Model.classes;
using finals_UI.Model.Database;
using System.Drawing;
using System.Windows.Forms;
using finals_UI.View;

namespace finals_UI.Controller
{
    internal class appointmentController
    {
        //VIEW APPOINTMENTS

        public DataSet loadAppointments()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT a.appointmentId, v.plateNumber, COALESCE(a.date, '0001-01-01') as date, a.time, " +
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
            string query = "SELECT a.appointmentId, v.plateNumber, COALESCE(a.date, '0001-01-01') as date, a.time, " +
    "a.appointmentStatus, a.description, c.firstName, c.lastName, c.phone " +
    "FROM appointment a " +
    "INNER JOIN vehicle v ON a.vehicleId = v.vehicleId " +
    "INNER JOIN customer c ON a.customerId = c.customerId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@search", "%" + search + "%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        //NEW APPOINTMENT

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

            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "SELECT TIME_FORMAT(time, '%H:%i') AS time FROM appointment WHERE DATE(date) = @date";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));

                //data reader class
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string time = reader["time"].ToString();
                    unavailableSlots.Add(time);
                    Console.WriteLine("Unavailable Slot: " + time); //debug log
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getUnavailableSlots: " + ex.Message);
            }

            return unavailableSlots;
        }

        public List<KeyValuePair<int, string>> getServices()
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

                //data reader class
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

        public int reserveAppointment(string date, string time, string status, string description, int customerId, int vehicleId)
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

        //EDIT APPOINTMENT

        public appointment getAppointmentById(int appointmentId)
        {
            appointment appointment = null;
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();
                //command class
                string query = "SELECT a.appointmentId, a.date, a.time, a.appointmentStatus, a.description, " +
                   "a.customerId, a.vehicleId, c.firstName, c.lastName, c.phone, v.plateNumber " +
                    "FROM appointment a " +
                    "INNER JOIN customer c ON a.customerId = c.customerId " +
                    "INNER JOIN vehicle v ON a.vehicleId = v.vehicleId " +
                    "WHERE a.appointmentId = @appointmentId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@appointmentId", appointmentId);

                Console.WriteLine("Executing Query: " + query); // Debug message
                Console.WriteLine("With Parameters: appointmentId = " + appointmentId); // Debug message

                //data reader class
                MySqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    appointment = new appointment
                    {
                        appointmentId = reader.GetInt32("appointmentId"),
                        date = reader.GetDateTime("date"),
                        time = reader.GetTimeSpan("time").ToString(),
                        appointmentStatus = reader.GetString("appointmentStatus"),
                        description = reader.GetString("description"),
                        customerId = reader.GetInt32("customerId"),
                        vehicleId = reader.GetInt32("vehicleId"),
                        customerName = reader.GetString("firstName") + " " + reader.GetString("lastName"),
                        phoneNumber = reader.GetString("phone"),
                        plateNumber = reader.GetString("plateNumber")
                    };
                    Console.WriteLine("Appointment Data Loaded Successfully"); // Debug message
                }
                else
                {
                    Console.WriteLine("No Data Found for Appointment ID: " + appointmentId); // Debug msg
                }
                reader.Close();
                con.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return appointment;
        }

        public List<int> getSelectedServiceIds(int appointmentId)
        {
            List<int> selectedServiceIds = new List<int>();
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();
                //command class
                string query = "SELECT serviceId FROM appointment_service WHERE appointmentId = @appointmentId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@appointmentId", appointmentId);

                //data reader class
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    int serviceId = reader.GetInt32("serviceId");
                    selectedServiceIds.Add(serviceId);
                }
                reader.Close();
                con.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return selectedServiceIds;
        }

        public int updateAppointment(int appointmentId, string date, string time, string status, string description, int customerId, int vehicleId)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();
                //command class
                string query = "UPDATE appointment SET date = @date, time = @time, appointmentStatus = @status, " +
                               "description = @description, vehicleId = @vehicleId, customerId = @customerId " +
                               "WHERE appointmentId = @appointmentId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@date", date);
                com.Parameters.AddWithValue("@time", time);
                com.Parameters.AddWithValue("@status", status);
                com.Parameters.AddWithValue("@description", description);
                com.Parameters.AddWithValue("@vehicleId", vehicleId);
                com.Parameters.AddWithValue("@customerId", customerId);
                com.Parameters.AddWithValue("@appointmentId", appointmentId);
                int rowsAffected = com.ExecuteNonQuery();
                con.closeConnection();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;
            }
        }

        public void updateAppointmentServices(int appointmentId, List<int> selectedServiceIds)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                // Delete existing services for the appointment
                string deleteQuery = "DELETE FROM appointment_service WHERE appointmentId = @appointmentId";
                MySqlCommand deleteCom = new MySqlCommand(deleteQuery, con.getConnection());
                deleteCom.Parameters.AddWithValue("@appointmentId", appointmentId);
                deleteCom.ExecuteNonQuery();

                // Insert the newly selected services
                foreach (int serviceId in selectedServiceIds)
                {
                    string insertQuery = "INSERT INTO appointment_service (appointmentId, serviceId) VALUES (@appointmentId, @serviceId)";
                    MySqlCommand insertCom = new MySqlCommand(insertQuery, con.getConnection());
                    insertCom.Parameters.AddWithValue("@appointmentId", appointmentId);
                    insertCom.Parameters.AddWithValue("@serviceId", serviceId);
                    insertCom.ExecuteNonQuery();
                }
                con.closeConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
