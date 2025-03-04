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
    public partial class receipt_display : Form
    {
        private string invoiceNo;
        public receipt_display(string invoiceNo)
        {
            InitializeComponent();
            this.invoiceNo = invoiceNo;
        }

        private void receipt_display_Load(object sender, EventArgs e)
        {
            try
            {
                receipt_cr report = new receipt_cr();

                report.SetParameterValue("InvoiceNo", invoiceNo);

                report.SetParameterValue("InvoiceNo", invoiceNo, "item_sub_cr.rpt");
                report.SetParameterValue("InvoiceNo", invoiceNo, "service_sub_cr.rpt");

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
