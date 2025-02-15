using finals_UI.Controller;
using finals_UI.Model.classes;
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

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
