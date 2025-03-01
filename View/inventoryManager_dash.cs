using finals_UI.Controller;
using finals_UI.Model.classes;
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
    public partial class inventoryManager_dash : Form
    {
        stockController stockController=new stockController();
        public inventoryManager_dash()
        {
            InitializeComponent();
        }

        private void btnitemInfo_Click(object sender, EventArgs e)
        {
            item_management item_Management = new item_management();
            item_Management.Show();
            this.Hide();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            view_stock view_Stock = new view_stock();
            view_Stock.Show();
            this.Hide();
        }

        private void managePayements_Click(object sender, EventArgs e)
        {

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            inventoryManager_profile inventoryManager_Profile = new inventoryManager_profile();
            inventoryManager_Profile.Show();
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

        private void inventoryManager_dash_Load(object sender, EventArgs e)
        {
            DataSet ds=stockController.restockItems();
            this.dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns["quantity"].DefaultCellStyle.ForeColor = Color.Red;



        }
    }
}



