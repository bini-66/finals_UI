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
    internal class purchaseController
    {
        
        public void addStock(purchase purchase)
        {
         //connection class

            //insertng record to purchase table
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "INSERT INTO purchase (itemId,quantity,purchaseDate,comment,supplierId,supplierInvoiceId,inventoryManagerId) VALUES (@itemId,@quantity,@purchaseDate,@comment,@supplierId,@supplierInvoiceId,@inventoryManagerId)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", purchase.itemId);
            com.Parameters.AddWithValue("@quantity",purchase.quantity);
            com.Parameters.AddWithValue("@purchaseDate",purchase.purchaseDate);
            com.Parameters.AddWithValue("@inventoryManagerId", purchase.inventoryManagerId);
            com.Parameters.AddWithValue("@supplierId", purchase.supplierId);
            com.Parameters.AddWithValue("@comment", purchase.comment);
            com.Parameters.AddWithValue("@supplierInvoiceId", purchase.supplierInvoiceId);

            int ret = com.ExecuteNonQuery();

            //check if the item exists in teh stock table 

            string query2 = "SELECT COUNT(*) FROM stock WHERE itemId=@itemId";
            MySqlCommand com2=new MySqlCommand(query2,con.getConnection());

            com2.Parameters.AddWithValue("@itemId",purchase.itemId);    

            int ret2 = Convert.ToInt32(com2.ExecuteScalar());

            if (ret2 > 0)
            {
                string query3 = "UPDATE stock SET quantity=quantity+@quantity where itemId=@itemId";
                MySqlCommand com3=new MySqlCommand( query3,con.getConnection());

                com3.Parameters.AddWithValue("@itemId", purchase.itemId);
                com3.Parameters.AddWithValue("@quantity", purchase.quantity);

               com3.ExecuteNonQuery();

            }
            else
            {
                string query4 = "INSERT INTO stock (itemId,quantity) VALUES (@itemId,@quantity)";
                MySqlCommand com4=new MySqlCommand(query4 ,con.getConnection());


                com4.Parameters.AddWithValue("@itemId", purchase.itemId);
                com4.Parameters.AddWithValue("@quantity", purchase.quantity);

                com4.ExecuteNonQuery();

            }


            MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            con.closeConnection();
        }
        public DataSet viewPurchaseDetails()
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,inventory.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceId,inventoryManagerID " +
                "FROM purchase " +
                "INNER JOIN  inventory ON  inventory.itemId=purchase.itemId" +
                " INNER JOIN supplier ON supplier.supplierId=purchase.supplierId";
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
        public void updateStock(purchase purchase)
        {
            //connecyon class
            dbConnection con= new dbConnection();   
            con.openConnection();

            //command class
            string query = "UPDATE purchase SET itemId=@itemId,quantity=@quantity,purchaseDate=@purchaseDate,supplierId=@supplierId,comment=@comment,supplierInvoiceId=@supplierInvoiceId WHERE purchaseId=@purchaseId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", purchase.itemId);
            com.Parameters.AddWithValue("@itemName", purchase.itemName);
            com.Parameters.AddWithValue("@quantity", purchase.quantity);
            com.Parameters.AddWithValue("@purchaseDate",purchase.purchaseDate);
            com.Parameters.AddWithValue("@purchaseId",purchase.purchaseId);
            com.Parameters.AddWithValue("@supplierId",purchase.supplierId);
            com.Parameters.AddWithValue("@supplierInvoiceId", purchase.supplierInvoiceId);
            com.Parameters.AddWithValue("@comment", purchase.comment);


            int ret = com.ExecuteNonQuery();


            string query2 = "UPDATE stock SET quantity=quantity+@quantity where itemId=@itemId";
            MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());

            com2.Parameters.AddWithValue("@itemId", purchase.itemId);
            com2.Parameters.AddWithValue("@quantity", purchase.quantity);

            com2.ExecuteNonQuery();
            if (ret != 0)
            {
                MessageBox.Show("stock updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.closeConnection();
        }

        public void deleteStock(int purchaseId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM purchase WHERE purchaseId=@purchaseId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());

                com.Parameters.AddWithValue("purchaseId", purchaseId);

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
