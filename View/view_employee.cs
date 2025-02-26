using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;

namespace finals_UI
{
    public partial class view_employee : Form
    {
        employee employee = new employee();
        employeeController employeeController = new employeeController();

        public view_employee()
        {
            InitializeComponent();
            //loading data grid
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
        }


        private void button12_Click(object sender, EventArgs e)
        {
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnIdSearch_Click(object sender, EventArgs e)
        {
            if (this.txtEmpId.Text == "")
            {
                this.errorProvider1.SetError(this.txtEmpId, "Employee id cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            employee.employeeId = Convert.ToInt32(this.txtEmpId.Text);

            loadEmployeeData(employee.employeeId);
        }
        private void loadEmployeeData(int employeeId)
        {
            DataSet ds = employeeController.searchId(employeeId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No employee found with this ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
        }

        private void btnNameSearch_Click(object sender, EventArgs e)
        {
            string inputName = txtName.Text.Trim();

            if (string.IsNullOrEmpty(inputName))
            {
                errorProvider1.SetError(txtName, "Employee name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }

            string[] nameParts = inputName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length == 1)
            {
                LoadEmployeeData(nameParts[0], null); // Search by single name
            }
            else if (nameParts.Length >= 2)
            {
                LoadEmployeeData(nameParts[0], nameParts[1]); // Search by full name
            }
        }
        private void LoadEmployeeData(string name1, string name2)
        {
            DataSet ds = employeeController.searchName(name1, name2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No employee found with this name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null; // Clear DataGridView if no match
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
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
            owner_profile owner_profile = new owner_profile();  
            owner_profile.Show();
            this.Hide();

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
