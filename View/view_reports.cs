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
    public partial class view_reports : Form
    {
        public view_reports()
        {
            InitializeComponent();
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            view_reports viewReports = new view_reports();
            viewReports.Show();
            this.Hide();
        }

        private void btncust_Click(object sender, EventArgs e)
        {

            //view_customer view_Customer = new view_customer();
            //view_Customer.Show();
            //this.Hide();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            view_employee view_Employee = new view_employee();
            view_Employee.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            owner_profile profile = new owner_profile();
            profile.Show();
            this.Hide();
        }
    }
}
