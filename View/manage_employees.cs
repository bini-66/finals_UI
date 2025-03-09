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
using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;

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
            this.Close();
        }
        //dashboard
        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Receptionist_dash dash = new Receptionist_dash();
            //dash.Show();
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
          
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataSet ds = employeeController.viewEmployee();
            this.dataGridView1.DataSource = ds.Tables[0];
            this.txtEmpIdsrch.Text = "";
            this.txtNamesrch.Text = "";
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
            this.txtNamesrch.Text = "";
            if (this.txtEmpIdsrch.Text == "")
            {
                this.errorProvider1.SetError(this.txtEmpIdsrch, "Employee id cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            employee.employeeId = Convert.ToInt32(this.txtEmpIdsrch.Text);

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
            this.txtEmpIdsrch.Text = "";
            string inputName = txtNamesrch.Text.Trim();

            if (string.IsNullOrEmpty(inputName))
            {
                errorProvider1.SetError(txtNamesrch, "Employee name cannot be empty");
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

        private void btnadd_Click_1(object sender, EventArgs e)
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
            if (!Regex.IsMatch(this.txtPhone.Text, @"^\d{10}$"))
            {
                this.errorProvider3.SetError(this.txtPhone, "Please enter a valid 10-digit phone number");
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
            if (!Regex.IsMatch(this.txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                this.errorProvider4.SetError(this.txtEmail, "Please enter a valid email address");
                return;
            }

            else
            {
                errorProvider4.Clear();
            }
           
            employee.firstName = this.txtFName.Text;
            employee.lastName = this.txtLName.Text;
            employee.email = this.txtEmail.Text;
            employee.phoneNumber = this.txtPhone.Text;
            //employee.employeeSalary = Convert.ToSingle(this.txtSalary.Text);

            //calling update employee function 
            employeeController.addEmployee(employee);

            //refresh grid
            refreshGrid();
            //clear fields
            clearFields();
        }

        private void label10_Click(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            serviceManager_profile profile = new serviceManager_profile();
            profile.Show();
            this.Hide();
        }
    }
}
