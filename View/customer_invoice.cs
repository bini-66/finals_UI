using CrystalDecisions.CrystalReports.Engine;
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
    public partial class customer_invoice : Form
    {
        private string invoiceNo;
        public customer_invoice(string invoiceNo)
        {
            InitializeComponent();
            this.invoiceNo = invoiceNo;
        }

        private void customer_invoice_Load(object sender, EventArgs e)
        {
            try
            {
                customerInvoice_cr report = new customerInvoice_cr();

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
