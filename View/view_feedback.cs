﻿using System;
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
    public partial class view_feedback : Form
    {
        feedback feedback = new feedback();
        feedbackController feedbackController = new feedbackController();

        public view_feedback()
        {
            InitializeComponent();
            //loading data grid
            DataSet ds = feedbackController.viewFeedback();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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

            DataSet ds = feedbackController.searchName(inputName);

            // Check if dataset is null or empty
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtName.Text = "";
                this.dataGridView1.DataSource = null; // Clears the grid without reloading all data
                return;
            }
            this.dataGridView1.DataSource = ds.Tables[0];
        }
        /*private void LoadFeedbackData(string name)
        {
            DataSet ds = feedbackController.searchName(name);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No feedback found from this customer.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Clear DataGridView if no match
            }
        }*/

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = feedbackController.viewFeedback();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            //serviceManager_dash serviceManager_Dash = new serviceManager_dash();
            //serviceManager_Dash.Show();
            //this.Hide();


        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            serviceManager_profile serviceManager_Profile = new serviceManager_profile();
            serviceManager_Profile.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
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

        private void txtacc_Click(object sender, EventArgs e)
        {
            serviceManager_profile profile = new serviceManager_profile();
            profile.Show();
            this.Hide();
        }
    }
}
