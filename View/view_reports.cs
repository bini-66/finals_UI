using CrystalDecisions.CrystalReports.Engine;
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
    public partial class view_reports : Form
    {
        public view_reports()
        {
            InitializeComponent();
        }
        private void LoadReport(string reportPath)
        {
            string selectedFilter = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFilter))
            {
                MessageBox.Show("Please select a filter (Weekly, Monthly, or Yearly).");
                return;
            }

            try
            {
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(reportPath);

                reportDocument.SetParameterValue("GroupBy", selectedFilter);

                crystalReportViewer1.ReportSource = reportDocument;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}");
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            LoadReport(@"D:\NIBM\GUI-C#\finals_UI\View\sales_cr.rpt");
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadReport(@"D:\NIBM\GUI-C#\finals_UI\View\purchase_cr.rpt");
        }

        private void view_reports_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient mdiClient)
                {
                    mdiClient.BackColor = Color.FromArgb(24, 30, 54);
                    break;
                }
            }
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            LoadReport(@"D:\NIBM\GUI-C#\finals_UI\View\attendance_cr.rpt");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            owner_profile owner_Profile =new owner_profile();
            owner_Profile.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {

            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }
    }
}
