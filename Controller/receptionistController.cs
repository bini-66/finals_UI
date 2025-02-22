using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    
    internal class receptionistController
    {
        public DataSet viewProfile()
        {
          
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT firstName,lastName,email,phoneNumber FROM receptionist WHERE email=@username";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@username", userSession.userName);
            //data adapyter class
            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet DS=new DataSet();
            DAP.Fill(DS);

            return DS;
        }
        public void updateProfile(receptionist receptionist)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE receptionist SET firstname=@firstName,lastName=@lastName,phoneNumber=@phoneNumber WHERE email=@username";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@firstName", receptionist.firstName);
            com.Parameters.AddWithValue("@lastName", receptionist.lastName);
            com.Parameters.AddWithValue("@phoneNumber", receptionist.phoneNumber);
            com.Parameters.AddWithValue("@username", userSession.userName);
            com.ExecuteNonQuery();

            MessageBox.Show("Profile Updated Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
