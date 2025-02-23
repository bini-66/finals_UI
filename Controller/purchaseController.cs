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
            string query = "INSERT INTO purchase (itemId,quantity,purchaseDate,comment,supplierId,supplierInvoiceNo,inventoryManagerId) VALUES (@itemId,@quantity,@purchaseDate,@comment,@supplierId,@supplierInvoiceNo,@inventoryManagerId)";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", purchase.itemId);
            com.Parameters.AddWithValue("@quantity",purchase.quantity);
            com.Parameters.AddWithValue("@purchaseDate",purchase.purchaseDate);
            com.Parameters.AddWithValue("@inventoryManagerId", purchase.inventoryManagerId);
            com.Parameters.AddWithValue("@supplierId", purchase.supplierId);
            com.Parameters.AddWithValue("@comment", purchase.comment);
            com.Parameters.AddWithValue("@supplierInvoiceNo", purchase.supplierInvoiceNo);

            int ret = com.ExecuteNonQuery();

            //check if the item exists in teh stock table 

            string query2 = "SELECT COUNT(*) FROM stock WHERE itemId=@itemId ";
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
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID " +
                "FROM purchase " +
                "INNER JOIN  item ON  item.itemId=purchase.itemId" +
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
            string query = "SELECT itemId,itemName FROM item  WHERE deleted_flag=FALSE";
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

            //get existing qty
            string query1 = "SELECT quantity FROM purchase WHERE purchaseId=@purchaseId";
            MySqlCommand com1=new MySqlCommand (query1,con.getConnection());    

            com1.Parameters.AddWithValue("@purchaseId",purchase.purchaseId);

            int oldQuantity = Convert.ToInt32(com1.ExecuteScalar());

            //update purchase record
            string query = "UPDATE purchase SET itemId=@itemId,quantity=@quantity,purchaseDate=@purchaseDate,supplierId=@supplierId,comment=@comment,supplierInvoiceNo=@supplierInvoiceNo WHERE purchaseId=@purchaseId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId", purchase.itemId);
            com.Parameters.AddWithValue("@itemName", purchase.itemName);
            com.Parameters.AddWithValue("@quantity", purchase.quantity);
            com.Parameters.AddWithValue("@purchaseDate",purchase.purchaseDate);
            com.Parameters.AddWithValue("@purchaseId",purchase.purchaseId);
            com.Parameters.AddWithValue("@supplierId",purchase.supplierId);
            com.Parameters.AddWithValue("@supplierInvoiceId", purchase.supplierInvoiceNo);
            com.Parameters.AddWithValue("@comment", purchase.comment);


            int ret = com.ExecuteNonQuery();

            //update stock qty
            int quantityDifference = purchase.quantity - oldQuantity;

            string query2 = "UPDATE stock SET quantity=quantity+@quantityDifference where itemId=@itemId";
            MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());

            com2.Parameters.AddWithValue("@itemId", purchase.itemId);
            com2.Parameters.AddWithValue("@quantityDifference", quantityDifference);

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
            String query = "SELECT supplierId,supplierCompany FROM supplier WHERE deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        public DataSet searchByItemId(int itemId)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID FROM purchase INNER JOIN  item ON  item.itemId=purchase.itemId INNER JOIN supplier ON supplier.supplierId=purchase.supplierId WHERE purchase.itemId=@itemId";
            MySqlCommand com = new MySqlCommand( query, con.getConnection());

            com.Parameters.AddWithValue("@itemId", itemId);

            //data adapter class
            MySqlDataAdapter DAP=new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet searchByItemName(String itemName)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID FROM purchase INNER JOIN  item ON  item.itemId=purchase.itemId INNER JOIN supplier ON supplier.supplierId=purchase.supplierId WHERE itemName LIKE @itemName";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@itemName", itemName+"%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet searchByPurchaseDate(DateTime date)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID FROM purchase INNER JOIN  item ON  item.itemId=purchase.itemId INNER JOIN supplier ON supplier.supplierId=purchase.supplierId WHERE purchaseDate=@purchaseDate";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@purchaseDate", date);

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet searchBySupplierCompany(string supplierCompany)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID FROM purchase INNER JOIN  item ON  item.itemId=purchase.itemId INNER JOIN supplier ON supplier.supplierId=purchase.supplierId WHERE supplierCompany LIKE @supplierCompany";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@supplierCompany", supplierCompany+"%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
        public DataSet searchByInvoiceNo(string invoiceNo)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT purchaseId,item.itemId,itemName,quantity,purchaseDate,comment,supplierCompany,supplierInvoiceNo,inventoryManagerID FROM purchase INNER JOIN  item ON  item.itemId=purchase.itemId INNER JOIN supplier ON supplier.supplierId=purchase.supplierId WHERE supplierInvoiceNo=@supplierInvoiceNo";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@supplierInvoiceNo", invoiceNo );

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }
    }
}
