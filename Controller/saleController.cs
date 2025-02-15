using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finals_UI.Model.Database;

namespace finals_UI.Controller
{
    internal class saleController
    {
        public DataSet loadItemName()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT itemId,itemName FROM item";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }
    }
}
