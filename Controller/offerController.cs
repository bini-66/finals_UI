using finals_UI.Model.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Model.Database;
using System.Data;

namespace finals_UI.Controller
{
    internal class offerController
    {
        public void addOffer(offer offer)
        {

            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "INSERT INTO offer(offerType,offerDescription,discount,startDate,endDate) VALUES (@offerType,@offerDescription,@discount,@startDate,@endDate)";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@offerType", offer.offerType);
            com.Parameters.AddWithValue("@offerDescription", offer.offerDescription);
            com.Parameters.AddWithValue("@discount", offer.discount);
            com.Parameters.AddWithValue("@startDate", offer.startDate);
            com.Parameters.AddWithValue("@endDate", offer.endDate);

            int ret = com.ExecuteNonQuery();

            MessageBox.Show("Offer added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);



            con.closeConnection();
        }

        public DataSet viewOffer()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT *  FROM offer";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);
            con.closeConnection();

            //return dataset
            return ds;


        }
        public void updateOffer(offer offer)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE offer SET offerType=@offerType,offerDescription=@offerDescription,discount=@discount,startDate=@startDate,endDate=@endDate WHERE offerId=@offerId";
            MySqlCommand com = new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@offerType",offer.offerType);
            com.Parameters.AddWithValue("@offerDescription", offer.offerDescription);
            com.Parameters.AddWithValue("@discount",offer.discount);
            com.Parameters.AddWithValue("@startDate",offer.startDate);
            com.Parameters.AddWithValue("@endDate",offer.endDate);
            com.Parameters.AddWithValue("@offerId", offer.offerId);

            int ret = com.ExecuteNonQuery();
            if (ret != 0) {
                MessageBox.Show("offer updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            con.closeConnection();
            
        }
        public void deleteOffer(int offerId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM offer WHERE offerId=@offerId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());

                com.Parameters.AddWithValue("@offerId", offerId);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("Offer deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.closeConnection();
            }
        }
        public DataSet loadSearchResults(string offerType)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT * FROM offer WHERE offerType LIKE @offerType";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@offerType", "%" + offerType + "%");

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();

            DAP.Fill(ds);

            return ds;

        }

    }
}
