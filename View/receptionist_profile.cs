using finals_UI.Controller;
using finals_UI.Model.classes;
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

namespace finals_UI.View
{
    public partial class receptionist_profile : Form
    {
        receptionistController receptionistController = new receptionistController();
        receptionist receptionist = new receptionist();
        public receptionist_profile()
        {
            InitializeComponent();
        }

        private void receptionist_profile_Load(object sender, EventArgs e)
        {
            DataSet DS = receptionistController.viewProfile();
            if (DS.Tables[0].Rows.Count > 0)
            {
                // Extract data
                DataRow row = DS.Tables[0].Rows[0];
                this.txtfname.Text = row["firstName"].ToString();
                this.txtlname.Text = row["lastName"].ToString();
                this.txtphone.Text = row["phoneNumber"].ToString();
                this.txtemail.Text = row["email"].ToString();

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

            receptionist.firstName = this.txtfname.Text;
            receptionist.lastName = this.txtlname.Text;
            receptionist.phoneNumber = this.txtphone.Text;

            //updatng full name label
            string fullName = receptionist.firstName + " " + receptionist.lastName;
            this.fullnamelbl.Text = fullName;
            receptionistController.updateProfile(receptionist);
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
            Receptionist_dash receptionist_Dash = new Receptionist_dash();
            receptionist_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
