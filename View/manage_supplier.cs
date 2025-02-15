﻿using finals_UI.Controller;
using finals_UI.Model.classes;
using Org.BouncyCastle.Tls;
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
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

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

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtemail.Text == "")
            {
                this.errorProvider4.SetError(this.txtemail, "supplier email cannot be empty");
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

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtemail.Text == "")
            {
                this.errorProvider4.SetError(this.txtemail, "supplier email cannot be empty");
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
            DataSet ds = supplierController.viewSuppliers();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtfname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtlname.Text= this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtemail.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtphone.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtcompany.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

            supplier.supplierId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);


        }

        private void btndlt_Click(object sender, EventArgs e)
        {
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
    }
}
