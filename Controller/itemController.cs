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
    internal class itemController
    {
        public void addItem(item item)
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "INSERT INTO item(itemName,itemCategory,itemBrand,itemDescription,itemPrice) Values(@itemName,@itemCategory,@itemBrand,@itemDescription,@itemPrice)";
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
            string query = "SELECT * FROM item";
            MySqlCommand com = new MySqlCommand( query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP= new MySqlDataAdapter(com);   
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            //return data set
            return ds;

        }

        public void updateItem(item item)
        {
            //connection class
            dbConnection con= new dbConnection();
            con.openConnection();

            //command class
            String query = "UPDATE item SET itemName=@itemName,itemCategory=@itemCategory,itemBrand=@itemBrand,itemDescription=@itemDescription,itemPrice=@itemPrice WHERE itemId=@itemId";
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
                string query = "DELETE FROM item WHERE itemId=@itemId";
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
        public DataSet loadSearchResults(string itemInfo)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT * FROM item WHERE itemName LIKE @itemName OR itemId=@itemId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@itemName", "%" + itemInfo + "%");
            com.Parameters.AddWithValue("@itemId",itemInfo);

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();

            DAP.Fill(ds);

            return ds;

        }

    }
}
