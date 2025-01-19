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
    public partial class place_appointments : Form
    {
        public place_appointments()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
                 this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist_dash dash= new Receptionist_dash();
            dash.Show();
        }
    }
}
