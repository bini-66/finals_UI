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
    public partial class purchase_report : Form
    {
        public purchase_report()
        {
            InitializeComponent();
        }

        private void purchase_report_Load(object sender, EventArgs e)
        {
            purchase_cr rpt = new purchase_cr();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
