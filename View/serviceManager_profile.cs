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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finals_UI.View
{
    public partial class serviceManager_profile : Form
    {
        serviceManagerContoller serviceManagerContoller=new serviceManagerContoller();
        serviceManager serviceManager = new serviceManager();
        public serviceManager_profile()
        {
            InitializeComponent();
        }

        private void serviceManager_profile_Load(object sender, EventArgs e)
        {
            DataSet DS = serviceManagerContoller.viewProfile();
            if (DS.Tables[0].Rows.Count > 0)
            {
                // Extract data
                DataRow row = DS.Tables[0].Rows[0];
                this.txtfname.Text = row["firstName"].ToString();
                this.txtlname.Text = row["lastName"].ToString();
                this.txtphone.Text = row["phoneNumber"].ToString();
                this.txtemail.Text = row["email"].ToString();

                string firstName= row["firstName"].ToString();
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

            serviceManager.firstName=this.txtfname.Text;
            serviceManager.lastName=this.txtlname.Text;
            serviceManager.phoneNumber=this.txtphone.Text;

            //updatng full name label
            string fullName = serviceManager.firstName + " " + serviceManager.lastName;
            this.fullnamelbl.Text = fullName;
            serviceManagerContoller.updateProfile(serviceManager);
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
          serviceManager_dash serviceManager_Dash = new serviceManager_dash();
            serviceManager_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            employee_attendance employee_Attendance = new employee_attendance();
            employee_Attendance.Show();
            this.Hide();
        }

        private void btnservices_Click(object sender, EventArgs e)
        {
            manage_services manage_Services = new manage_services();
            manage_Services.Show();
            this.Hide();
        }

        private void btnoffers_Click(object sender, EventArgs e)
        {
            manage_offers manage_Offers = new manage_offers();
            manage_Offers.Show();
            this.Hide();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            manage_employees manage_Employees = new manage_employees();
            manage_Employees.Show();
            this.Hide();
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            view_feedback view_Feedback = new view_feedback();
            view_Feedback.Show();
            this.Hide();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnacc_Click_1(object sender, EventArgs e)
        {
            serviceManager_profile profile = new serviceManager_profile();
            profile.Show();
            this.Hide();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
