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
using finals_UI.Model.classes;
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
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void LoadAppointments()
        {
            //load appointments on load
            DataSet ds = appointmentController.loadAppointments();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "appointmentId",
                HeaderText = "Appointment ID",
                DataPropertyName = "appointmentId"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "plateNumber",
                HeaderText = "Plate Number",
                DataPropertyName = "plateNumber"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "date",
                HeaderText = "Date",
                DataPropertyName = "date"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "time",
                HeaderText = "Time",
                DataPropertyName = "time"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "appointmentStatus",
                HeaderText = "Status",
                DataPropertyName = "appointmentStatus"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "description",
                HeaderText = "Description",
                DataPropertyName = "description"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "firstName",
                HeaderText = "First Name",
                DataPropertyName = "firstName"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "lastName",
                HeaderText = "Last Name",
                DataPropertyName = "lastName"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "phone",
                HeaderText = "Phone",
                DataPropertyName = "phone"
            });

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
            apt.Show();
            this.Hide();
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
                var appointmentIdValue = dataGridView1.SelectedRows[0].Cells["appointmentId"].Value;
                if (appointmentIdValue != null && int.TryParse(appointmentIdValue.ToString(), out int appointmentId))
                {
                    Console.WriteLine("Selected Appointment ID: " + appointmentId); // Debug message
                    edit_appointments editForm = new edit_appointments(appointmentId);
                    editForm.ShowDialog();
                    this.Hide();
                    LoadAppointments(); //to refresh grid after editing
                }
                else
                {
                    MessageBox.Show("Invalid appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnapt_Click(object sender, EventArgs e)
        {
            view_appointment view_Appointment = new view_appointment();
            view_Appointment.Show();
            this.Hide();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            manage_sales_invoice manage_Sales_Invoice = new manage_sales_invoice();
            manage_Sales_Invoice.Show();
            this.Hide();
        }

        private void btnpayments_Click(object sender, EventArgs e)
        {
            this.Hide();
            manage_payment payment = new manage_payment(null);
            payment.Show();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            view_customer customer = new view_customer();
            customer.Show();
            this.Hide();
        }

    

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        //btn cust inquiries
        private void btnacc_Click(object sender, EventArgs e)
        {
         view_customer_inquiries view_Customer_Inquiries = new view_customer_inquiries();
         view_Customer_Inquiries.Show();
            this.Hide();
        }

        private void btnacc_Click_1(object sender, EventArgs e)
        {

            receptionist_profile profile1 = new receptionist_profile();
            profile1.Show();
            this.Hide();

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
