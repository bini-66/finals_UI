using finals_UI;
using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class manage_sales_invoice : Form
    {
        saleController saleController=new saleController();
        sale sale=new sale();   
        customerInvoice customerInvoice=new customerInvoice();
        customerInvoiceController customerInvoiceController=new customerInvoiceController();

        string invoiceNo;

        public manage_sales_invoice()
        {
            InitializeComponent();
        }

        private void manage_sales_Load(object sender, EventArgs e)
        {
            
            //generate and insert invoiceNo
             invoiceNo=customerInvoiceController.generateInvoiceNo();
            this.txtInvoiceNo.Text = invoiceNo;

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ItemServiceId", "Item/service ID");
                dataGridView1.Columns.Add("ItemServiceName", "Item/service Name");
                dataGridView1.Columns.Add("type", "Type");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns["Quantity"].SortMode = DataGridViewColumnSortMode.NotSortable;

                dataGridView1.Columns.Add("unitPrice", "Unit Price");
                dataGridView1.Columns.Add("price", "Price");
                dataGridView1.Columns.Add("saleItemId", "saleItem Id");
                dataGridView1.Columns.Add("invitemservId", "invitem/service Id");



                //dataGridView1.Columns.Add("Update", "");
                //dataGridView1.Columns.Add("Delete", "");


                ////hiding saleIteM id column
                dataGridView1.Columns["saleItemId"].Visible = false;
                dataGridView1.Columns["invitemservId"].Visible = true;
                dataGridView1.Columns["type"].Visible = false;


               //disabling payment btn
               this.btnpaymentDetails.Enabled = false;
                //disabling print invoice btn
                this.btnprint.Enabled = false;
                //disablng save btn
                this.btnsave.Enabled = false;



            }
            //populating combo box with item names
            DataSet ds = saleController.loadItemName();
            CBitmName.DataSource = ds.Tables[0];
            CBitmName.DisplayMember = "itemName";
            CBitmName.ValueMember = "itemId";

            //populating combo box with services
            DataSet ds2 = saleController.loadServiceName();
            CBservice.DataSource = ds2.Tables[0];
            CBservice.DisplayMember = "serviceName";
            CBservice.ValueMember = "serviceId";
            // Make the ComboBox display empty initially
            CBservice.SelectedIndex = -1;
            CBitmName.SelectedIndex = -1;

            //load offers
            DataSet ds3 = saleController.retrieveOffers();
            CBoffer.DataSource = ds3.Tables[0];
            CBoffer.DisplayMember = "offerType";
            CBoffer.ValueMember = "offerId";
            // Make the ComboBox display empty initially
            CBoffer.SelectedIndex = -1;
        }

        //items  adding button 
        private void btnadd_Click(object sender, EventArgs e)
        {
            //enabling save btn
            this.btnsave.Enabled=true;
            //validations
            //item category
            if (this.CBitmName.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBitmName, "please select an item name");
                return;
            }

            else
            {
                errorProvider1.Clear();
            }
            //itm qty
            if (this.NUDqty.Value == 0)
            {
                this.errorProvider2.SetError(this.NUDqty, "please enter a valid qunatity");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            //customer invoice
            if (this.txtInvoiceNo.Text=="")
            {
                this.errorProvider3.SetError(this.txtInvoiceNo, "please enter an invoice no");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            //vehicle Number
            if (this.txtplateNo.Text == "")
            {
                this.errorProvider4.SetError(this.txtplateNo, "please enter a vehicle number");
                return;
            }

            else
            {
                errorProvider4.Clear();

            }
            sale.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            sale.quantity= Convert.ToInt32(this.NUDqty.Value);
            sale.plateNumber=this.txtplateNo.Text;
            sale.invoiceNo = this.txtInvoiceNo.Text;
            string type = "Item";
            sale.operationalManagerId = 3;

            //function to retrieve customer ID
           int customerId= saleController.retrieveCustomerId(sale.plateNumber);
            if (customerId == -1)
            {
                // Stop further processing if no customer was found
                return;  
            }

            //function to retrieve invoiceId
            int invoiceId=saleController.retrieveInvoiceId(sale.invoiceNo);

            //if (invoiceId == -1)
            //{
            //    // Stop further processing if no invoiceId was found
            //    return;
            //}


          

            bool stockAvailability = saleController.checkStockAvailability(sale.itemId, sale.quantity);
            if (stockAvailability == false)
            {
                MessageBox.Show("No enough stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }
            else
            {
                //function to insert sale details
                int saleItemId = saleController.addItem(sale);


                //insertng record to data grid view
                string itemName = this.CBitmName.Text;
                float itemPrice = saleController.retrieveItemPrice(sale.itemId);
                //calcuate total price 
                float totalPrice = sale.quantity * itemPrice;
                int invoiceitmid=saleController.retrieveinvitmId(sale.itemId,invoiceId);

                dataGridView1.Rows.Add(sale.itemId,itemName,type, sale.quantity,itemPrice,totalPrice,saleItemId,invoiceitmid);
                updateTotal();
                //// Create and add Update button
                //DataGridViewButtonCell updateButtonCell = new DataGridViewButtonCell();
                //updateButtonCell.Value = "Update";
                //dataGridView1.Rows[rowIndex].Cells["Update"] = updateButtonCell;

                //// Create and add Delete button
                //DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell();
                //deleteButtonCell.Value = "Delete";
                //dataGridView1.Rows[rowIndex].Cells["Delete"] = deleteButtonCell;
                //////hiding saleIteM id column
                dataGridView1.Columns["saleItemId"].Visible = false;
               // dataGridView1.Columns["invitemservId"].Visible = false;
                dataGridView1.Columns["Quantity"].Visible = true;
                dataGridView1.Columns["type"].Visible = false;
                dataGridView1.Columns["invitemservId"].Visible = false;




                //clear fields
                this.CBitmName.SelectedIndex = -1;
                this.NUDqty.Value = 0;


            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if CurrentRow is null or if there are no rows in the grid
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }

            var typeCell = dataGridView1.CurrentRow.Cells["type"].Value;
            string type = typeCell != null ? typeCell.ToString() : string.Empty;

            //  string type = this.dataGridView1.CurrentRow.Cells["type"].Value.ToString();

            if (type == "Item")
            {
                this.CBitmName.Text = this.dataGridView1.CurrentRow.Cells["ItemServiceName"].Value.ToString();
                this.CBservice.SelectedIndex = -1;

            }
            else
            {
                this.CBservice.Text = this.dataGridView1.CurrentRow.Cells["ItemServiceName"].Value.ToString();
                this.CBitmName.SelectedIndex = -1;

            }

            var qtyValue = dataGridView1.CurrentRow.Cells["Quantity"].Value;
            NUDqty.Value = int.TryParse(qtyValue?.ToString(), out int qty) ? qty : 0;

          
            var saleItemValue = dataGridView1.CurrentRow.Cells["saleItemId"].Value;
            sale.saleItemId = int.TryParse(saleItemValue?.ToString(), out int saleItemId) ? saleItemId : 0;

            //this.txtplateNo.Text=this.dataGridView1.CurrentRow.Cells["plateNumber"].Value.ToString();
            //this.txtInvoiceNo.Text = this.dataGridView1.CurrentRow.Cells["InvoiceNo"].Value.ToString();
            sale.invoiceItemServiceId= Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["invitemservId"].Value);



            // Make Invoice No field readonly
            txtInvoiceNo.ReadOnly = true;

            //disabling add buttons
            this.btnadditem.Enabled = false;
            this.btnaddservice.Enabled = false;

            
        }

        private void btnup_Click(object sender, EventArgs e)
        {

            //enabling add buttons
            this.btnadditem.Enabled = true;
            this.btnaddservice.Enabled = true;
            //validations
            //item category
            if (this.CBitmName.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBitmName, "please select an item name");
                return;
            }

            else
            {
                errorProvider1.Clear();
            }
            //itm qty
            if (this.NUDqty.Value == 0)
            {
                this.errorProvider2.SetError(this.NUDqty, "please enter a valid qunatity");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            //customer invoice
            if (this.txtInvoiceNo.Text == "")
            {
                this.errorProvider3.SetError(this.txtInvoiceNo, "please enter an invoice no");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            //vehicle Number
            if (this.txtplateNo.Text == "")
            {
                this.errorProvider4.SetError(this.txtplateNo, "please enter a vehicle number");
                return;
            }

            else
            {
                errorProvider4.Clear();

            }
            sale.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            sale.quantity = Convert.ToInt32(this.NUDqty.Value);
            sale.plateNumber = this.txtplateNo.Text;
            sale.invoiceNo = this.txtInvoiceNo.Text;
            sale.operationalManagerId = 2;
         


            //function to retrieve customer ID
            int customerId = saleController.retrieveCustomerId(sale.plateNumber);
            if (customerId == -1)
            {
                // Stop further processing if no customer was found
                return;
            }

            //function to retrieve invoiceId
            int invoiceId = saleController.retrieveInvoiceId(sale.invoiceNo);

            //if (invoiceId == -1)
            //{
            //    // Stop further processing if no invoiceId was found
            //    return;
            //}

            //function to insert sale details
           

            bool stockAvailability = saleController.checkStockAvailability(sale.itemId, sale.quantity);
            if (stockAvailability == false)
            {
                return;
            }
            else
            {
                //insertng record to data grid view
                saleController.updateitem(sale);

                float itemPrice = saleController.retrieveItemPrice(sale.itemId);
                //calcuate total price 
                float totalPrice = sale.quantity * itemPrice;
                

                // Update the selected row in the DataGridView 
                if (dataGridView1.CurrentRow != null)
                {
                    dataGridView1.CurrentRow.Cells["ItemServiceName"].Value = this.CBitmName.Text;
                    dataGridView1.CurrentRow.Cells["Quantity"].Value = sale.quantity;
                    dataGridView1.CurrentRow.Cells["Price"].Value = totalPrice;

                    updateTotal();


                    //dataGridView1.CurrentRow.Cells["InvoiceNo"].Value = sale.invoiceNo;
                    //dataGridView1.CurrentRow.Cells["plateNumber"].Value = sale.plateNumber;
                }
                else
                {
                    MessageBox.Show("Please select a row to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //clear fields
                this.CBitmName.SelectedIndex = -1;
                this.NUDqty.Value = 0;


            }

        }

        //search btn click 
        private void button5_Click(object sender, EventArgs e)
        {
            //clear existing columns
            dataGridView1.Columns.Clear();

            string searchInvoiceNo = this.txtInvoiceNo.Text;
         
            DataSet ds = saleController.searchsales(searchInvoiceNo);
            dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btndlt_Click(object sender, EventArgs e)
        {


            //enabling add buttons
            this.btnadditem.Enabled = true;
            this.btnaddservice.Enabled = true;

            sale.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            sale.invoiceNo = this.txtInvoiceNo.Text;

            //callng delete function 
            saleController.deleteitem(sale);
            // Remove the selected row from the DataGridView
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            updateTotal();

            //clear fields
            clearFields();

        }
        private void clearFields()
        {
            this.CBitmName.SelectedIndex= -1;
            this.NUDqty.Value=0;
            //this.txtInvoiceNo.Text = "";
            //this.txtplateNo.Text = "";
            //this.txtInvoiceNo.Text = "";

        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
            this.btnadditem.Enabled= true;
            this.btnaddservice.Enabled = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnaddservice_Click(object sender, EventArgs e)
        {
            //enabling btn save
            this.btnsave.Enabled= true;
            //validtng 
            if (this.CBservice.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBservice, "please select a service");
                return;
            }

            else
            {
                errorProvider1.Clear();
            }
            if (this.txtplateNo.Text == "")
            {
                this.errorProvider2.SetError(this.txtplateNo, "please enter plate number");
                return;
            }

            else
            {
                errorProvider2.Clear();
            }

            //checkg whther plate no is of a registered custimer
            sale.plateNumber = this.txtplateNo.Text;
            int customerId = saleController.retrieveCustomerId(sale.plateNumber);
            if (customerId == -1)
            {
                // Stop further processing if no customer was found
                return;
            }

            sale.invoiceNo = this.txtInvoiceNo.Text;
            string service =this.CBservice.Text;
            int serviceId = Convert.ToInt32(CBservice.SelectedValue);
            //function to retrieve invoiceId
            int invoiceId = saleController.retrieveInvoiceId(sale.invoiceNo);
            string type = "Service";

            //if (invoiceId == -1)
            //{
            //    // Stop further processing if no invoiceId was found
            //    return;
            //}
            //callig function to insert data
            saleController.addService(serviceId, invoiceId);



            //function to return servicePrice
            float servicePrice = saleController.retrieveServicePrice(serviceId);
            //funtion to return invserviceId
            int invserId=saleController.retrieveinvserId(serviceId,invoiceId);

            //loading data into data grid view 
           dataGridView1.Rows.Add(serviceId, service,type,"", servicePrice,servicePrice, "",invserId);
            updateTotal();

            //// Create and add Delete button
            //DataGridViewButtonCell deleteButtonCell = new DataGridViewButtonCell();
            //deleteButtonCell.Value = "Delete";
            //dataGridView1.Rows[rowIndex].Cells["Delete"] = deleteButtonCell;

            ////hiding saleIteM id column
            dataGridView1.Columns["saleItemId"].Visible = false;
            dataGridView1.Columns["invitemservId"].Visible = false;
           // dataGridView1.Columns["Quantity"].Visible = false;
            dataGridView1.Columns["type"].Visible = false;


            this.CBservice.SelectedIndex = -1;



        }

        private void btnserup_Click(object sender, EventArgs e)
        {

            //enabling add buttons
            this.btnadditem.Enabled = true;
            this.btnaddservice.Enabled = true;

            //function to retrieve customer ID
            int customerId = saleController.retrieveCustomerId(sale.plateNumber);
            if (customerId == -1)
            {
                // Stop further processing if no customer was found
                return;
            }


            //validtng 
            if (this.CBservice.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBservice, "please select a service");
                return;
            }

            else
            {
                errorProvider1.Clear();
            }
            int serviceId = Convert.ToInt32(CBservice.SelectedValue);
            float servicePrice = saleController.retrieveServicePrice(serviceId);


            //callng update function
            saleController.updateService(serviceId,sale.invoiceItemServiceId);

            //updating data grid view
            dataGridView1.CurrentRow.Cells["ItemServiceId"].Value = serviceId;
            dataGridView1.CurrentRow.Cells["ItemServiceName"].Value = this.CBservice.Text;
            dataGridView1.CurrentRow.Cells["Price"].Value = servicePrice;

            updateTotal();



            this.CBservice.SelectedIndex = -1;





        }

        private void btndltser_Click(object sender, EventArgs e)
        {

            //enabling add buttons
            this.btnadditem.Enabled = true;
            this.btnaddservice.Enabled = true;

            //callng delete function
            saleController.deleteService(sale.invoiceItemServiceId);
            // Remove the selected row from the DataGridView
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            updateTotal();

            this.CBservice.SelectedIndex = -1;
        }

        //Exit btn
        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnserclr_Click(object sender, EventArgs e)
        {
            this.CBservice.SelectedIndex=-1;
            this.btnaddservice.Enabled = true;
            this.btnadditem.Enabled = true;

        }

        private void updateTotal()
        {
            decimal total = 0;
            decimal discount= Convert.ToDecimal(this.txtdisc.Text);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["price"].Value != null)
                {
                    total =total+ Convert.ToDecimal(row.Cells["price"].Value);
                }
            }
            decimal finalTotal = total - discount; 
            txttot.Text = finalTotal.ToString("N2"); 

          
        }

        //save invoice btn click
        private void btnsave_Click(object sender, EventArgs e)
        {
           //validating plate numebr
            if (this.txtplateNo.Text=="")
            {
                this.errorProvider2.SetError(this.txtplateNo, "please enter a plate number");
                return;
            }

            else
            {
                errorProvider2.Clear();
            }

            //validating total field

            if (this.txttot.Text == "")
            {
                this.errorProvider6.SetError(this.txttot, "Total field cannoth be empty");
                return;
            }

            else
            {
                errorProvider6.Clear();
            }

            //enablin payment btn and print invoice bnt
            btnpaymentDetails.Enabled = true;
            btnprint.Enabled = true;

            customerInvoice.invoiceTotal = float.Parse(txttot.Text);
            customerInvoice.invoiceNo=this.txtInvoiceNo.Text;
            //customerInvoice.receptionistId = 1;
            customerInvoice.customerId = saleController.retrieveCustomerId(sale.plateNumber);
            customerInvoice.vehicleId = customerInvoiceController.retrieveVehicleId(sale.plateNumber);
            customerInvoice.offerId = Convert.ToInt32(CBoffer.SelectedValue);

            customerInvoiceController.saveInvoiceInfo(customerInvoice);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void CBoffer_SelectedIndexChanged(object sender, EventArgs e)
        {
            float discount = 0;
            if (CBoffer.SelectedValue != null && int.TryParse(CBoffer.SelectedValue.ToString(), out int offerId))
            {
               // decimal total = Convert.ToDecimal(this.txttot.Text);

                discount = saleController.retrieveDiscount(offerId);
                this.txtdisc.Text = discount.ToString();
                updateTotal();
                //total=total - Convert.ToDecimal(discount);
                //txttot.Text = total.ToString("N2");
            }
            txtdisc.Text = discount.ToString("N2");

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (this.txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Please enter an Invoice Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            customer_invoice report = new customer_invoice(txtInvoiceNo.Text);
            report.Show();
        }

        private void btnpaymentDetails_Click(object sender, EventArgs e)
        {
           manage_payment payment= new manage_payment(invoiceNo);    
            payment.Show();
            this.Hide();    
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            Receptionist_dash receptionist_Dash = new Receptionist_dash();
            receptionist_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            receptionist_profile profile = new receptionist_profile();
            profile.Show();
            this.Hide();

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();

        }

        private void btnapt_Click(object sender, EventArgs e)
        {

            view_appointment view_Appointment = new view_appointment();
            view_Appointment.Show();
            this.Hide();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            manage_sales_invoice invoice = new manage_sales_invoice();
            invoice.Show();
            this.Hide();
        }

        private void btnpayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            manage_payment payment = new manage_payment(null);
            payment.Show();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_customer view_Customer = new view_customer();
            view_Customer.Show();
        }

        private void btnacc_Click_1(object sender, EventArgs e)
        {
            view_customer_inquiries view_Customer_Inquiries = new view_customer_inquiries();
            view_Customer_Inquiries.Show();
            this.Hide();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            receptionist_profile profile = new receptionist_profile();
            profile.Show();
            this.Hide();
        }

        //public string returnInvoiceNo()
        //{ 
        //    this.txtInvoiceNo.Text = invoiceNo;
        //    return invoiceNo;
        //}
    }
}
