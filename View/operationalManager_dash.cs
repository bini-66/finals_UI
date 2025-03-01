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
    public partial class operationalManager_dash : Form
    {
        public operationalManager_dash()
        {
            InitializeComponent();
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            manage_supplier manage_Supplier = new manage_supplier();
            manage_Supplier.Show();
            this.Hide();

        }

        private void btnmaintainance_Click(object sender, EventArgs e)
        {
            maintenance_transaction transaction = new maintenance_transaction();    
            transaction.Show();
            this.Hide();
        }

        private void btnsuptrans_Click(object sender, EventArgs e)
        {
            manage_purchases purchases = new manage_purchases();
            purchases.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            operationalManager_profile profile = new operationalManager_profile();
            profile.Show();
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
