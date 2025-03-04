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
using finals_UI.View;

namespace finals_UI
{
    public partial class view_customer : Form
    {
        customer customer = new customer();
        customerController customerController = new customerController();

        public view_customer()
        {
            InitializeComponent();
            //load customer details on load
            LoadCustomerDetails();
        }

        //Other Methods
        private void LoadCustomerDetails()
        {
            DataSet ds = customerController.ViewCustomer();     
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];
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

        private void ClearSearchFields()
        {
            txtName.Clear();
            txtPlateNo.Clear();
            errorProvider1.Clear();
            errorProvider2.Clear();
        }

        //Event Handlers
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

            ClearSearchFields();
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
            ClearSearchFields();
        }

        private void btnViewAllCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomerDetails();
            ClearSearchFields();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) 
            {
                int customerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Customer ID"].Value);
                customerController.DeleteCustomer(customerId); // Call delete function

                //Refresh DataGridView
                LoadCustomerDetails();
                ClearSearchFields();
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            view_appointment view_Appointment = new view_appointment();
            view_Appointment.Show();
            this.Hide();
        }
        //btn payment
        private void btnacc_Click(object sender, EventArgs e)
        {
            manage_payment manage_Payment = new manage_payment(null);
            manage_Payment.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        //cust inq
        private void button3_Click(object sender, EventArgs e)
        {
           view_customer_inquiries view_Customer_Inquiries = new view_customer_inquiries();
            view_Customer_Inquiries.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        //btnsales

        private void button2_Click(object sender, EventArgs e)
        {
            manage_sales_invoice manage_sales_invoice = new manage_sales_invoice();
            manage_sales_invoice.Show();    
            this.Hide();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnacc2_Click(object sender, EventArgs e)
        {
            receptionist_profile receptionist_Profile = new receptionist_profile();
            receptionist_Profile.Show();
            this.Hide();
        }
    }
}
