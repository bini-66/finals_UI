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
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;


namespace finals_UI.View
{
    public partial class edit_appointments : Form
    {
        appointmentController appointmentController = new appointmentController();
        public edit_appointments()
        {
            InitializeComponent();
            LoadServices();
        }

        //global variables
        private string selectedTimeSlot = "";
        private int appointmentId;

        public edit_appointments(int appointmentId) : this()
        {
            this.appointmentId = appointmentId;
            LoadAppointmentDetails();
        }

        //other methods
        private void LoadAppointmentDetails()
        {
            var appointment = appointmentController.getAppointmentById(appointmentId);
            if (appointment != null)
            {
                txtCustomerId.Text = appointment.customerId.ToString();
                txtFullName.Text = appointment.customerName;
                txtPhone.Text = appointment.phoneNumber;
                txtVehicleId.Text = appointment.vehicleId.ToString();
                txtPlateNumber.Text = appointment.plateNumber;
                txtDescription.Text = appointment.description;
                // Set the status radio button
                switch (appointment.appointmentStatus)
                {
                    case "Confirmed":
                        rbConfirmed.Checked = true;
                        break;
                    case "Pending":
                        rbPending.Checked = true;
                        break;
                    case "Cancelled":
                        rbCancelled.Checked = true;
                        break;
                    case "Missed":
                        rbMissed.Checked = true;
                        break;
                }
                // Set the date in the calendar
                monthCalendar1.SetDate(appointment.date);
                // Set the time slot button
                switch (appointment.time)
                {
                    case "10:00":
                        SlotButton_Click(btnSlot10, null);
                        break;
                    case "11:00":
                        SlotButton_Click(btnSlot11, null);
                        break;
                    case "12:00":
                        SlotButton_Click(btnSlot12, null);
                        break;
                    case "13:00":
                        SlotButton_Click(btnSlot13, null);
                        break;
                    case "14:00":
                        SlotButton_Click(btnSlot14, null);
                        break;
                    case "15:00":
                        SlotButton_Click(btnSlot15, null);
                        break;
                    case "16:00":
                        SlotButton_Click(btnSlot16, null);
                        break;
                    case "17:00":
                        SlotButton_Click(btnSlot17, null);
                        break;
                    case "18:00":
                        SlotButton_Click(btnSlot18, null);
                        break;
                }
                // Set the services checkboxes
                var selectedServices = appointmentController.getSelectedServiceIds(appointmentId);
                foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
                {
                    int serviceId = (int)checkBox.Tag;
                    if (selectedServices.Contains(serviceId))
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }

        private string getStatus()
        {
            if (rbConfirmed.Checked) return "Confirmed";
            if (rbPending.Checked) return "Pending";
            if (rbCancelled.Checked) return "Cancelled";
            if (rbMissed.Checked) return "Missed";
            return "Pending"; // Default
        }

        private void ClearAllFields()
        {
            txtCustomerId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtVehicleId.Clear();
            txtPlateNumber.Clear();
            txtDescription.Clear();

            foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
            {
                checkBox.Checked = false;
            }

            selectedTimeSlot = null;
            rbPending.Checked = true;

            // Clear search results in the DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            // Reset the selected date in the calendar
            monthCalendar1.SetDate(DateTime.Today);

            // Clear all bolded dates
            monthCalendar1.BoldedDates = new DateTime[] { };
            monthCalendar1.UpdateBoldedDates();
        }

        private void LoadServices()
        {
            // Clear existing checkboxes
            flowLayoutPanelServices.Controls.Clear();

            // Establish a connection
            dbConnection con = new dbConnection();
            con.openConnection();

            // Query to get all services
            string query = "SELECT serviceId, serviceName FROM service";
            MySqlCommand com = new MySqlCommand(query, con.getConnection());
            MySqlDataReader reader = com.ExecuteReader();

            // Dynamically create checkboxes
            while (reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = reader["serviceName"].ToString(); // Set service name as text
                checkBox.Tag = reader["serviceId"]; // Set service ID as tag
                flowLayoutPanelServices.Controls.Add(checkBox);
            }

            // Close the connection
            con.closeConnection();
        }

        //EVENTS
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
            string url = "http://kae.ct.ws/register.php";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;
            DateTime today = DateTime.Today;

            // Reset all buttons to blue (available)
            ResetButtons();

            if (selectedDate < today)
            {
                // Disable and grey out all buttons for old dates
                DisableAllButtons();
                MessageBox.Show("You cannot select a date in the past.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method early
            }

            // Get unavailable slots for the selected date
            List<string> unavailableSlots = appointmentController.getUnavailableSlots(selectedDate);

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

        private void ResetButtons()
        {
            Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };
            foreach (Button btn in buttons)
            {
                btn.Enabled = true;
                btn.BackColor = Color.DodgerBlue;
            }
        }

        private void DisableAllButtons()
        {
            Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
                btn.BackColor = Color.Gray;
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //BOLDING THE SELECTED DATE
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            //Check if old date
            if (selectedDate < DateTime.Today)
            {
                MessageBox.Show("You cannot select a date in the past.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Reset to today's date
                monthCalendar1.SetDate(DateTime.Today);
                return;
            }

            //Clear previous bolded dates
            monthCalendar1.BoldedDates = new DateTime[0];

            //Bold the newly selected date
            monthCalendar1.AddBoldedDate(selectedDate);
            monthCalendar1.UpdateBoldedDates();

            //FLICKER FIX (For old dates at least. Limitations for bolded)
            monthCalendar1.SuspendLayout();
            // Apply the grey-out logic here
            foreach (DateTime date in monthCalendar1.BoldedDates)
            {
                if (date < DateTime.Today)
                {
                    monthCalendar1.RemoveBoldedDate(date);
                }
            }
            monthCalendar1.UpdateBoldedDates();
            monthCalendar1.ResumeLayout();
        }

        private void SlotButton_Click(object sender, EventArgs e)
        {
            //Reset only the previously selected slot, if any
            if (!string.IsNullOrEmpty(selectedTimeSlot))
            {
                foreach (Button btn in new Button[] { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 })
                {
                    if (btn.Text == selectedTimeSlot)
                    {
                        btn.BackColor = Color.DodgerBlue;
                        break;
                    }
                }
            }

            //Selected slot to orange
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Orange;

            selectedTimeSlot = clickedButton.Text;
            //Console.WriteLine("Selected Time Slot: " + selectedTimeSlot);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerId.Text) || string.IsNullOrEmpty(txtVehicleId.Text))
            {
                MessageBox.Show("Please select a customer and vehicle.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrEmpty(selectedTimeSlot))
            {
                MessageBox.Show("Please select a time slot.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> selectedServiceIds = new List<int>();
            foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
            {
                if (checkBox.Checked)
                {
                    int serviceId = (int)checkBox.Tag;
                    selectedServiceIds.Add(serviceId);
                }
            }

            if (selectedServiceIds.Count == 0)
            {
                MessageBox.Show("Please select at least one service.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Prepare appointment data
            string date = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            string time = selectedTimeSlot;
            string status = getStatus();
            string description = txtDescription.Text;
            int customerId = Convert.ToInt32(txtCustomerId.Text);
            int vehicleId = Convert.ToInt32(txtVehicleId.Text);

            if(appointmentId > 0)
            {
                // Update existing appointment
                int rowsAffected = appointmentController.updateAppointment(appointmentId, date, time, status, description, customerId, vehicleId);
            
                if (rowsAffected > 0)
                {
                    // Update services
                    appointmentController.updateAppointmentServices(appointmentId, selectedServiceIds);
                    MessageBox.Show("Appointment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllFields();
                }
                else
                {
                    MessageBox.Show("Failed to update appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
            ClearAllFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
