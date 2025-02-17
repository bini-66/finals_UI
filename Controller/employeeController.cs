using finals_UI.Model.classes;
using MySql.Data.MySqlClient;
using finals_UI.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;

namespace finals_UI.Controller
{
    internal class employeeController
    {
        public void addEmployee(employee employee)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string sql = "INSERT INTO employee(firstName,lastName,email,phoneNumber,employeeSalary) Values (@firstName,@lastName,@email,@phoneNumber,@employeeSalary)";
                MySqlCommand com = new MySqlCommand(sql, con.getConnection());

                com.Parameters.AddWithValue("@firstName", employee.firstName);
                com.Parameters.AddWithValue("@lastName", employee.lastName);
                com.Parameters.AddWithValue("@email", employee.email);
                com.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                com.Parameters.AddWithValue("@employeeSalary", employee.employeeSalary);

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
        public DataSet viewEmployee()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string sql = "SELECT * FROM employee";
            MySqlCommand com = new MySqlCommand(sql, con.getConnection());

            //data adapter class
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }
        public DataSet searchId(int employeeId)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string sql = "SELECT * FROM employee WHERE employeeId = @employeeId";
            MySqlCommand com = new MySqlCommand(sql, con.getConnection());

            com.Parameters.AddWithValue("@employeeId", employeeId);

            //data adapter class
            MySqlDataAdapter da = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

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
                sql = "SELECT * FROM employee WHERE firstName = @name OR lastName = @name";
                com = new MySqlCommand(sql, con.getConnection());
                com.Parameters.AddWithValue("@name", name1);
            }
            else
            {
                // If two names are entered, check firstName AND lastName together
                sql = "SELECT * FROM employee WHERE firstName = @name1 AND lastName = @name2";
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
        public void updateEmployee(employee employee)
        {
            try
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string sql = "UPDATE employee SET firstName=@firstName,lastName=@lastName,email=@email,phoneNumber=@phoneNumber,employeeSalary=@employeeSalary WHERE employeeId=@employeeId";
                MySqlCommand com = new MySqlCommand(sql, con.getConnection());

                com.Parameters.AddWithValue("@employeeId", employee.employeeId);
                com.Parameters.AddWithValue("@firstName", employee.firstName);
                com.Parameters.AddWithValue("@lastName", employee.lastName);
                com.Parameters.AddWithValue("@email", employee.email);
                com.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                com.Parameters.AddWithValue("@employeeSalary", employee.employeeSalary);

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
        public void deleteEmployee(int employeeId)
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
                    string sql = "DELETE FROM employee WHERE employeeId=@employeeId";
                    MySqlCommand com = new MySqlCommand(sql, con.getConnection());


                    com.Parameters.AddWithValue("@employeeId", employeeId);

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
