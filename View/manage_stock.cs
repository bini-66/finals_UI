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

namespace finals_UI
{
    public partial class manage_stock : Form
    {
        stockController stockController=new stockController();
        stock stock=new stock();
        public manage_stock()
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
            DataSet ds = stockController.loadItemName();
            CBitmName.DataSource=ds.Tables[0];
            CBitmName.DisplayMember = "itemName";
            CBitmName.ValueMember = "itemId";
            // Make the ComboBox display empty initially
            CBitmName.SelectedIndex = -1;

            //load data to data gridview

            DataSet ds2 = stockController.viewStock();
            dataGridView1.DataSource = ds2.Tables[0];
            //hiding stockId column
            dataGridView1.Columns["stockId"].Visible = false;

            //populating combo box with supplier comapny names aand their ids
            DataSet ds3 = stockController.loadSupplierDetails();
            CBsupDetails.DataSource = ds3.Tables[0];
            CBsupDetails.DisplayMember = "supplierCompany";
            CBsupDetails.ValueMember = "supplierId";
            // Make the ComboBox display empty initially
            CBsupDetails.SelectedIndex = -1;

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DataSet ds = stockController.viewStock();
            dataGridView1.DataSource = ds.Tables[0];
            //hiding stockId column
            dataGridView1.Columns["stockId"].Visible = false;

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
            stock.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            stock.quantity = Convert.ToInt32(this.NUDqty.Value);
            stock.purchaseDate=Convert.ToDateTime(this.DTPpurDate.Value);
            stock.supplierId= Convert.ToInt32(CBsupDetails.SelectedValue);
            stock.inventoryManagerId = 1;
            
            stockController.addStock(stock);

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
                stock.stockId = int.Parse(this.dataGridView1.CurrentRow.Cells["stockId"].Value.ToString());
                this.CBsupDetails.Text= this.dataGridView1.CurrentRow.Cells["supplierCompany"].Value.ToString();



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
            stock.itemId = Convert.ToInt32(CBitmName.SelectedValue);
            stock.quantity = Convert.ToInt32(this.NUDqty.Value);
            stock.purchaseDate = Convert.ToDateTime(this.DTPpurDate.Value);
            stock.supplierId = Convert.ToInt32(CBsupDetails.SelectedValue);


            stockController.updateStock(stock);

            //refresh grid
            refreshGrid();
            
             //clear Fields
            clearFields();

        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            stockController.deleteStock(stock.stockId);
            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();


        }

        private void refreshGrid()
        {
            DataSet ds = stockController.viewStock();
            dataGridView1.DataSource = ds.Tables[0];
            //hiding stockId column
            dataGridView1.Columns["stockId"].Visible = false;
        }
        private void clearFields()
        {
            this.CBitmName.SelectedIndex = -1;
            this.DTPpurDate.Value = DateTime.Now;
            this.NUDqty.Value = 0;
            this.CBsupDetails.SelectedIndex = -1;


        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
