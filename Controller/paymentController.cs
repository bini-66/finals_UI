using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class paymentController
    {
        public int retrieveInvoiceId(string invoiceNo)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            //retrieving cutomerId frm the plate number
            string query = "SELECT customerInvoiceId FROM customer_invoice WHERE invoiceNo=@invoiceNo";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@invoiceNo", invoiceNo);


            object result = com.ExecuteScalar();

            // Check if no result was found
            //if (result == null)
            //{
            //    MessageBox.Show("No such invoiceNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;

            //}

            int invoiceId = Convert.ToInt32(result);

            return invoiceId;
        }
        public DataSet retrieveCustomerInfo(string invoiceNo)
        {
            //verfying invoice no 

            //connection class
            dbConnection con = new dbConnection();

            string query = "SELECT CONCAT(customer.firstName, ' ', customer.lastName) AS fullname,vehicle.plateNumber,customer_invoice.invoiceTotal FROM customer_invoice INNER JOIN vehicle ON vehicle.vehicleId=customer_invoice.vehicleId INNER JOIN customer ON customer.customerId=customer_invoice.customerId WHERE invoiceNo=@invoiceNo";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@invoiceNo", invoiceNo);

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }

        //retrieving receptionisy
        
        public void savePaymentDetails(payment payment,receipt receipt)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            //insertng into receipt table

            string query1 = "INSERT INTO receipt (receptionistId) VALUES (@receptionistId); SELECT LAST_INSERT_ID();"; ;
            MySqlCommand com=new MySqlCommand(query1,con.getConnection());
            com.Parameters.AddWithValue("@receptionistId", receipt.receptionistId);
 
            int receiptId = Convert.ToInt32(com.ExecuteScalar());
            receipt.receiptId = receiptId;

            //insertgn into payment table

            string query2 = "INSERT INTO payment(paymentAmount,paidAmount,paymentMethod,vehicleId,customerInvoiceId,receiptId) VALUES (@paymentAmount,@paidAmount,@paymentMethod,@vehicleId,@customerInvoiceId,@receiptId)";
            MySqlCommand com2=new MySqlCommand(query2 ,con.getConnection());
            com2.Parameters.AddWithValue("@paymentAmount", payment.invoiceTotal);
            com2.Parameters.AddWithValue("@paidAmount", payment.paidAmount);
            com2.Parameters.AddWithValue("@paymentMethod", payment.paymentMethod);
            com2.Parameters.AddWithValue("@vehicleId", payment.vehicleId);
            com2.Parameters.AddWithValue("@customerInvoiceId", payment.customerInvoiceId);
            com2.Parameters.AddWithValue("@receiptId", receipt.receiptId);

            com2.ExecuteNonQuery();






        }
        public int retrieveVehicleId(string plateNumber)

        {
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = "SELECT vehicleId FROM vehicle WHERE plateNumber=@plateNumber";
            MySqlCommand com=new MySqlCommand( query,con.getConnection());

            com.Parameters.AddWithValue("@plateNumber",plateNumber);

            int vehicleId=Convert.ToInt32(com.ExecuteScalar());
            return vehicleId;


        }

        public int ckInvoiceDuplication(int invoiceId)
        {
            //connection cladd
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = "SELECT COUNT(*) FROM payment WHERE customerInvoiceId=@customerInvoiceId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);
            object result = com.ExecuteScalar();

            int count = (result != null) ? Convert.ToInt32(result) : 0;

            if (count > 0)
            {
              
                return -1;
            }
            return 0;
            // Close connection
            con.closeConnection();


        }

    }
}
