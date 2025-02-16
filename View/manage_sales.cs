using finals_UI.Controller;
using finals_UI.Model.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class manage_sales : Form
    {
        saleController saleController=new saleController();
        sale sale=new sale();   

        public manage_sales()
        {
            InitializeComponent();
        }

        private void manage_sales_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("ItemName", "Item Name");
                dataGridView1.Columns.Add("Quantity", "Quantity");
                dataGridView1.Columns.Add("InvoiceNo", "Invoice Number");
                dataGridView1.Columns.Add("plateNumber", "Vehicle Number");
                dataGridView1.Columns.Add("saleItemId", "saleItem Id");

                ////hiding saleIteM id column
                //dataGridView1.Columns["saleItemId"].Visible = false;
            }
            //populating combo box with item names
            DataSet ds = saleController.loadItemName();
            CBitmName.DataSource = ds.Tables[0];
            CBitmName.DisplayMember = "itemName";
            CBitmName.ValueMember = "itemId";
            // Make the ComboBox display empty initially
            CBitmName.SelectedIndex = -1;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

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
            sale.comment=this.txtcomment.Text;
            sale.operationalManagerId = 2;

            //function to retrieve customer ID
           int customerId= saleController.retrieveCustomerId(sale.plateNumber);
            if (customerId == -1)
            {
                // Stop further processing if no customer was found
                return;  
            }

            //function to retrieve invoiceId
            int invoiceId=saleController.retrieveInvoiceId(sale.invoiceNo);

            if (invoiceId == -1)
            {
                // Stop further processing if no invoiceId was found
                return;
            }


            //function to insert sale details
            int saleItemId=saleController.addSale(sale);

            bool stockAvailability = saleController.checkStockAvailability(sale.itemId, sale.quantity);
            if (stockAvailability == false)
            {
                return ;
            }
            else
            {
                //insertng record to data grid view
                string itemName = this.CBitmName.Text;
                dataGridView1.Rows.Add(itemName, sale.quantity, sale.invoiceNo, sale.plateNumber,saleItemId);

                //clear fields
                this.CBitmName.SelectedIndex = -1;
                this.NUDqty.Value = 0;


            }



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CBitmName.Text = this.dataGridView1.CurrentRow.Cells["ItemName"].Value.ToString();
            this.NUDqty.Value = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["Quantity"].Value);
            sale.saleItemId=Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["saleItemId"].Value);
            //this.txtplateNo.Text=this.dataGridView1.CurrentRow.Cells["InvoiceNo"].ToString();
            //this.txtInvoiceNo.Text = this.dataGridView1.CurrentRow.Cells["plateNumber"].ToString();
            // Make Invoice No field readonly
            txtInvoiceNo.ReadOnly = true;
        }

        private void btnup_Click(object sender, EventArgs e)
        {
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

            if (invoiceId == -1)
            {
                // Stop further processing if no invoiceId was found
                return;
            }

            //function to insert sale details
           

            bool stockAvailability = saleController.checkStockAvailability(sale.itemId, sale.quantity);
            if (stockAvailability == false)
            {
                return;
            }
            else
            {
                //insertng record to data grid view
                saleController.updatesale(sale);
               
                // Update the selected row in the DataGridView 
                if (dataGridView1.CurrentRow != null)
                {
                    dataGridView1.CurrentRow.Cells["ItemName"].Value = this.CBitmName.Text;
                    dataGridView1.CurrentRow.Cells["Quantity"].Value = sale.quantity;
                    dataGridView1.CurrentRow.Cells["InvoiceNo"].Value = sale.invoiceNo;
                    dataGridView1.CurrentRow.Cells["plateNumber"].Value = sale.plateNumber;
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

        private void button5_Click(object sender, EventArgs e)
        {
            string searchInvoiceNo = this.txtsrchinv.Text;
            // Ensure only existing columns are used
            dataGridView1.AutoGenerateColumns = false;
            DataSet ds = saleController.searchsales(searchInvoiceNo);

            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
