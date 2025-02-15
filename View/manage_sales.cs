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
    public partial class manage_sales : Form
    {
        saleController saleController=new saleController();
        sale sale=new sale();   

        public manage_sales()
        {
            InitializeComponent();
        }

        private void manage_sales_Load(object sender, EventArgs e)
        {
            //populating combo box with item names
            DataSet ds = saleController.loadItemName();
            CBitmName.DataSource = ds.Tables[0];
            CBitmName.DisplayMember = "itemName";
            CBitmName.ValueMember = "itemId";
            // Make the ComboBox display empty initially
            CBitmName.SelectedIndex = -1;

        }
    }
}
