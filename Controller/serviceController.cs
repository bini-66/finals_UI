using finals_UI.Model.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using finals_UI.Model;
using finals_UI.Model.classes;
using System.Data;

namespace finals_UI.Controller
{
    internal class serviceController
    {
       
        //add service
        public void addService(service service)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query="INSERT INTO service(serviceName,serviceDescription,servicePrice,serviceManagerId) VALUES (@serviceName,@serviceDescription,@servicePrice,@serviceManagerId)";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@serviceName",service.serviceName);
            com.Parameters.AddWithValue("@serviceDescription",service.serviceDescription);
            com.Parameters.AddWithValue("@servicePrice",service.servicePrice);
            com.Parameters.AddWithValue("@serviceManagerId",service.serviceManagerId);  

            int ret=com.ExecuteNonQuery();

            MessageBox.Show("no of records inserted:"+ret,"Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

   

            con.closeConnection();


        }

        public DataSet viewServices()
        {   
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT *  FROM service";
            MySqlCommand com = new MySqlCommand( query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);
            con.closeConnection();

            //return dataset
            return ds;

        }

        public void deleteService(int serviceId)

        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {

                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM service WHERE serviceId=@serviceId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());

                com.Parameters.AddWithValue("@serviceId", serviceId);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("service deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.closeConnection();
            }
        }

        public void updateService(service service)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE service SET serviceName=@serviceName,serviceDescription=@serviceDescription,servicePrice=@servicePrice WHERE serviceId=@serviceId";
            MySqlCommand com = new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@serviceId",service.serviceId);
            com.Parameters.AddWithValue("@serviceName", service.serviceName);
            com.Parameters.AddWithValue("@serviceDescription", service.serviceDescription);
            com.Parameters.AddWithValue("@servicePrice", service.servicePrice);


            int ret = com.ExecuteNonQuery();
            if (ret != 0)
            {
                MessageBox.Show("service updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
            con.closeConnection();
        }


    }
}
