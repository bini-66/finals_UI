using finals_UI.Controller;
using finals_UI.Model.classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace finals_UI
{
    public partial class manage_employee : Form
    {
        userController userController=new userController();
        user user = new user();

        public manage_employee()
        {
            InitializeComponent();
        }

        private void manage_employee_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DataSet ds = userController.loadUsers();
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
