using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class feedbackController
    {
        public DataSet viewFeedback()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string sql = "SELECT feedbackId,feedbackDescription AS feedback,CONCAT(customer.firstName, ' ', customer.lastName) AS fullName,customer.email AS email FROM feedback INNER JOIN customer ON feedback.customerId=customer.customerId";
            MySqlCommand com = new MySqlCommand(sql, con.getConnection());

            //data adapter class
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public void addFeedback(feedback feedback)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string sql = "INSERT INTO feedback(feedbackDescription) VALUES (@feedbackDescription)";
                MySqlCommand com = new MySqlCommand(sql, con.getConnection());

                com.Parameters.AddWithValue("@feedbackDescription", feedback.feedbackDescription);
                //com.Parameters.AddWithValue("@rating", feedback.rating);

                int ret = com.ExecuteNonQuery();
                MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //close connection
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void updateFeedback(feedback feedback)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string sql = "UPDATE feedback SET feedbackDescription=@feedbackDescription,rating=@rating WHERE feedbackId=@feedbackId";
                MySqlCommand com = new MySqlCommand(sql, con.getConnection());

                com.Parameters.AddWithValue("@feedbackId", feedback.feedbackId);
                com.Parameters.AddWithValue("@feedbackDescription", feedback.feedbackDescription);
                com.Parameters.AddWithValue("@rating", feedback.rating);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("Record updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                //close connection
                con.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void deleteFeedback(int feedbackId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    //connection class
                    dbConnection con = new dbConnection();
                    con.openConnection();

                    //command class
                    string sql = "DELETE FROM feedback WHERE feedbackId=@feedbackId";
                    MySqlCommand com = new MySqlCommand(sql, con.getConnection());


                    com.Parameters.AddWithValue("@feedbackId", feedbackId);

                    int ret = com.ExecuteNonQuery();
                    if (ret != 0)
                    {
                        MessageBox.Show("Record deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //close connection
                    con.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public DataSet searchName(string name1, string name2 = null)
        {
            dbConnection con = new dbConnection();
            con.openConnection();

            string sql;
            MySqlCommand com;

            if (string.IsNullOrEmpty(name2))
            {
                // If only one name is entered, check both firstName and lastName
                sql = "SELECT f.* FROM feedback f JOIN customer c ON c.customerId = f.customerId WHERE firstName = @name OR lastName = @name";
                com = new MySqlCommand(sql, con.getConnection());
                com.Parameters.AddWithValue("@name", name1);
            }
            else
            {
                // If two names are entered, check firstName AND lastName together
                sql = "SELECT f.* FROM feedback f JOIN customer c ON c.customerId = f.customerId WHERE firstName = @name1 AND lastName = @name2";
                com = new MySqlCommand(sql, con.getConnection());
                com.Parameters.AddWithValue("@name1", name1);
                com.Parameters.AddWithValue("@name2", name2);
            }

            // Execute the query
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
    }
}
