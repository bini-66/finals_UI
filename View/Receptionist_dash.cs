using finals_UI.Model.classes;
using finals_UI.View;
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
    public partial class Receptionist_dash : Form
    {
        public Receptionist_dash()
        {
            InitializeComponent();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_customer view_Customer = new view_customer();
            view_Customer.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            this.Hide();
            new_appointments apt = new new_appointments();
            apt.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            manage_payment payment = new manage_payment(null);
            payment.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            receptionist_profile profile = new receptionist_profile();
            profile.Show();
            this.Hide();
        }

        //log out btn
        private void button6_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           Receptionist_dash receptionist_Dash = new Receptionist_dash();
            receptionist_Dash.Show();
            this.Hide();
        }

        private void sales_Click(object sender, EventArgs e)
        {
            manage_sales_invoice invoice= new manage_sales_invoice();   
            invoice.Show();
            this.Hide();
        }

        private void btnviewapt_Click(object sender, EventArgs e)
        {
            view_appointment view_Appointment = new view_appointment();
            view_Appointment.Show();
            this.Hide();
        }

        private void Receptionist_dash_Load(object sender, EventArgs e)
        {

        }
    }
}
