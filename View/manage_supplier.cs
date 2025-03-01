using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace finals_UI
{
    public partial class manage_supplier : Form
    {
        supplier supplier=new supplier();
        supplierController supplierController = new supplierController();   

        public manage_supplier()
        {
            InitializeComponent();
      


            //loading data grid
            DataSet ds = supplierController.viewSuppliers();
            this.dataGridView1.DataSource = ds.Tables[0];
            this.btnup.Enabled = false;
            this.btndlt.Enabled = false;
        }



        private void btnadd_Click(object sender, EventArgs e)
        {
            //validations
            if (this.txtfname.Text == "")
            {
                this.errorProvider1.SetError(this.txtfname, "supplier first name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtlname.Text == "")
            {
                this.errorProvider2.SetError(this.txtlname, "supplier last name cannot be empty");
                return;

            }

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtphone.Text == "")
            {
                this.errorProvider3.SetError(this.txtphone, "phone number cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtphone.Text, @"^\d{10}$"))
            {
                this.errorProvider3.SetError(this.txtphone, "Please enter a valid 10-digit phone number");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtemail.Text == "")
            {
                this.errorProvider4.SetError(this.txtemail, "supplier email cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                this.errorProvider4.SetError(this.txtemail, "Please enter a valid email address");
                return; 
            }

            else
            {
                errorProvider4.Clear();
            }
            if (this.txtcompany.Text == "")
            {
                this.errorProvider5.SetError(this.txtcompany, "supplier company cannot be empty");
                return;

            }

            else
            {
                errorProvider5.Clear();
            }

            supplier.supplierfirstName=this.txtfname.Text;
            supplier.supplierlastName=this.txtlname.Text;
            supplier.email=this.txtemail.Text;
            supplier.phoneNumber=this.txtphone.Text;
            supplier.supplierCompany=this.txtcompany.Text;

            //calling add suppler function 
            supplierController.addSupplier(supplier);


            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();




        }

        private void btnup_Click(object sender, EventArgs e)
        {
            this.btnadd.Enabled = true;

            //validations
            if (this.txtfname.Text == "")
            {
                this.errorProvider1.SetError(this.txtfname, "supplier first name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtlname.Text == "")
            {
                this.errorProvider2.SetError(this.txtlname, "supplier last name cannot be empty");
                return;

            }

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtphone.Text == "")
            {
                this.errorProvider3.SetError(this.txtphone, "phone number cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtphone.Text, @"^\d{10}$"))
            {
                this.errorProvider3.SetError(this.txtphone, "Please enter a valid 10-digit phone number");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtemail.Text == "")
            {
                this.errorProvider4.SetError(this.txtemail, "supplier email cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                this.errorProvider4.SetError(this.txtemail, "Please enter a valid email address");
                return;
            }

            else
            {
                errorProvider4.Clear();
            }
            if (this.txtcompany.Text == "")
            {
                this.errorProvider5.SetError(this.txtcompany, "supplier company cannot be empty");
                return;

            }

            else
            {
                errorProvider5.Clear();
            }

            supplier.supplierfirstName = this.txtfname.Text;
            supplier.supplierlastName = this.txtlname.Text;
            supplier.email = this.txtemail.Text;
            supplier.phoneNumber = this.txtphone.Text;
            supplier.supplierCompany = this.txtcompany.Text;

            //calling update suppler function 
            supplierController.updateSupplier(supplier);

            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            //this.txtsearch.Text = "";
            DataSet ds = supplierController.viewSuppliers();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtlname.Text= this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtemail.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtphone.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.txtcompany.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            supplier.supplierId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
            this.btnadd.Enabled = false;
            this.btnup.Enabled = true;
            this.btndlt.Enabled = true;




        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            this.btnadd.Enabled = true;
            supplierController.deleteSupplier(supplier.supplierId);

            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();


        }
        public void refreshGrid()
        {
            DataSet ds = supplierController.viewSuppliers();
            this.dataGridView1.DataSource = ds.Tables[0];
        }
        public void clearFields()
        {
            this.txtfname.Text = "";
            this.txtlname.Text = "";
            this.txtemail.Text = "";
            this.txtphone.Text = "";
            this.txtcompany.Text = "";
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }


        private void txtsearch_Leave(object sender, EventArgs e)
        {
            //if (txtsearch.Text == "")
            //{
            //    txtsearch.Text = "Search by supplier name / company";
            //    txtsearch.ForeColor= Color.FromArgb(200, 200, 200); ;
            //}
        }

        //search button 
        private void button8_Click(object sender, EventArgs e)
        {
            string supInfo = this.txtsearch.Text;

            //load data in to data grid
            DataSet ds = supplierController.loadSearchResults(supInfo);

            // Check if dataset is empty
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No matching supplier found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtsearch.Text = "";
                return;

            }
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();

        }

        private void manage_supplier_Load(object sender, EventArgs e)
        {

        }

        private void btndash_Click(object sender, EventArgs e)
        {
            operationalManager_dash operationalManager_Dash = new operationalManager_dash();
            operationalManager_Dash.Show();
            this.Hide();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            operationalManager_profile profile = new operationalManager_profile();
            profile.Show();
            this.Hide();

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
