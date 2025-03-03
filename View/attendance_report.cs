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
    public partial class attendance_report : Form
    {
        public attendance_report()
        {
            InitializeComponent();
        }

        private void attendance_report_Load(object sender, EventArgs e)
        {
            attendance_cr report = new attendance_cr();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
