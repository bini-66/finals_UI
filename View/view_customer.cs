using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Controller;
using finals_UI.Model.classes;

namespace finals_UI
{
    public partial class view_customer : Form
    {
        customer customer = new customer();
        customerController customerController = new customerController();

        public view_customer()
        {
            InitializeComponent();
            //loading data grid
            DataSet ds = customerController.viewCustomer();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = customerController.viewCustomer();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnPlateNoSearch_Click(object sender, EventArgs e)
        {
            if (this.txtPlateNo.Text == "")
            {
                this.errorProvider2.SetError(this.txtPlateNo, "Vehicle plate number cannot be empty");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            string plateNumber = this.txtPlateNo.Text;

            loadCustomerData(plateNumber);
        }
        private void loadCustomerData(string plateNumber)
        {
            DataSet ds = customerController.searchPlateNo(plateNumber);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No customer found with this vehicle plate number.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
        }
        private void btnNameSearch_Click(object sender, EventArgs e)
        {
            string inputName = txtName.Text.Trim();

            if (string.IsNullOrEmpty(inputName))
            {
                errorProvider1.SetError(txtName, "Customer name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            string[] nameParts = inputName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 1)
            {
                LoadCustomerData(nameParts[0], null); // Search by single name
            }
            else if (nameParts.Length >= 2)
            {
                LoadCustomerData(nameParts[0], nameParts[1]); // Search by full name
            }
        }
        private void LoadCustomerData(string name1, string name2)
        {
            DataSet ds = customerController.searchName(name1, name2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No customer found with this name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Clear DataGridView if no match
            }
        }
    }
}
