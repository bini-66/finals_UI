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

            string[] nameParts = inputName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 1)
            {
                LoadFeedbackData(nameParts[0], null); // Search by single name
            }
            else if (nameParts.Length >= 2)
            {
                LoadFeedbackData(nameParts[0], nameParts[1]); // Search by full name
            }
        }
        private void LoadFeedbackData(string name1, string name2)
        {
            DataSet ds = feedbackController.searchName(name1, name2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No feedback found from this customer.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Clear DataGridView if no match
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = feedbackController.viewFeedback();
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
