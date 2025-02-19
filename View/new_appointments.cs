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
using finals_UI.Model.classes;

namespace finals_UI
{
    public partial class new_appointments : Form
    {
        appointmentController appointmentController = new appointmentController();
        public new_appointments()
        {
            InitializeComponent();
        }

        private void dataGridView1_SelectedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtCustomerId.Text = dataGridView1.SelectedRows[0].Cells["Customer ID"].Value.ToString();
                txtFullName.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                txtPhone.Text = dataGridView1.SelectedRows[0].Cells["Phone Number"].Value.ToString();
                txtVehicleId.Text = dataGridView1.SelectedRows[0].Cells["Vehicle ID"].Value.ToString();
                txtPlateNumber.Text = dataGridView1.SelectedRows[0].Cells["Vehicle Plate"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = appointmentController.searchCustomer(txtSearch.Text);

            // Clear previous data
            dataGridView1.DataSource = null;

            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("No results found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Clear search bar after searching
            txtSearch.Text = "";
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            List<string> unavailableSlots = appointmentController.getUnavailableSlots(monthCalendar1.SelectionRange.Start);

            // Reset all buttons to blue (available)
            Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };
            foreach (Button btn in buttons)
            {
                btn.Enabled = true;
                btn.BackColor = Color.DodgerBlue;
            }

            // Disable and grey out unavailable slots
            foreach (string time in unavailableSlots)
            {
                switch (time)
                {
                    case "10:00":
                        btnSlot10.Enabled = false;
                        btnSlot10.BackColor = Color.Gray;
                        break;
                    case "11:00":
                        btnSlot11.Enabled = false;
                        btnSlot11.BackColor = Color.Gray;
                        break;
                    case "12:00":
                        btnSlot12.Enabled = false;
                        btnSlot12.BackColor = Color.Gray;
                        break;
                    case "13:00":
                        btnSlot13.Enabled = false;
                        btnSlot13.BackColor = Color.Gray;
                        break;
                    case "14:00":
                        btnSlot14.Enabled = false;
                        btnSlot14.BackColor = Color.Gray;
                        break;
                    case "15:00":
                        btnSlot15.Enabled = false;
                        btnSlot15.BackColor = Color.Gray;
                        break;
                    case "16:00":
                        btnSlot16.Enabled = false;
                        btnSlot16.BackColor = Color.Gray;
                        break;
                    case "17:00":
                        btnSlot17.Enabled = false;
                        btnSlot17.BackColor = Color.Gray;
                        break;
                    case "18:00":
                        btnSlot18.Enabled = false;
                        btnSlot18.BackColor = Color.Gray;
                        break;
                }
            }
        }

        private void SlotButton_Click(object sender, EventArgs e)
        {
            // Reset all other buttons to blue (if available)
            Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };
            foreach (Button btn in buttons)
            {
                if (btn.Enabled)
                {
                    btn.BackColor = Color.DodgerBlue;
                }
            }

            // Set the clicked button to orange
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Orange;
        }

        private void new_appointment_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<int, string>> services = appointmentController.getServices();

            foreach (var service in services)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = service.Value;
                checkBox.Tag = service.Key; //store serviceId as a tag
                checkBox.AutoSize = true;
                flowLayoutPanelServices.Controls.Add(checkBox);
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            //List<int> selectedServiceIds = new List<int>();

            //foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
            //{
            //    if (checkBox.Checked)
            //    {
            //        int serviceId = (int)checkBox.Tag;
            //        selectedServiceIds.Add(serviceId);
            //    }
            //}

            //appointmentController.saveAppointmentServices(appointmentId, selectedServiceIds);
            //MessageBox.Show("Appointment and Services Reserved!");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
