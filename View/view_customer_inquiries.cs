using finals_UI.Controller;
using finals_UI.Model.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class view_customer_inquiries : Form
    {
        inquiryController inquiryController=new inquiryController();
        public view_customer_inquiries()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void view_customer_inquiries_Load(object sender, EventArgs e)
        {
            DataSet ds=inquiryController.viewInquiries();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {

            DataSet ds = inquiryController.viewInquiries();
            this.dataGridView1.DataSource = ds.Tables[0];
            this.txtsearch.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString= this.txtsearch.Text;
            DataSet ds = inquiryController.loadSearchResults(searchString);
            this.dataGridView1 .DataSource = ds.Tables[0];
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            payment.ShowDialog();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            view_customer view_Customer = new view_customer();
            view_Customer.Show();
            this.Hide();
        }

        private void btninq_Click(object sender, EventArgs e)
        {
            view_customer_inquiries view_Customer_Inquiries = new view_customer_inquiries();
            view_Customer_Inquiries.Show();
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
    }
}
