using finals_UI.Controller;
using finals_UI.Model.classes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class owner_profile : Form
    {
        ownerController ownerController=new ownerController();
        owner owner = new owner();

        public owner_profile()
        {
            InitializeComponent();
        }

        private void owner_profile_Load(object sender, EventArgs e)
        {
            DataSet DS = ownerController.viewProfile();
            if (DS.Tables[0].Rows.Count > 0)
            {
                // Extract data
                DataRow row = DS.Tables[0].Rows[0];
                this.txtfname.Text = row["firstName"].ToString();
                this.txtlname.Text = row["lastName"].ToString();
                this.txtphone.Text = row["phoneNumber"].ToString();
                this.txtemail.Text = row["email"].ToString();

                //displayng full name
                string firstName = row["firstName"].ToString();
                string lastName = row["lastName"].ToString();
                string fullName = firstName + " " + lastName;
                this.fullnamelbl.Text = fullName;
            }
            else
            {
                MessageBox.Show("No data found for this username.");
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            //validations
            if (this.txtfname.Text == "")
            {
                this.errorProvider1.SetError(this.txtfname, "first name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtlname.Text == "")
            {
                this.errorProvider2.SetError(this.txtlname, "last name cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
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

            owner.firstName = this.txtfname.Text;
            owner.lastName = this.txtlname.Text;
            owner.phoneNumber = this.txtphone.Text;

            //updatng full name label
            string fullName = owner.firstName + " " + owner.lastName;
            this.fullnamelbl.Text = fullName;
            ownerController.updateProfile(owner);

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();

        }

        private void btndash_Click(object sender, EventArgs e)
        {
            owner_dash owner_Dash = new owner_dash();
            owner_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            view_reports viewReports = new view_reports();
            viewReports.Show();
            this.Hide();
        }

        private void btncust_Click(object sender, EventArgs e)
        {

        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            view_employee view_Employee = new view_employee();
            view_Employee.Show();
            this.Hide();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }
    }
}
