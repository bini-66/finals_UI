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

        string username = sendCode.to;
        public resetPW()
        {
            InitializeComponent();
        }

        //btn reset
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtresetpw.Text == txtconresetpw.Text)
            {
                //connection classs
               dbConnection con = new dbConnection();
               con.openConnection();
                //command class
                string query = "UPDATE user SET password=@password WHERE username=@username";
               MySqlCommand com = new MySqlCommand(query,con.getConnection());

                com.Parameters.AddWithValue("@password",this.txtconresetpw.Text);
                com.Parameters.AddWithValue("@username",username);
                
                com.ExecuteNonQuery();
             
                MessageBox.Show("reset successfully");
            }
            else
            {
                MessageBox.Show("passwords do not match");
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            sign_in sign_In = new sign_in();
            this.Hide();
            sign_In.Show();
        }
    }
}
