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
    public partial class manage_employees : Form
    {
        employee employee = new employee();
        employeeController employeeController = new employeeController();

        public manage_employees()
        {
            InitializeComponent();
            //loading data grid
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist_dash dash = new Receptionist_dash();
            dash.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //validations
            if (this.txtFName.Text == "")
            {
                this.errorProvider1.SetError(this.txtFName, "Employee first name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtLName.Text == "")
            {
                this.errorProvider2.SetError(this.txtLName, "Employee last name cannot be empty");
                return;
            }
            else
            {
                errorProvider3.Clear();
            }
            if (this.txtPhone.Text == "")
            {
                this.errorProvider3.SetError(this.txtPhone, "Phone number cannot be empty");
                return;
            }
            else
            {
                errorProvider3.Clear();
            }
            if (this.txtEmail.Text == "")
            {
                this.errorProvider4.SetError(this.txtEmail, "Employee email cannot be empty");
                return;
            }
            else
            {
                errorProvider4.Clear();
            }
            if (this.txtSalary.Text == "")
            {
                this.errorProvider5.SetError(this.txtSalary, "Employee salary cannot be empty");
                return;
            }
            else
            {
                errorProvider5.Clear();
            }

            employee.firstName = this.txtFName.Text;
            employee.lastName = this.txtLName.Text;
            employee.email = this.txtEmail.Text;
            employee.phoneNumber = this.txtPhone.Text;
            //employee.employeeSalary = Convert.ToSingle(this.txtSalary.Text);

            //calling update employee function 
            employeeController.updateEmployee(employee);

            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //calling delete employee function 
            employeeController.deleteEmployee(employee.employeeId);

            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();
        }
        public void refreshGrid()
        {
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
        }
        public void clearFields()
        {
            this.txtFName.Text = "";
            this.txtLName.Text = "";
            this.txtEmail.Text = "";
            this.txtPhone.Text = "";
            this.txtSalary.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtFName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtLName.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtEmail.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtPhone.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //this.txtSalary.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

            employee.employeeId = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value);
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
    }
}
