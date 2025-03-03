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
        private string selectedFilter;

        public sales_report(string filter)
        {
            InitializeComponent();
            selectedFilter = filter;
        }

        private void sales_report_Load(object sender, EventArgs e)
        {
            try
            {
                sales_cr report = new sales_cr();

                report.SetParameterValue("groupby", selectedFilter);

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
