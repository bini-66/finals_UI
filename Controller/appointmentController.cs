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
    }
}
