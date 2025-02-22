using finals_UI.Controller;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class resetPW : Form
    {
        userController userController=new userController();
        sendCode sendCode = new sendCode();
        string username;
        public resetPW(string username)
        {
            this.username=username;
            InitializeComponent();
        }

        //btn reset
        private void button1_Click(object sender, EventArgs e)
        {

            if (txtresetpw.Text == txtconresetpw.Text)
            {
                string newPW = this.txtconresetpw.Text;
                userController.resetPW(newPW,username);
            }
            else
            {
                MessageBox.Show("passwords do not match");
            }

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
       
        }

        private void label2_Click(object sender, EventArgs e)
        {
            sign_in sign_In = new sign_in();
            this.Hide();
            sign_In.Show();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                txtresetpw.UseSystemPasswordChar = true;

            }
            else
            {
                txtresetpw.UseSystemPasswordChar = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                txtconresetpw.UseSystemPasswordChar = true;

            }
            else
            {
                txtconresetpw.UseSystemPasswordChar = false;
            }
        }
    }
}
