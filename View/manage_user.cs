using finals_UI;
using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;
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
            DataSet ds = userController.loadUsers();
            this.dataGridView1.DataSource = ds.Tables[0];

            // Create a delete button column
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Actions";
            deleteButtonColumn.Name = "Actions";
            deleteButtonColumn.Text = "Delete";  
            deleteButtonColumn.UseColumnTextForButtonValue = true;  // Makes sure all buttons display "Delete"
            this.dataGridView1.Columns.Add(deleteButtonColumn);

        }

        private void label1_Click(object sender, EventArgs e)
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
            this.txtsearch.Text = "";
            DataSet ds = userController.loadUsers();
            this.dataGridView1.DataSource = ds.Tables[0];

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText=this.txtsearch.Text;
          
            DataSet ds = userController.serachUser(searchText);

            this.dataGridView1 .DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the button column was clicked
            if (e.ColumnIndex == dataGridView1.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                // Get the userId from the current row
                int userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["userId"].Value);

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete user {userId}?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Call the delete method here
                    userController.deleteUser(userId);
                    //refresh the DataGridView 
                    DataSet ds = userController.loadUsers();
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            superUser_dash superUser_Dash = new superUser_dash();
            superUser_Dash.Show();
            this.Hide();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            Register_user register_User = new Register_user();
            register_User.Show();
            this.Hide();
        }
    }
}
