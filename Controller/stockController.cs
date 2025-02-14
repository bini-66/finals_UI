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
using Org.BouncyCastle.Bcpg.OpenPgp;


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
            string query = "INSERT INTO stock (itemId,quantity,purchaseDate,supplierId,inventoryManagerId) VALUES (@itemId,@quantity,@purchaseDate,@supplierId,@inventoryManagerId)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", stock.itemId);
            com.Parameters.AddWithValue("@quantity",stock.quantity);
            com.Parameters.AddWithValue("@purchaseDate",stock.purchaseDate);
            com.Parameters.AddWithValue("@inventoryManagerId", stock.inventoryManagerId);
            com.Parameters.AddWithValue("@supplierId", stock.supplierId);



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
            string query = "SELECT stockId,inventory.itemId,itemName,quantity,purchaseDate,supplierCompany,inventoryManagerID " +
                "FROM stock " +
                "INNER JOIN  inventory ON  inventory.itemId=stock.itemId" +
                " INNER JOIN supplier ON supplier.supplierId=stock.supplierId";
            MySqlCommand com=new MySqlCommand( query,con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet loadItemName()
        {
            //connection class
            dbConnection con= new dbConnection();   
            con.openConnection();

            //command class
            string query = "SELECT itemId,itemName FROM inventory";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());   

            //data adapter ckass
            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds=new DataSet();   
            DAP.Fill(ds);

            return ds;

        }
        public void updateStock(stock stock)
        {
            //connecyon class
            dbConnection con= new dbConnection();   
            con.openConnection();

            //command class
            string query = "UPDATE stock SET itemId=@itemId,quantity=@quantity,purchaseDate=@purchaseDate,supplierId=@supplierId WHERE stockId=@stockId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", stock.itemId);
            com.Parameters.AddWithValue("@itemName", stock.itemName);
            com.Parameters.AddWithValue("@quantity", stock.quantity);
            com.Parameters.AddWithValue("@purchaseDate",stock.purchaseDate);
            com.Parameters.AddWithValue("@stockId",stock.stockId);
            com.Parameters.AddWithValue("@supplierId",stock.supplierId);

            int ret = com.ExecuteNonQuery();
            if (ret != 0)
            {
                MessageBox.Show("stock updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.closeConnection();
        }

        public void deleteStock(int stockId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM stock WHERE stockId=@stockId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());

                com.Parameters.AddWithValue("stockId", stockId);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("item deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.closeConnection();

            }
        }
        public DataSet loadSupplierDetails()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command classs
            String query = "SELECT supplierId,supplierCompany FROM supplier";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

    }
}
