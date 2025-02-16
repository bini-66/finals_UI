using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Controller;

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
            place_appointments apt = new place_appointments();
            apt.ShowDialog();
        }
    }
}
