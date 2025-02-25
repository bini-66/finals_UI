using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finals_UI.Model.Database;
using Microsoft.SqlServer.Server;
using MySqlX.XDevAPI.Common;
using finals_UI.Model.classes;
using Org.BouncyCastle.Ocsp;
using System.Windows.Forms;
using System.Transactions;
using System.Data.Common;
using Mysqlx.Crud;
using System.Reflection;
using System.Drawing;

namespace finals_UI.Controller
{
    internal class saleController
    {
      
        public DataSet loadItemName()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT itemId,itemName FROM item WHERE deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }

        public DataSet loadServiceName()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT serviceId,serviceName FROM service WHERE deleted_flag=FALSE";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //data adapter ckass
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }
        public void addService(int serviceId,int invoiceId)
        {
            //connection cass
            dbConnection con=new dbConnection();
            con.openConnection();

            //command clssd
            string query = "INSERT INTO customerinvoice_service(serviceId,customerInvoiceId) VALUES( @serviceId,@customerInvoiceId)";
            MySqlCommand com= new MySqlCommand(query,con.getConnection());
            com.Parameters.AddWithValue("@serviceId", serviceId);
            com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

            com.ExecuteNonQuery();

        }
        public float retrieveServicePrice(int serviceId)
        {  
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT servicePrice FROM service WHERE serviceId=@serviceId";
            MySqlCommand com = new MySqlCommand( query,con.getConnection());
            com.Parameters.AddWithValue("@serviceId", serviceId);

            object result = com.ExecuteScalar();
            float price = (result != null && result != DBNull.Value) ? Convert.ToSingle(result) : 0.0f;

            return price;

        }

        public int retrieveinvserId(int serviceId,int invoiceId)
        {
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT invoiceServiceId FROM customerinvoice_service WHERE serviceId=@serviceId AND customerInvoiceId=@customerInvoiceId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@serviceId", serviceId);
            com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);



            object result = com.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            



        }

        public int retrieveinvitmId(int itemId, int invoiceId)
        {
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT invoiceItemId FROM customerinvoice_item WHERE itemId=@itemId AND customerInvoiceId=@customerInvoiceId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@itemId", itemId);
            com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);



            object result = com.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;




        }
        public void updateService(int serviceId,int invoiceServiceId)
        {
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE customerinvoice_service SET serviceId=@serviceId WHERE invoiceServiceId=@invoiceServiceId";
            MySqlCommand com = new MySqlCommand(query,con.getConnection()); 

            com.Parameters.AddWithValue("@serviceId",serviceId);    
            com.Parameters.AddWithValue("@invoiceServiceId",invoiceServiceId);

            com.ExecuteNonQuery();
            MessageBox.Show("Service updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void deleteService(int invoiceServiceId)
        {
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "DELETE FROM customerinvoice_service WHERE invoiceServiceId=@invoiceServiceId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@invoiceServiceId", invoiceServiceId);

            com.ExecuteNonQuery();
            MessageBox.Show("Service deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public float retrieveItemPrice(int itemId)
        {
            //connection cass
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT itemPrice FROM item WHERE itemId=@itemId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            com.Parameters.AddWithValue("@itemId", itemId);

            object result = com.ExecuteScalar();
            float price = (result != null && result != DBNull.Value) ? Convert.ToSingle(result) : 0.0f;

            return price;

        }
        public int retrieveCustomerId(string plateNumber)
        {
            //connection class
            dbConnection con=new dbConnection();    
            con.openConnection();

            //command class
            //retievinf cutomerId frm the plate number
            string query = "SELECT vehicle.customerId FROM vehicle INNER JOIN customer ON customer.customerId=vehicle.customerId WHERE plateNumber=@plateNumber AND vehicle.deleted_flag=FALSE";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@plateNumber", plateNumber);


            object result = com.ExecuteScalar();

            // Check if no result was found
            if (result == null)
            {
                MessageBox.Show("No customer found for the given plate number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
               
            }
           
            int customerId = Convert.ToInt32(result);
            return customerId;
                

        }
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

            int invoiceId =  Convert.ToInt32(result) ;

            return invoiceId;
        }

        public bool checkStockAvailability(int itemId,int requestedQuantity)
        {

            dbConnection con = new dbConnection();
            con.openConnection();

            string query3 = "SELECT quantity FROM stock WHERE itemId=@itemId";
            MySqlCommand com3 = new MySqlCommand(query3, con.getConnection());

            com3.Parameters.AddWithValue("@itemId", itemId);
            int quantity = Convert.ToInt32(com3.ExecuteScalar());

            if (quantity < requestedQuantity)
            {
                return false;
            }
            return true;    

        }

        public int addItem(sale sale )
        {

            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();
            // Start a new transaction
            //MySqlTransaction transaction = con.getConnection().BeginTransaction();


            try
            {
                //insertng into stock table
                // Check stock availability
                //string query3 = "SELECT quantity FROM stock WHERE itemId=@itemId";
                //MySqlCommand com3 = new MySqlCommand(query3, con.getConnection(), transaction);

                //com3.Parameters.AddWithValue("@itemId", sale.itemId);
                //int quantity = Convert.ToInt32(com3.ExecuteScalar());

                //if (quantity < sale.quantity)
                //{
                //    MessageBox.Show("No enough stock,remainig stock:" + quantity, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    transaction.Rollback();
                //    return;

                // }
                bool stockAvailability = checkStockAvailability(sale.itemId, sale.quantity);
                if (stockAvailability == false)
                {
                    MessageBox.Show("No enough stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string query4 = "UPDATE stock SET quantity=quantity-@quantity WHERE itemId=@itemId";
                    MySqlCommand com4 = new MySqlCommand(query4, con.getConnection());

                    com4.Parameters.AddWithValue("@quantity", sale.quantity);
                    com4.Parameters.AddWithValue("@itemId", sale.itemId);

                    com4.ExecuteNonQuery();
                   

                }
                // insertng into sale table

                // Check if sale already exists

                string checkQuery = "SELECT COUNT(*) FROM sale WHERE customerInvoiceId = @customerInvoiceId";
                MySqlCommand checkCom = new MySqlCommand(checkQuery, con.getConnection());

                int customerId = retrieveCustomerId(sale.plateNumber);
                int invoiceId = retrieveInvoiceId(sale.invoiceNo);

                //checkCom.Parameters.AddWithValue("@customerId", customerId);
                checkCom.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

                int saleCount = Convert.ToInt32(checkCom.ExecuteScalar());

                // If the sale does not exist, insert it
                if (saleCount == 0)
                {
                    string query = "INSERT INTO sale(customerId,customerInvoiceId,operationalManagerId) VALUES(@customerId,@customerInvoiceId,@operationalManagerId)";
                    MySqlCommand com = new MySqlCommand(query, con.getConnection());


                    com.Parameters.AddWithValue("@customerId", customerId);
                    com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);
                    com.Parameters.AddWithValue("@operationalManagerId", sale.operationalManagerId);

                    com.ExecuteNonQuery();
                }
                
                //insertng into sale_item table
                //retrieving saleId

                // Retrieve the most recent saleId based on the inserted data 
                string query1 = "SELECT saleId FROM sale WHERE customerInvoiceId = @customerInvoiceId ORDER BY saleId DESC LIMIT 1";
                MySqlCommand com1 = new MySqlCommand(query1, con.getConnection());
                com1.Parameters.AddWithValue("@customerId", customerId);
                com1.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

                int saleId = Convert.ToInt32(com1.ExecuteScalar());
                //string query1= "SELECT LAST_INSERT_ID()";
                //MySqlCommand com1=new MySqlCommand(query1,con.getConnection());

                //int saleId=Convert.ToInt32(com1.ExecuteScalar());
               //MessageBox.Show("sale id"+saleId);

                string query2 = "INSERT INTO sale_item(saleId, itemId, quantity) VALUES(@saleId, @itemId, @quantity)";
                MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());


                com2.Parameters.AddWithValue("@saleId", saleId);
                com2.Parameters.AddWithValue("@itemId", sale.itemId);
                com2.Parameters.AddWithValue("@quantity", sale.quantity);

                int ret=com2.ExecuteNonQuery();
                // Retrieve the last inserted ID for sale_item
                string query3 = "SELECT LAST_INSERT_ID()";
                MySqlCommand com3 = new MySqlCommand(query3, con.getConnection());
                int saleItemId = Convert.ToInt32(com3.ExecuteScalar());

                //insertng intto customerinvoice_item table
                string query5 = "INSERT INTO customerinvoice_item(itemId,customerInvoiceId) VALUES( @itemId,@customerInvoiceId)";
                MySqlCommand com5 = new MySqlCommand(query5, con.getConnection());
                com5.Parameters.AddWithValue("@itemId", sale.itemId);
                com5.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

                com5.ExecuteNonQuery();


               // MessageBox.Show("Sale record added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

             

                // Commit transaction
                //transaction.Commit();
                return saleItemId;
            }
            //catch (Exception ex)
            //{
            //    // If any error occurs, rollback the transaction
            //    //transaction.Rollback();
            //    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}
            finally
            {
                con.closeConnection();
            }
            
        }

        public void retrieveSaleItemId()
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query= "SELECT saleItemId FROM sale_item WHERE saleId = @saleId AND itemId = @itemId ORDER BY saleItemId DESC LIMIT 1";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());


        }

        public void updateitem(sale sale)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class

            //updatng stock table
            bool stockAvailability = checkStockAvailability(sale.itemId, sale.quantity);
            if (stockAvailability == false)
            {
                MessageBox.Show("No enough stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query3 = "SELECT quantity FROM sale_item WHERE saleItemId=@saleItemId";
                MySqlCommand com3=new MySqlCommand(query3, con.getConnection());

                com3.Parameters.AddWithValue("@saleItemId",sale.saleItemId);

                int oldQuantity = Convert.ToInt32(com3.ExecuteScalar());
                int quantityDif=sale.quantity-oldQuantity;

                string query4 = "UPDATE stock SET quantity=quantity-@quantityDifference WHERE itemId=@itemId";
                MySqlCommand com4 = new MySqlCommand(query4, con.getConnection());

                com4.Parameters.AddWithValue("@quantityDifference", quantityDif);
                com4.Parameters.AddWithValue("@itemId", sale.itemId);

                com4.ExecuteNonQuery();
          

            }
            //updatng sale table
            string query1 = "UPDATE sale SET customerId=@customerId,operationalManagerId=@operationalManagerId WHERE customerInvoiceId=@customerInvoiceId";
            MySqlCommand com1=new MySqlCommand(query1,con.getConnection());
      

            int customerId = retrieveCustomerId(sale.plateNumber);
            int invoiceId = retrieveInvoiceId(sale.invoiceNo);
            com1.Parameters.AddWithValue("@customerId", customerId);
            com1.Parameters.AddWithValue("@customerInvoiceId",invoiceId);
            com1.Parameters.AddWithValue("@operationalManagerId", sale.operationalManagerId);

            com1.ExecuteNonQuery();

            //updatng saleItem Table
            string query2 = "UPDATE sale_item SET itemId=@itemId,quantity=@quantity WHERE saleItemId=@saleItemId";
            MySqlCommand com2=new MySqlCommand(query2,con.getConnection());

            com2.Parameters.AddWithValue("@itemId", sale.itemId);
            com2.Parameters.AddWithValue("@quantity", sale.quantity);
            com2.Parameters.AddWithValue("@saleItemId",sale.saleItemId);
            com2.ExecuteNonQuery();

            //updating customerinvouce_item tabel
            string query = "UPDATE customerinvoice_item SET itemId=@itemId WHERE invoiceItemId=@invoiceItemId";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            com.Parameters.AddWithValue("@itemId",sale.itemId);
            com.Parameters.AddWithValue("@invoiceItemId", sale.invoiceItemServiceId);
            com.ExecuteNonQuery();

            MessageBox.Show("Sale record updated successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        public DataSet searchsales(string invoiceNo)
        {
            //connectuon class
            dbConnection con = new dbConnection();
            con.openConnection();

            int invoiceId=retrieveInvoiceId(invoiceNo);
            string query = "SELECT item.itemName AS 'ItemName', sale_item.quantity AS 'Quantity',  customer_invoice.invoiceNo AS 'InvoiceNo',  vehicle.plateNumber AS 'plateNumber',  sale_item.saleItemId AS 'saleItemId' FROM sale INNER JOIN sale_item ON sale_item.saleId = sale.saleId INNER JOIN item ON sale_item.itemId = item.itemId INNER JOIN customer_invoice ON customer_invoice.customerInvoiceId = sale.customerInvoiceId INNER JOIN vehicle ON customer_invoice.vehicleId = vehicle.vehicleId WHERE sale.customerInvoiceId = @customerInvoiceId";



            MySqlCommand com =new MySqlCommand(query,con.getConnection());
            com.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

            //data adapetr class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds=new DataSet();
            DAP.Fill(ds);

            return ds;

        }
        public void deleteitem(sale sale)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "delte confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //connection class
                dbConnection con = new dbConnection();
                con.openConnection();


                //adjustng the stock level

                //retrieving the qty frm sale_item table
                string query3 = "SELECT quantity FROM sale_item WHERE saleItemId=@saleItemId";
                MySqlCommand com3 = new MySqlCommand(query3, con.getConnection());

                com3.Parameters.AddWithValue("@saleItemId", sale.saleItemId);

                int quantity = Convert.ToInt32(com3.ExecuteScalar());

                //adding tht qunatoty to stock table
                string query4 = "UPDATE stock SET quantity=quantity+@quantity WHERE itemId=@itemId";
                MySqlCommand com4 = new MySqlCommand(query4, con.getConnection());

                com4.Parameters.AddWithValue("@quantity", quantity);
                com4.Parameters.AddWithValue("@itemId", sale.itemId);

                com4.ExecuteNonQuery();

                //retriveng saleId of deletng transaction
                string query = "SELECT saleId FROM sale_item WHERE saleItemId=@saleItemId";
                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@saleItemId", sale.saleItemId);

                int saleId = Convert.ToInt32(com.ExecuteScalar());


                //deletng frm saleItem table
                string query1 = "DELETE FROM sale_item WHERE saleItemId=@saleItemId";
                MySqlCommand com1 = new MySqlCommand(query1, con.getConnection());

                com1.Parameters.AddWithValue("@saleItemId", sale.saleItemId);

                com1.ExecuteNonQuery();

                string checkQuery = "SELECT COUNT(*) FROM sale_item WHERE saleId=@saleId";
                MySqlCommand checkCom = new MySqlCommand(checkQuery, con.getConnection());

                checkCom.Parameters.AddWithValue("@saleId", saleId);
                int count = Convert.ToInt32(checkCom.ExecuteScalar());

                if (count == 0)
                {
                    //deletng frm sale table
                    string query2 = "DELETE FROM sale WHERE customerInvoiceId=@customerInvoiceId";
                    MySqlCommand com2 = new MySqlCommand(query2, con.getConnection());

                    int invoiceId = retrieveInvoiceId(sale.invoiceNo);

                    com2.Parameters.AddWithValue("@customerInvoiceId", invoiceId);

                    com2.ExecuteNonQuery();


                }

                //deleting from customerinvoice_item table
                //command class
                string query5 = "DELETE FROM customerinvoice_item WHERE invoiceItemId=@invoiceItemId";
                MySqlCommand com5 = new MySqlCommand(query, con.getConnection());

                com.Parameters.AddWithValue("@invoiceItemId", sale.invoiceItemServiceId);

                com.ExecuteNonQuery();

                //MessageBox.Show("Record deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                con.closeConnection();
            }
        }
        public DataSet retrieveOffers()
        {
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = "SELECT offerId,offerType FROM offer";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            //dsta adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;

        }

        public float retrieveDiscount(int offerId)
        {
            dbConnection con = new dbConnection();
            con.openConnection();

            string query = "SELECT discount FROM OFFER WHERE offerId=@offerId";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());

            com.Parameters.AddWithValue("@offerId", offerId);
            object result = com.ExecuteScalar();
            float discount = result != null ? Convert.ToSingle(result) : 0;

            return discount;
        }
    }
}