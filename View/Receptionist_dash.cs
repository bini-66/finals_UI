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
            manage_customers customers = new manage_customers();
            customers.ShowDialog();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_appointment apt = new view_appointment();
            apt.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            payment payment = new payment();
            payment.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
