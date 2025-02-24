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
    }
}
