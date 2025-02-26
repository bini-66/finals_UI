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
    internal class customerController
    {
        //public void addCustomer(customer customer)
        //{
        //    try
        //    {
        //        //connection class
        //        dbConnection con = new dbConnection();
        //        con.openConnection();

        //        //command class
        //        string sql = "INSERT INTO customer(firstName,lastName,email,phone) VALUES (@firstName,@lastName,@email,@phone)";
        //        MySqlCommand com = new MySqlCommand(sql, con.getConnection());

        //        com.Parameters.AddWithValue("@firstName", customer.firstName);
        //        com.Parameters.AddWithValue("@lastName", customer.lastName);
        //        com.Parameters.AddWithValue("@email", customer.email);
        //        com.Parameters.AddWithValue("@phoneNumber", customer.phone);

        //        int ret = com.ExecuteNonQuery();
        //        MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        //close connection
        //        con.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public DataSet ViewCustomer()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string sql = "SELECT customerId AS 'Customer ID', CONCAT(firstName, ' ',lastName) AS Name, email AS 'Email', " +
                    "phone AS 'Phone Number' " +
                    "FROM customer WHERE deleted_flag=false";
            MySqlCommand com = new MySqlCommand(sql, con.getConnection());

            //data adapter class
            MySqlDataAdapter dap = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            dap.Fill(ds);

            return ds;
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
                sql = "SELECT customerId AS 'Customer ID', CONCAT(firstName, ' ',lastName) AS Name, email AS 'Email', " +
                    "phone AS 'Phone Number' " +
                    "FROM customer WHERE (firstName = @name OR lastName = @name) AND deleted_flag=false";
                com = new MySqlCommand(sql, con.getConnection());
                com.Parameters.AddWithValue("@name", name1);
            }
            else
            {
                // If two names are entered, check firstName AND lastName together
                sql = "SELECT customerId AS 'Customer ID', CONCAT(firstName, ' ',lastName) AS Name, email AS 'Email', " +
                    "phone AS 'Phone Number' " +
                    "FROM customer WHERE (firstName = @name1 AND lastName = @name2) AND deleted_flag=false";
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
        public DataSet searchPlateNo(string plateNumber)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string sql = "SELECT c.customerId AS 'Customer ID', CONCAT(c.firstName, ' ',c.lastName) AS Name, c.email AS 'Email', c.phone AS 'Phone Number' " +
                "FROM customer c JOIN vehicle v ON c.customerId = v.customerId " +
                 "WHERE v.plateNumber = @plateNumber AND deleted_flag=false";
            MySqlCommand com = new MySqlCommand(sql, con.getConnection());

            com.Parameters.AddWithValue("@plateNumber", plateNumber);

            //data adapter class
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        //public void updateCustomer(customer customer)
        //{
        //    try
        //    {
        //        //connection class
        //        dbConnection con = new dbConnection();
        //        con.openConnection();

        //        //command class
        //        string sql = "UPDATE customer SET firstName=@firstName,lastName=@lastName,email=@email,phone=@phone WHERE customerId=@customerId";
        //        MySqlCommand com = new MySqlCommand(sql, con.getConnection());

        //        com.Parameters.AddWithValue("@customerId", customer.customerId);
        //        com.Parameters.AddWithValue("@firstName", customer.firstName);
        //        com.Parameters.AddWithValue("@lastName", customer.lastName);
        //        com.Parameters.AddWithValue("@email", customer.email);
        //        com.Parameters.AddWithValue("@phone", customer.phone);

        //        int ret = com.ExecuteNonQuery();
        //        if (ret != 0)
        //        {
        //            MessageBox.Show("Record updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        }

        //        //close connection
        //        con.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void DeleteCustomer(int customerId)
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
                    string sql = "UPDATE `customer` SET `deleted_flag`=true WHERE customerId=@customerId";
                    MySqlCommand com = new MySqlCommand(sql, con.getConnection());


                    com.Parameters.AddWithValue("@customerId", customerId);

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
    }
}
