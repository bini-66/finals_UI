using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finals_UI.Model.Database;
using finals_UI.Model.classes;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace finals_UI.Controller
{
    internal class inventoryController
    {
        public void addItem(inventory item)
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "INSERT INTO inventory(itemName,itemCategory,itemBrand,itemDescription,itemPrice) Values(@itemName,@itemCategory,@itemBrand,@itemDescription,@itemPrice)";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@itemName", item.itemName);
            com.Parameters.AddWithValue("@itemCategory",item.itemCategory);
            com.Parameters.AddWithValue("@itemBrand",item.itemBrand);
            com.Parameters.AddWithValue("@itemDescription",item.itemDescription);
            com.Parameters.AddWithValue("@itemPrice",item.itemPrice);

            int ret=com.ExecuteNonQuery();
            MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            con.closeConnection();


        }

        public DataSet viewItem()
        {
            //connection class
            dbConnection con= new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT * FROM inventory";
            MySqlCommand com = new MySqlCommand( query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP= new MySqlDataAdapter(com);   
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            //return data set
            return ds;

        }

        public void updateItem(inventory item)
        {
            //connection class
            dbConnection con= new dbConnection();
            con.openConnection();

            //command class
            String query = "UPDATE inventory SET itemName=@itemName,itemCategory=@itemCategory,itemBrand=@itemBrand,itemDescription=@itemDescription,itemPrice=@itemPrice WHERE itemId=@itemId";
            MySqlCommand com = new MySqlCommand( query , con.getConnection());
            com.Parameters.AddWithValue("@itemName", item.itemName);
            com.Parameters.AddWithValue("@itemCategory", item.itemCategory);
            com.Parameters.AddWithValue("@itemBrand", item.itemBrand);
            com.Parameters.AddWithValue("@itemDescription", item.itemDescription);
            com.Parameters.AddWithValue("@itemPrice", item.itemPrice);
            com.Parameters.AddWithValue("@itemId",item.itemId);


            int ret = com.ExecuteNonQuery();
            if (ret != 0)
            {
                MessageBox.Show("item updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.closeConnection();


        }
        public void deleteItem(int itemId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM inventory WHERE itemId=@itemId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());


                com.Parameters.AddWithValue("@itemId", itemId);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("item deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.closeConnection();
            }
        }

    }
}
