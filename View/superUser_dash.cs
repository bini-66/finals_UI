using finals_UI.Model.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.View
{
    public partial class superUser_dash : Form
    {
        public superUser_dash()
        {
            InitializeComponent();
        }

        private void btnmanageUsers_Click(object sender, EventArgs e)
        {
            manage_employee manage_user=new manage_employee();
            manage_user.Show();
            this.Hide();
        }

        private void btnreguser_Click(object sender, EventArgs e)
        {
            Register_user register_User = new Register_user();
            register_User.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Show();
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
