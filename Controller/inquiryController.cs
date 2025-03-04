using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Controller
{
    internal class inquiryController
    {
        public DataSet viewInquiries()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT firstName,lastName,message,email,phone FROM contact";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP= new MySqlDataAdapter(com);    
            DataSet ds=new DataSet();
            DAP.Fill(ds);
            return ds;

        }
        public DataSet loadSearchResults(string searchString)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT firstName,lastName,message,email,phone FROM contact WHERE firstName LIKE @searchString OR lastName LIKE @searchString OR email LIKE @searchString OR phone LIKE @searchString";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@searchString", searchString+"%");

            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);
            return ds;


        }
    }
}
