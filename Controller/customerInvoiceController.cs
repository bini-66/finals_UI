using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class customerInvoiceController
    {
      customerInvoice customerInvoice=new customerInvoice();

        public string generateInvoiceNo()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            string newInvoiceNo = "INV001";
            string query = "SELECT invoiceNo FROM customer_invoice ORDER BY customerInvoiceId DESC LIMIT 1";
            MySqlCommand com = new MySqlCommand(query,con.getConnection());
            object result = com.ExecuteScalar();

            if (result != null)
            {
                string lastInvoiceID = result.ToString();
                int number = int.Parse(lastInvoiceID.Substring(3));
                newInvoiceNo = "INV" + (number + 1).ToString("D3");
            }

            int receptionistId=retrieveReceptionistId();
            //insert into customer_invoice
            string query2 = "INSERT INTO customer_invoice(invoiceNo, invoiceTotal,customerId,receptionistId,vehicleId,offerId) VALUES (@invoiceNo, NULL,NULL,@receptionistId,NULL,NULL)";
            MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());
            com2.Parameters.AddWithValue("@invoiceNo", newInvoiceNo);
            com2.Parameters.AddWithValue("@receptionistId", receptionistId);

            com2.ExecuteNonQuery();



            return newInvoiceNo;
        }
        public int retrieveVehicleId(string plateNumber)
        {
            dbConnection con=new dbConnection();
            con.openConnection();

            string query = "SELECT vehicleId FROM vehicle WHERE plateNumber=@plateNumber";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());
            com.Parameters.AddWithValue("@plateNumber",plateNumber);



            object result = com.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }
        public void saveInvoiceInfo(customerInvoice invoice)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE customer_invoice SET invoiceTotal = @invoiceTotal, customerId = @customerId, vehicleId = @vehicleId, offerId=@offerId WHERE invoiceNo = @invoiceNo";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@invoiceNo",invoice.invoiceNo);
            com.Parameters.AddWithValue("@invoiceTotal",invoice.invoiceTotal);
           // com.Parameters.AddWithValue("@receptionistId",invoice.receptionistId);
            com.Parameters.AddWithValue("@customerId",invoice.customerId);
            com.Parameters.AddWithValue("@vehicleId",invoice.vehicleId);
            com.Parameters.AddWithValue("@offerId", invoice.offerId);



            com.ExecuteNonQuery();

            MessageBox.Show("Invoice saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.closeConnection();




        }
        public int retrieveReceptionistId()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT receptionistId FROM receptionist WHERE email=@email";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@email", userSession.userName);
            int receptionistId = Convert.ToInt32(com.ExecuteScalar());
            return receptionistId;
        }

    }
}
