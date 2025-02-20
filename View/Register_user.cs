using finals_UI.Controller;
using finals_UI.Model.classes;
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

namespace finals_UI
{
    public partial class Register_user : Form
    {
        userController userController=new userController();
        user user=new user();

        public Register_user()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_user_Load(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (this.txtfname.Text == "")
            {
                this.errorProvider1.SetError(this.txtfname, "first name cannot be empty");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (this.txtlname.Text == "")
            {
                this.errorProvider2.SetError(this.txtlname, "last name cannot be empty");
                return;

            }

            else
            {
                errorProvider2.Clear();
            }
            if (this.txtphone.Text == "")
            {
                this.errorProvider3.SetError(this.txtphone, "phone number cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtphone.Text, @"^\d{10}$"))
            {
                this.errorProvider3.SetError(this.txtphone, "Please enter a valid 10-digit phone number");
                return;
            }

            else
            {
                errorProvider3.Clear();
            }
            if (this.txtemail.Text == "")
            {
                this.errorProvider4.SetError(this.txtemail, "email(username) cannot be empty");
                return;

            }
            if (!Regex.IsMatch(this.txtemail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                this.errorProvider4.SetError(this.txtemail, "Please enter a valid email address");
                return;
            }

            else
            {
                errorProvider4.Clear();
            }
            if (this.txtpw.Text == "")
            {
                this.errorProvider5.SetError(this.txtpw, "Please enter a password");
                return;

            }

            else
            {
                errorProvider5.Clear();
            }

            //chekcng user roles

            if (this.CBrole.Text== "Receptionist")
            {
                 user = new receptionist();
            }
            else if(this.CBrole.Text== "Operational Manager")
            {
                 user = new operationalManager();

            }
            else if (this.CBrole.Text == "Inventory Manager")
            {
                user = new inventoryManager();

            }
            else if (this.CBrole.Text == "Service Manager")
            {
                user = new serviceManager();

            }
            else if (this.CBrole.Text == "Owner")
            {
                user = new owner();

            }
            user.role = this.CBrole.Text;
            user.username = this.txtemail.Text;
            user.email = this.txtemail.Text;
            user.password = this.txtpw.Text;
            user.firstName = this.txtfname.Text;
            user.lastName = this.txtlname.Text;
            user.phoneNumber = this.txtphone.Text;

            //function to add into user table
            userController.addUser(user);  


            
        }
        public void clearFields()
        {
            this.CBrole.SelectedIndex = -1;
            this.txtfname.Text = "";
            this.txtlname.Text = "";
            this.txtphone.Text = "";
            this.txtpw.Text = "";
            this.txtemail.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtpw.UseSystemPasswordChar = true;

            }
            else
            {
                txtpw.UseSystemPasswordChar = false;
            }
        }
    }
}
