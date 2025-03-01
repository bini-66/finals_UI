using finals_UI.Controller;
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
    public partial class view_stock : Form
    {
        stockController stockController=new stockController();
        stock stock=new stock();
        public view_stock()
        {
            InitializeComponent();
        }

        private void view_stock_Load(object sender, EventArgs e)
        {
            DataSet ds=stockController.loadStock();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText=this.txtsearch.Text;
            DataSet ds = stockController.serachResult(searchText);

            // Check if the DataSet is null or empty
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {

                MessageBox.Show("No records found for the search criteria.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataSet ds2 = stockController.loadStock();
                this.dataGridView1.DataSource = ds2.Tables[0];

            }
            else
            {
                
                dataGridView1.DataSource = ds.Tables[0];  
            }


        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DataSet ds = stockController.loadStock();
            this.dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btndash_Click(object sender, EventArgs e)
        {
            inventoryManager_dash inventoryManager_Dash = new inventoryManager_dash();  
            inventoryManager_Dash.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            inventoryManager_profile inventoryManager_Profile = new inventoryManager_profile();
            inventoryManager_Profile.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
