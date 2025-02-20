using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Controller;
using finals_UI.View;

namespace finals_UI
{
    public partial class view_appointment : Form
    {
        appointmentController appointmentController = new appointmentController();
        public view_appointment()
        {
            InitializeComponent();
        }

        private void view_appointment_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            //load appointments on load
            DataSet ds = appointmentController.loadAppointments();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];

            // Map predefined columns to dataset columns
            dataGridView1.Columns["appointmentId"].DataPropertyName = "appointmentId";
            dataGridView1.Columns["plateNumber"].DataPropertyName = "plateNumber";
            dataGridView1.Columns["date"].DataPropertyName = "date";
            dataGridView1.Columns["time"].DataPropertyName = "time";
            dataGridView1.Columns["appointmentStatus"].DataPropertyName = "appointmentStatus";
            dataGridView1.Columns["description"].DataPropertyName = "description";
            dataGridView1.Columns["firstName"].DataPropertyName = "firstName";
            dataGridView1.Columns["lastName"].DataPropertyName = "lastName";
            dataGridView1.Columns["phone"].DataPropertyName = "phone";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //load appointments on load
            DataSet ds = appointmentController.searchAppointments(txtSearch.Text);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables[0];

            // Map predefined columns to dataset columns
            dataGridView1.Columns["appointmentId"].DataPropertyName = "appointmentId";
            dataGridView1.Columns["plateNumber"].DataPropertyName = "plateNumber";
            dataGridView1.Columns["date"].DataPropertyName = "date";
            dataGridView1.Columns["time"].DataPropertyName = "time";
            dataGridView1.Columns["appointmentStatus"].DataPropertyName = "appointmentStatus";
            dataGridView1.Columns["description"].DataPropertyName = "description";
            dataGridView1.Columns["firstName"].DataPropertyName = "firstName";
            dataGridView1.Columns["lastName"].DataPropertyName = "lastName";
            dataGridView1.Columns["phone"].DataPropertyName = "phone";
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            new_appointments apt = new new_appointments();
            apt.ShowDialog();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            string url = "http://kae.ct.ws/register.php";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[hit.RowIndex].Cells[0];
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int appointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["appointmentId"].Value);
                edit_appointments editForm = new edit_appointments(appointmentId);
                editForm.ShowDialog();
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void selectEntireRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void selectCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
    }
}
