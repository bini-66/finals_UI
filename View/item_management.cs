using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI
{
    public partial class item_management : Form
    {
        item item=new item();
        itemController itemController=new itemController();

        public item_management()
        {
            InitializeComponent();
            DataSet ds = itemController.viewItem();
            this.dataGridView1.DataSource = ds.Tables[0];


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

     
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            //validations
                //item category
            if (this.CBcategory.SelectedIndex == -1)
            {
                this.errorProvider5.SetError(this.CBcategory, "please select an item category");
                return;
            }

            else
            {
                errorProvider5.Clear();
            }
                //item name
            if (this.txtitmName.Text == "")
            {
                this.errorProvider1.SetError(this.txtitmName, "item name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
                //item price
            if (this.txtitmPrice.Text == "")
            {
                this.errorProvider2.SetError(this.txtitmPrice, "item price cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
            }
            //price validation
            float price;
            if (!float.TryParse(this.txtitmPrice.Text, out price) || price <= 0)
            {
                errorProvider2.SetError(this.txtitmPrice, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                item.itemPrice = price;
                errorProvider2.Clear();
            }
                //item brand
            if (this.txtitmBrand.Text == "")
            {
                this.errorProvider3.SetError(this.txtitmBrand, "item brand cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }
                   //item description
            if (this.txtitmDes.Text == "")
            {
                this.errorProvider4.SetError(this.txtitmDes, "item description cannot be empty");
                return;


            }
            else
            {
                errorProvider4.Clear();
            }

            //set values
            item.itemName=this.txtitmName.Text;
            item.itemCategory = this.CBcategory.SelectedItem.ToString();
            item.itemBrand=this.txtitmBrand.Text;
            item.itemDescription=this.txtitmDes.Text;

            //calling functipn to add item
            itemController.addItem(item);

            //refresh grid
            RefreshGrid();

            //clear fields
            clearFields();


        }

        private void btnview_Click(object sender, EventArgs e)
        {
           DataSet ds=itemController.viewItem();
           this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtitmName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.CBcategory.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtitmBrand.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtitmDes.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtitmPrice.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            item.itemId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);

        }

        private void btnup_Click(object sender, EventArgs e)
        {
            //validations
                //item category
            if (this.CBcategory.SelectedIndex == -1)
            {
                this.errorProvider5.SetError(this.CBcategory, "please select an item category");
                return;
            }

            else
            {
                errorProvider5.Clear();
            }
                //item name
            if (this.txtitmName.Text == "")
            {
                this.errorProvider1.SetError(this.txtitmName, "item name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
                //item price

            if (this.txtitmPrice.Text == "")
            {
                this.errorProvider2.SetError(this.txtitmPrice, "item price cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
            }
            //price validation
            float price;
            if (!float.TryParse(this.txtitmPrice.Text, out price) || price <= 0)
            {
                errorProvider2.SetError(this.txtitmPrice, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                item.itemPrice = price;
                errorProvider2.Clear();
            }
                //item brand
            if (this.txtitmBrand.Text == "")
            {
                this.errorProvider3.SetError(this.txtitmBrand, "item brand cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }
                //item description
            if (this.txtitmDes.Text == "")
            {
                this.errorProvider4.SetError(this.txtitmDes, "item description cannot be empty");
                return;


            }
            else
            {
                errorProvider4.Clear();
            }
            //set values
            item.itemName = this.txtitmName.Text;
            item.itemCategory = this.CBcategory.SelectedItem.ToString();
            item.itemBrand = this.txtitmBrand.Text;
            item.itemDescription = this.txtitmDes.Text;
            
            //calling update item method
            itemController.updateItem(item);

            //refresh grid
            RefreshGrid();

            //clear fields
            clearFields();
        }

       
        private void btndlt_Click(object sender, EventArgs e)
        {
            //calling function to delete item
            itemController.deleteItem(item.itemId);

            //refresh grid
            RefreshGrid();

            //clear fields
            clearFields();
        }
        private void RefreshGrid()
        {
            this.dataGridView1.DataSource = itemController.viewItem().Tables[0];
        }

        private void clearFields()
        {
            this.txtitmBrand.Text = "";
            this.txtitmDes.Text = "";
            this.txtitmName.Text = "";
            this.txtitmPrice.Text = "";
            this.CBcategory.SelectedIndex = -1;
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string itemInfo = this.txtsearch.Text;

            //load data in to data grid
            DataSet ds = itemController.loadSearchResults(itemInfo);

            // Check if dataset is empty
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No matching offers found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtsearch.Text = "";
                return;

            }
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnview_Click_1(object sender, EventArgs e)
        {
            this.txtsearch.Text = "";
            DataSet ds = itemController.viewItem();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void CBcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void item_management_Load(object sender, EventArgs e)
        {

        }

        private void btndash_Click(object sender, EventArgs e)
        {
            inventoryManager_dash inventoryManager_Dash = new inventoryManager_dash();
            inventoryManager_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            inventoryManager_profile inventoryManager_Profile = new inventoryManager_profile();
            inventoryManager_Profile.Show();
            this.Hide();

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            view_stock view_Stock = new view_stock();
            view_Stock.Show();
            this.Hide();
        }

        private void btnitms_Click(object sender, EventArgs e)
        {
            item_management item_Management = new item_management();
            item_Management.Show();
            this.Hide();
        }

        private void btnacc_Click_1(object sender, EventArgs e)
        {
            inventoryManager_profile inventoryManager_Profile = new inventoryManager_profile();
            inventoryManager_Profile.Show();
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
