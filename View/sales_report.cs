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
    public partial class sales_report : Form
    {
        public sales_report()
        {
            InitializeComponent();
        }

        private void sales_report_Load(object sender, EventArgs e)
        {
            sales_cr rpt = new sales_cr();
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
