using finals_UI.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Model;
using finals_UI.Model.classes;
using finals_UI.View;

namespace finals_UI
{
    public partial class manage_purchases : Form
    {
        purchaseController purchaseController=new purchaseController();
        purchase purchase=new purchase();
        public manage_purchases()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manage_stock_Load(object sender, EventArgs e)
        {
          

            //populating combo box with item names
            DataSet ds = purchaseController.loadItemName();
            CBitmName.DataSource=ds.Tables[0];
            CBitmName.DisplayMember = "itemName";
            CBitmName.ValueMember = "itemId";
            // Make the ComboBox display empty initially
            CBitmName.SelectedIndex = -1;

            //load data to data gridview

            DataSet ds2 = purchaseController.viewPurchaseDetails();
            dataGridView1.DataSource = ds2.Tables[0];
            ////hiding stockId column
            dataGridView1.Columns["purchaseId"].Visible = false;

            //populating combo box with supplier comapny names aand their ids
            DataSet ds3 = purchaseController.loadSupplierDetails();
            CBsupDetails.DataSource = ds3.Tables[0];
            CBsupDetails.DisplayMember = "supplierCompany";
            CBsupDetails.ValueMember = "supplierId";
            // Make the ComboBox display empty initially
            CBsupDetails.SelectedIndex = -1;

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.txtsearch.Text ="";
            this.CBcolumns.SelectedIndex = -1;
            DataSet ds = purchaseController.viewPurchaseDetails();
            dataGridView1.DataSource = ds.Tables[0];
            ////hiding stockId column
            dataGridView1.Columns["purchaseId"].Visible = false;

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
            if (this.NUDqty.Value ==0)
            {
                this.errorProvider2.SetError(this.NUDqty, "please enter a valid qunatity");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            //supplier company
            if (this.CBsupDetails.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBsupDetails, "please select a supplier company");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            //supplier invoice
            if (this.txtinvoice.Text == "")
            {
                this.errorProvider1.SetError(this.txtinvoice, "please enter an invoice number");
                return;
            }

            else
            {
                errorProvider4.Clear();

            }

            purchase.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            purchase.quantity = Convert.ToInt32(this.NUDqty.Value);
            purchase.purchaseDate=Convert.ToDateTime(this.DTPpurDate.Value);
            purchase.supplierId= Convert.ToInt32(CBsupDetails.SelectedValue);
            purchase.comment=this.txtcomment.Text;
            purchase.supplierInvoiceNo= this.txtinvoice.Text;
            //purchase.operationalManagerId = 2;

            purchaseController.addStock(purchase);

            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                this.CBitmName.SelectedValue = this.dataGridView1.CurrentRow.Cells["itemId"].Value.ToString();
                this.DTPpurDate.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["purchaseDate"].Value);
                this.NUDqty.Value = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells["quantity"].Value);
            purchase.purchaseId = int.Parse(this.dataGridView1.CurrentRow.Cells["purchaseId"].Value.ToString());
            this.CBsupDetails.Text= this.dataGridView1.CurrentRow.Cells["supplierCompany"].Value.ToString();
                this.txtinvoice.Text = this.dataGridView1.CurrentRow.Cells["supplierInvoiceNo"].Value.ToString();
                this.txtcomment.Text = this.dataGridView1.CurrentRow.Cells["comment"].Value.ToString();




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
            //supplier company
            if (this.CBsupDetails.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.CBsupDetails, "please select a supplier company");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            //supplier invoice
            if (this.txtinvoice.Text == "")
            {
                this.errorProvider1.SetError(this.txtinvoice, "please enter an invoice number");
                return;
            }

            else
            {
                errorProvider4.Clear();

            }
            purchase.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            purchase.quantity = Convert.ToInt32(this.NUDqty.Value);
            purchase.purchaseDate = Convert.ToDateTime(this.DTPpurDate.Value);
            purchase.supplierId = Convert.ToInt32(CBsupDetails.SelectedValue);
            purchase.comment = this.txtcomment.Text;
            purchase.supplierInvoiceNo = this.txtinvoice.Text;


            purchaseController.updateStock(purchase);

            //refresh grid
            refreshGrid();
            
             //clear Fields
            clearFields();

        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            purchaseController.deleteStock(purchase.purchaseId);
            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();


        }

        private void refreshGrid()
        {
            DataSet ds = purchaseController.viewPurchaseDetails();
            dataGridView1.DataSource = ds.Tables[0];
            ////hiding stockId column
            dataGridView1.Columns["purchaseId"].Visible = false;
        }
        private void clearFields()
        {
            this.CBitmName.SelectedIndex = -1;
            this.DTPpurDate.Value = DateTime.Now;
            this.NUDqty.Value = 0;
            this.CBsupDetails.SelectedIndex = -1;
            this.txtcomment.Text = "";
            this.txtinvoice.Text = "";
            this.CBcolumns.SelectedIndex = -1;
            this.txtsearch.Text = "";
            refreshGrid();

        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

     

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            if(this.CBcolumns.SelectedIndex == 0)
            {
                int itemId;
                if (int.TryParse(this.txtsearch.Text, out itemId))
                {
                    
                }
                else
                {
                    // Invalid integer input
                    MessageBox.Show("Please enter a valid item ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtsearch.Text = "";
                    return;
                }

                DataSet ds =purchaseController.searchByItemId(itemId);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    refreshGrid();
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
           else if (this.CBcolumns.SelectedIndex == 1)
            {
                String itemName = this.txtsearch.Text;
                DataSet ds = purchaseController.searchByItemName(itemName);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    refreshGrid();
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex ==2 )
            {
                DateTime date;
                if (DateTime.TryParse(this.txtsearch.Text, out date))
                {
               
                }
                else
                {
                    // Invalid date format
                    MessageBox.Show("Please enter a valid date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtsearch.Text = "";
                    return;
                }
                DataSet ds = purchaseController.searchByPurchaseDate(date);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    refreshGrid();
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex == 3)
            {
               string supplierCompany = this.txtsearch.Text;
                DataSet ds = purchaseController.searchBySupplierCompany(supplierCompany);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    refreshGrid();
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex == 4)
            {
                string supplierInvoiceNo = this.txtsearch.Text;
                DataSet ds = purchaseController.searchByInvoiceNo(supplierInvoiceNo);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    refreshGrid();
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void CBitmName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            //operationalManager_dash operationalManager_Dash = new operationalManager_dash();
            //operationalManager_Dash.Show();
            //this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            operationalManager_profile operationalManager_Profile = new operationalManager_profile();
            operationalManager_Profile.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnmaintenance_Click(object sender, EventArgs e)
        {

            maintenance_transaction transaction = new maintenance_transaction();
            transaction.Show();
            this.Hide();
        }

        private void btnsupp_Click(object sender, EventArgs e)
        {
            manage_supplier manage_Supplier = new manage_supplier();
            manage_Supplier.Show();
            this.Hide();
        }

        private void btnpur_Click(object sender, EventArgs e)
        {
            manage_purchases manage_Purchases = new manage_purchases();
            manage_Purchases.Show();
            this.Hide();
        }

        private void btnacc1_Click(object sender, EventArgs e)
        {
            operationalManager_profile operationalManager_Profile = new operationalManager_profile();
            operationalManager_Profile.Show();
            this.Hide();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }
    }
}
