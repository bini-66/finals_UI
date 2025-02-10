using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI
{
    public partial class Receptionist_dash : Form
    {
        public Receptionist_dash()
        {
            InitializeComponent();
        }

        private void Receptionist_dash_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            manage_customers customers = new manage_customers();     
            customers.ShowDialog();
           


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            place_appointments appt=new place_appointments();
            appt.ShowDialog();  
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            payment payment = new payment();
            payment.ShowDialog();
        }
    }
}
