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
    internal class ownerController
    {

        public DataSet viewProfile()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT firstName,lastName,email,phoneNumber FROM owner WHERE email=@username";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@username", userSession.userName);
            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet DS = new DataSet();
            DAP.Fill(DS);

            return DS;
        }
        public void updateProfile(owner owner)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE owner SET firstname=@firstName,lastName=@lastName,phoneNumber=@phoneNumber WHERE email=@username";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@firstName", owner.firstName);
            com.Parameters.AddWithValue("@lastName", owner.lastName);
            com.Parameters.AddWithValue("@phoneNumber", owner.phoneNumber);
            com.Parameters.AddWithValue("@username", userSession.userName);
            com.ExecuteNonQuery();

            MessageBox.Show("Profile Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
