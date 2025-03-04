using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Controller
{
    internal class stockController
    {
        public DataSet loadStock()
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT stock.itemId,item.itemName,item.itemBrand AS Brand,stock.quantity AS 'Available quantity' FROM stock INNER JOIN item ON item.itemId=stock.itemId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());   

            MySqlDataAdapter DAP=new MySqlDataAdapter(com); 
            DataSet ds=new DataSet();   
            DAP.Fill(ds);

            return ds;
        }
        public DataSet serachResult(string searchText)
        {
            dbConnection con=new dbConnection();
            con.openConnection();

            string query = "SELECT stock.itemId,item.itemName,stock.quantity FROM stock INNER JOIN item ON item.itemId=stock.itemId " +
                "WHERE itemName LIKE @itemName OR stock.itemId=@itemId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", searchText);
            com.Parameters.AddWithValue("@itemName", searchText + "%");

            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);
       

        
            return ds;
        }
        public DataSet  restockItems()
        {
            dbConnection con=new dbConnection();
            con.openConnection();

            string query = "SELECT itemName,quantity FROM item INNER JOIN stock ON item.itemId=stock.itemId WHERE quantity < 5";
            MySqlCommand com=new MySqlCommand(query, con.getConnection());  

            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            return ds;
        }
    }
}
