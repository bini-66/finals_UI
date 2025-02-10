using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Model;
using finals_UI.Controller;
using finals_UI.Model.classes;

namespace finals_UI
{
    public partial class manage_services : Form
    {
        serviceController serviceController=new serviceController();
        service service = new service();
        public manage_services()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
           
            service.serviceName=this.txtsername.Text;
            service.serviceDescription=this.txtserdes.Text;
            service.servicePrice = float.Parse(this.txtserprice.Text);
            service.serviceManagerId = 1;       //need to maintain a session fr this
            serviceController.addService(service);


        }

        private void btnview_Click(object sender, EventArgs e)
        {
            
            DataSet ds= serviceController.viewServices();
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
