using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class supplierController
    {
        public void addSupplier(supplier supplier)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            String query = "INSERT INTO supplier(supplierfirstName,supplierlastName,phoneNumber,email,supplierCompany) VALUES (@supplierfirstName,@supplierlastName,@phoneNumber,@email,@supplierCompany)";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@supplierfirstName", supplier.supplierfirstName);
            com.Parameters.AddWithValue("@supplierlastName", supplier.supplierlastName);
            com.Parameters.AddWithValue("@phoneNumber", supplier.phoneNumber);
            com.Parameters.AddWithValue("@email", supplier.email);
            com.Parameters.AddWithValue("@supplierCompany", supplier.supplierCompany);






            int ret = com.ExecuteNonQuery();

            MessageBox.Show("no of records inserted:" + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.closeConnection();

        }

        public DataSet viewSuppliers()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT * FROM supplier";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }

        public void updateSupplier(supplier supplier)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();


            //command class
            string query = "UPDATE supplier SET supplierfirstName=@supplierfirstName,supplierlastName=@supplierlastName,phoneNumber=@phoneNumber,email=@email,supplierCompany=@supplierCompany WHERE supplierId=@supplierId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@supplierfirstName", supplier.supplierfirstName);
            com.Parameters.AddWithValue("@supplierlastName", supplier.supplierlastName);
            com.Parameters.AddWithValue("@phoneNumber", supplier.phoneNumber);
            com.Parameters.AddWithValue("@email", supplier.email);
            com.Parameters.AddWithValue("@supplierCompany", supplier.supplierCompany);
            com.Parameters.AddWithValue("@supplierId",supplier.supplierId);

            int ret = com.ExecuteNonQuery();
            if (ret != 0)
            {
                MessageBox.Show("supplier updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            con.closeConnection();
        }

        public void deleteSupplier(int supplierId)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();

                //command class
                string query = "DELETE FROM supplier WHERE supplierId=@supplierId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());


                com.Parameters.AddWithValue("@supplierId", supplierId);

                int ret = com.ExecuteNonQuery();
                if (ret != 0)
                {
                    MessageBox.Show("supplier deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.closeConnection();
            }

        }
     
    }
}
