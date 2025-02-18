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
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;

namespace finals_UI
{
    public partial class new_appointments : Form
    {
        appointmentController appointmentController = new appointmentController();
        public new_appointments()
        {
            InitializeComponent();
            LoadServices();
        }

        //global variables
        private string selectedTimeSlot = "";

        //Other methods
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


        //events

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

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //BOLDING THE SELECTED DATE
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;

            //Check if selected date is in the past
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
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;
            DateTime today = DateTime.Today;

            Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };

            if (selectedDate < today)
            {
                // Disable and grey out all buttons for old dates
                foreach (Button btn in buttons)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.Gray;
                }
            }
            else
            {    // Reset all buttons to blue (available)
                foreach (Button btn in buttons)
                {
                    btn.Enabled = true;
                    btn.BackColor = Color.DodgerBlue;
                }
            }

            // Set the clicked button to orange
            Button clickedButton = (Button)sender;
            clickedButton.BackColor = Color.Orange;

            // Store the selected time slot
            selectedTimeSlot = clickedButton.Text;
        }

        private void new_appointment_Load(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            // Basic Validations
            if (string.IsNullOrEmpty(txtCustomerId.Text) || string.IsNullOrEmpty(txtVehicleId.Text))
            {
                MessageBox.Show("Please select a customer and vehicle.");
                return;
            }

            if (string.IsNullOrEmpty(selectedTimeSlot))
            {
                MessageBox.Show("Please select a time slot.");
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
                MessageBox.Show("Please select at least one service.");
                return;
            }

            // Save Appointment
            int appointmentId = appointmentController.saveAppointment(
                monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"),
                selectedTimeSlot,
                getStatus(),
                txtDescription.Text,
                Convert.ToInt32(txtCustomerId.Text),
                Convert.ToInt32(txtVehicleId.Text)
            );

            // Save Selected Services
            appointmentController.saveAppointmentServices(appointmentId, selectedServiceIds);

            MessageBox.Show("Appointment Reserved!");
            ClearAllFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
