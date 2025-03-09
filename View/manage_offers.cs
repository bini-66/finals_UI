using System;
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
    public partial class manage_offers : Form
    {
        offer offer =new offer();
        offerController offerController = new offerController();

        public manage_offers()
        {
            InitializeComponent();

            //load offers to datagridview
            DataSet ds = offerController.viewOffer();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

       
        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            //validations
            if (this.txtofferType.Text == "")
            {
                this.errorProvider1.SetError(this.txtofferType, "offer type cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtdisc.Text == "") { 
            
                this.errorProvider2.SetError(this.txtdisc, "discount value cannot be empty");
                return;

            }
            else
            {
                    errorProvider2.Clear();
            }

            //discount validation
            float discount;
            if (!float.TryParse(this.txtdisc.Text, out discount) || discount <= 0)
            {
                errorProvider3.SetError(this.txtdisc, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                offer.discount = discount;
                errorProvider2.Clear();
            }
            if (this.txtofferDes.Text == "")
            {
                this.errorProvider3.SetError(this.txtofferDes, "offer description cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }
            offer.offerType=this.txtofferType.Text;
            offer.offerDescription=this.txtofferDes.Text;
            offer.startDate=Convert.ToDateTime(this.DTPstart.Text);
            offer.endDate=Convert.ToDateTime(this.DTPend.Text);

            //calling addoffer function
            offerController.addOffer(offer);

            //update grid
            refreshGrid();

            //clear fields
            clearFields();


        }

        private void btnup_Click(object sender, EventArgs e)
        {
        


        }

        private void btnview_Click(object sender, EventArgs e)
        {
            this.txtsearch.Text = "";
            DataSet ds = offerController.viewOffer();
            this.dataGridView1.DataSource=ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtofferType.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtofferDes.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtdisc.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.DTPstart.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[4].Value);
            this.DTPend.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[5].Value);
            offer.offerId=Convert.ToInt32(this.dataGridView1.CurrentRow.Cells [0].Value);

        }
        public void refreshGrid()
        {
            this.dataGridView1.DataSource = offerController.viewOffer().Tables[0];
        }
        public void clearFields()
        {
            this.txtdisc.Text = "";
            this.txtofferType.Text = "";
            this.txtofferDes.Text = "";
            this.DTPstart.Value = DateTime.Today;
            this.DTPend.Value = DateTime.Today;

        }

        private void btnup_Click_1(object sender, EventArgs e)
        {
            //validations
            if (this.txtofferType.Text == "")
            {
                this.errorProvider1.SetError(this.txtofferType, "offer type cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtdisc.Text == "")
            {

                this.errorProvider2.SetError(this.txtdisc, "discount value cannot be empty");
                return;

            }
            else
            {
                errorProvider2.Clear();
            }

            //discount validation
            float discount;
            if (!float.TryParse(this.txtdisc.Text, out discount) || discount <= 0)
            {
                errorProvider3.SetError(this.txtdisc, "Please enter a valid price greater than 0.");
                return;
            }
            else
            {
                offer.discount = discount;
                errorProvider2.Clear();
            }
            if (this.txtofferDes.Text == "")
            {
                this.errorProvider3.SetError(this.txtofferDes, "offer description cannot be empty");
                return;


            }
            else
            {
                errorProvider3.Clear();
            }
            offer.offerType = this.txtofferType.Text;
            offer.offerDescription = this.txtofferDes.Text;
            offer.startDate = Convert.ToDateTime(this.DTPstart.Text);
            offer.endDate = Convert.ToDateTime(this.DTPend.Text);

            //calling updateOffer function
            offerController.updateOffer(offer);

            //update grid
            refreshGrid();

            //clear fields
            clearFields();
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            //calling delete offer function
            offerController.deleteOffer(offer.offerId);

            //refresh grid
            refreshGrid();

            //clear fields
            clearFields() ;
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
                string offerType = this.txtsearch.Text;

                //load data in to data grid
                DataSet ds = offerController.loadSearchResults(offerType);

                // Check if dataset is empty
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching offers found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    return;

                }
                this.dataGridView1.DataSource = ds.Tables[0];

            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
