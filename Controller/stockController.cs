using finals_UI.Model.classes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace finals_UI.Controller
{
    internal class stockController
    {
        
        public void addStock(stock stock)
        {
         //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "INSERT INTO stock (itemId,qunatity,purchaseDate,inventoryManagerId) VALUES (@itemId,@qunatity,@purchaseDate,@inventoryManagerId)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", stock.itemId);
            com.Parameters.AddWithValue("@quantity",stock.quantity);
            com.Parameters.AddWithValue("@purchaseDate",stock.purchaseDate);
            com.Parameters.AddWithValue("@inventoryManagerId", stock.inventoryManagerId);


            int ret = com.ExecuteNonQuery();

            MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            con.closeConnection();
        }
        public DataSet viewStock()
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT itemId,itemName,quantity,purchaseDate,inventoryManagerID FROM stock INNER JOIN ON inventory WHERE inventory.itemId=stock.itemId";
            MySqlCommand com=new MySqlCommand( query,con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            return ds;
        }
    }
}
