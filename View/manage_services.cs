﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Model;
using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;

namespace finals_UI
{
    public partial class manage_services : Form
    {
        serviceController serviceController=new serviceController();
        service service = new service();

        public manage_services()
        {
            InitializeComponent();
            DataSet ds = serviceController.viewServices();
            this.dataGridView1.DataSource = ds.Tables[0];
            //hiding serviceManagerId column
           dataGridView1.Columns["serviceManagerId"].Visible = false;
        }

      

        private void btnadd_Click(object sender, EventArgs e)

        {
            //validations
            if(this.txtsername.Text=="")
            {
                this.errorProvider1.SetError(this.txtsername, "service name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtserprice.Text == "")
            {
                this.errorProvider2.SetError(this.txtserprice, "service price cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
            }
            //price validation
            float price;
            if (!float.TryParse(this.txtserprice.Text, out price) || price <= 0)
            {
                errorProvider3.SetError(this.txtserprice, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                service.servicePrice = price;
                errorProvider3.Clear();
            }
            if (this.txtserdes.Text == "")
            {
                this.errorProvider3.SetError(this.txtserdes, "service description cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }


            //set service details
            service.serviceName = this.txtsername.Text;
            service.serviceDescription = this.txtserdes.Text;
            service.serviceManagerId = 1;       //need to maintain a session fr this

            //calling function to add service
            serviceController.addService(service);

            //update datagridview
            RefreshGrid();
            clearFields();


        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.txtsearch.Text = "";
            DataSet ds= serviceController.viewServices();
            this.dataGridView1.DataSource = ds.Tables[0];
            //hiding serviceManagerId column
            dataGridView1.Columns["serviceManagerId"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtsername.Text=this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtserdes.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtserprice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            service.serviceId=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


        }

        private void btndlt_Click(object sender, EventArgs e)
        {

            //calling function to delete service
            serviceController.deleteService(service.serviceId);
            //update datagridview
            RefreshGrid();
            //clear text fields
            clearFields();

        }

        private void btnup_Click(object sender, EventArgs e)
        {
            //validations
            if (this.txtsername.Text == "")
            {
                this.errorProvider1.SetError(this.txtsername, "service name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtserprice.Text == "")
            {
                this.errorProvider2.SetError(this.txtserprice, "service price cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
            }
            //price validation
            float price;
            if (!float.TryParse(this.txtserprice.Text, out price) || price <= 0)
            {
                errorProvider3.SetError(this.txtserprice, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                service.servicePrice = price;
                errorProvider3.Clear();
            }
            if (this.txtserdes.Text == "")
            {
                this.errorProvider3.SetError(this.txtserdes, "service description cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }

            //set service details
            service.serviceName = this.txtsername.Text;
            service.serviceDescription = this.txtserdes.Text;


            //calling function to update service
            serviceController.updateService(service);

            //update datagridview
            RefreshGrid();

            //clear fields
            clearFields();


        }
        private void RefreshGrid()
        {
            this.dataGridView1.DataSource = serviceController.viewServices().Tables[0];
            //hiding serviceManagerId column
            dataGridView1.Columns["serviceManagerId"].Visible = false;
        }
        private void clearFields()
        {
            this.txtsername.Text = "";
            this.txtserdes.Text = "";
            this.txtserprice.Text = "";
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void txtsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsearchname_Click(object sender, EventArgs e)
        {
            string serviceName = this.txtsearch.Text;

            //load data in to data grid
            DataSet ds=serviceController.loadSearchResults(serviceName);

            // Check if dataset is empty
            if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No matching services found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtsearch.Text = "";
                return;

            }
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
            serviceManager_profile profile = new serviceManager_profile();
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            employee_attendance employee_Attendance = new employee_attendance();
            employee_Attendance.Show();
            this.Hide();
        }
        private void btnacc_1Click(object sender, EventArgs e)
        {
            manage_offers manage_Offers = new manage_offers();
            manage_Offers.Show();
            this.Hide();
        }

     


        private void btnservices_Click_1(object sender, EventArgs e)
        {
            manage_services manage_Services = new manage_services();
            manage_Services.Show();
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

        private void btnoffers_Click(object sender, EventArgs e)
        {
            manage_offers manage_Offers = new manage_offers();
            manage_Offers.Show();
            this.Hide();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //view_reports view_Reports = new view_reports();
            //view_Reports.MdiParent = this;
            //view_Reports.Show();
        }

        private void btnacc_Click_1(object sender, EventArgs e)
        {
            serviceManager_profile profile = new serviceManager_profile();
            profile.Show();
            this.Hide();
        }

        private void manage_services_Load(object sender, EventArgs e)
        {

        }
    }
}
