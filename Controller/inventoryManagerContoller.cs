using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finals_UI.Model.classes;
using finals_UI.Model.Database;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class inventoryManagerContoller
    {

        public DataSet viewProfile()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT firstName,lastName,email,phoneNumber FROM inventory_manager WHERE email=@username";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@username", userSession.userName);
            //data adapyter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet DS = new DataSet();
            DAP.Fill(DS);

            return DS;
        }
        public void updateProfile(inventoryManager inventoryManager)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE inventory_manager SET firstname=@firstName,lastName=@lastName,phoneNumber=@phoneNumber WHERE email=@username";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@firstName", inventoryManager.firstName);
            com.Parameters.AddWithValue("@lastName", inventoryManager.lastName);
            com.Parameters.AddWithValue("@phoneNumber", inventoryManager.phoneNumber);
            com.Parameters.AddWithValue("@username", userSession.userName);
            com.ExecuteNonQuery();

            MessageBox.Show("Profile Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
