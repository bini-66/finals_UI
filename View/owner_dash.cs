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
    public partial class owner_dash : Form
    {
        public owner_dash()
        {
            InitializeComponent();
        }

        private void btnViewCustomers_Click(object sender, EventArgs e)
        {
            view_customer view_Customer = new view_customer();
            view_Customer.Show();
            this.Hide();
        }

        private void btnuserInfo_Click(object sender, EventArgs e)
        {
          view_employee view_Employee = new view_employee();
            view_Employee.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            owner_profile owner_profile = new owner_profile();
            owner_profile.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            owner_dash dash = new owner_dash();
            dash.Show();
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
