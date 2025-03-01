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
    public partial class serviceManager_dash : Form
    {
        public serviceManager_dash()
        {
            InitializeComponent();
        }

     

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            manage_employees manage_Employees = new manage_employees();
            manage_Employees.Show();
            this.Hide();
        }

        private void brnservices_Click(object sender, EventArgs e)
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

        private void btnattendance_Click(object sender, EventArgs e)
        {
            employee_attendance employee_Attendance = new employee_attendance();    
            employee_Attendance.Show();
            this.Hide();
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            view_feedback view_Feedback = new view_feedback();  
            view_Feedback.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            serviceManager_profile profile = new serviceManager_profile();  
            profile.Show();
            this.Hide();
        }

        //btndashboard

        private void button1_Click(object sender, EventArgs e)
        {
            this.Show();

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
