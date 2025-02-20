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
        private int appointmentId;
        appointmentController appointmentController = new appointmentController();
        private string selectedTimeSlot = "";
        public edit_appointments(int appointmentId)
        {
            InitializeComponent();
            this.appointmentId = appointmentId;
            LoadAppointmentData();
            LoadServices();

        }

        //other methods
        private void LoadAppointmentData()
        {
            appointment apt = appointmentController.GetAppointmentById(appointmentId);
            if (apt != null)
            {
                // Populate text boxes and other components
                txtCustomerId.Text = apt.customerId.ToString();
                txtFullName.Text = apt.customerName;
                txtPhone.Text = apt.customerPhone;
                txtVehicleId.Text = apt.vehicleId.ToString();
                txtPlateNumber.Text = apt.plateNumber;
                txtDescription.Text = apt.description;

                // Set the selected date in the month calendar
                monthCalendar1.SetDate(apt.date);

                // Set the selected time slot button
                selectedTimeSlot = apt.time;
                Button[] buttons = { btnSlot10, btnSlot11, btnSlot12, btnSlot13, btnSlot14, btnSlot15, btnSlot16, btnSlot17, btnSlot18 };
                foreach (Button btn in buttons)
                {
                    if (btn.Text == selectedTimeSlot)
                    {
                        btn.BackColor = Color.Orange;
                        break;
                    }
                }

                // Set the appointment status
                switch (apt.appointmentStatus)
                {
                    case "Confirmed": rbConfirmed.Checked = true; break;
                    case "Pending": rbPending.Checked = true; break;
                    case "Cancelled": rbCancelled.Checked = true; break;
                    case "Missed": rbMissed.Checked = true; break;
                    default: rbPending.Checked = true; break;
                }

                // Fetch and tick the selected services
                List<int> selectedServices = appointmentController.GetSelectedServices(appointmentId);
                foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
                {
                    if (selectedServices.Contains((int)checkBox.Tag))
                    {
                        checkBox.Checked = true;
                    }
                }
            }
        }

        private void LoadServices()
        {
            // Clear existing checkboxes
            flowLayoutPanelServices.Controls.Clear();

            // Fetch services from the database
            List<KeyValuePair<int, string>> services = appointmentController.getServices();

            // Dynamically create checkboxes
            foreach (var service in services)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = service.Value; // Set service name as text
                checkBox.Tag = service.Key; // Set service ID as tag
                flowLayoutPanelServices.Controls.Add(checkBox);
            }
        }

        // Get the selected status
        private string getStatus()
        {
            if (rbConfirmed.Checked) return "Confirmed";
            if (rbPending.Checked) return "Pending";
            if (rbCancelled.Checked) return "Cancelled";
            if (rbMissed.Checked) return "Missed";
            return "Pending"; // Default
        }

        // Reset all fields
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

            // Reset the selected date in the calendar
            monthCalendar1.SetDate(DateTime.Today);

            // Clear all bolded dates
            monthCalendar1.BoldedDates = new DateTime[] { };
            monthCalendar1.UpdateBoldedDates();
        }


        //EVENTS
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            string url = "http://kae.ct.ws/register.php";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            // Update Appointment
            bool isAppointmentUpdated = appointmentController.UpdateAppointment(
                appointmentId,
                monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd"),
                selectedTimeSlot,
                getStatus(),
                txtDescription.Text,
                Convert.ToInt32(txtCustomerId.Text),
                Convert.ToInt32(txtVehicleId.Text)
            );

            // Update Selected Services
            bool areServicesUpdated = appointmentController.UpdateAppointmentServices(appointmentId, selectedServiceIds);

            if (isAppointmentUpdated && areServicesUpdated)
            {
                MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
