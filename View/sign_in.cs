using finals_UI.Controller;
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
    public partial class sign_in : Form
    {
        user user = new user();
        userController userController = new userController();

        public sign_in()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //validations
            if (this.txtemail.Text == "")
            {
                errorProvider1.SetError(this.txtemail, "Username cannot be empty");
                
            }
            else
            {
                errorProvider1.Clear(); 
            }
            if (this.txtpw.Text == "")
            {
                errorProvider2.SetError(this.txtpw, "Password field cannot be empty");
            }
            else
            {
                errorProvider2.Clear();

            }
            user.username=this.txtemail.Text;
            user.password=this.txtpw.Text;

            //CALLING LOGIN FUNCTION
            bool loginResult=userController.userLogin(user);
            if (loginResult == true)//if credentials are valid
            {
                if (user.role == "Receptionist")
                {
                    view_appointment view_Appointment = new view_appointment();
                    view_Appointment.Show();
                    this.Hide(); 
                }
                else if (user.role == "Owner")
                {
                    view_reports viewReports = new view_reports();
                    viewReports.Show();
                    this.Hide();
                }
                else if (user.role == "Operational Manager")
                {
                    maintenance_transaction maintenance_Transaction = new maintenance_transaction();
                    maintenance_Transaction.Show();
                    this.Hide();
                }
                else if (user.role == "Service Manager")
                {   
                    employee_attendance employee_Attendance = new employee_attendance();
                    employee_Attendance.Show();
                    this.Hide();
                }
                else if (user.role == "Inventory Manager")
                {
                   view_stock view_Stock = new view_stock();
                    view_Stock.Show();
                    this.Hide();
                }
                if(user.role =="Super User")
                {
                     manage_employee manage_Employee = new manage_employee();
                    manage_Employee.Show();
                    this.Hide();
                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            //txtpw.PasswordChar = checkBox1.Checked ? '\0' : '*';
            if (checkBox1.Checked == false)
            {
                txtpw.UseSystemPasswordChar = true;

            }
            else
            {
                txtpw.UseSystemPasswordChar = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            sendCode sc = new sendCode();
            this.Hide();
            sc.Show();
        }
    }
}
