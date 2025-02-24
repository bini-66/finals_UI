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
        }
        private void edit_appointments_Load(object sender, EventArgs e)
        {
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
                txtDate.Text = appointment.date.ToString("yyyy-MM-dd");
                txtTime.Text = appointment.time;

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

                // Set the services checkboxes
                var selectedServices = appointmentController.getSelectedServiceIds(appointmentId);
                foreach (CheckBox checkBox in flowLayoutPanelServices.Controls)
                {
                    int serviceId = (int)checkBox.Tag;
                    checkBox.Checked = selectedServices.Contains(serviceId);
                }
            }
            else
            {
                MessageBox.Show("Appointment not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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
                checkBox.Text = reader["serviceName"].ToString();
                checkBox.Tag = reader["serviceId"];
                flowLayoutPanelServices.Controls.Add(checkBox);
            }

            // Close the connection
            con.closeConnection();
        }

        //EVENTS
        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            string url = "http://kae.ct.ws/register.php";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
            string date = txtDate.Text;
            string time = txtTime.Text;
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
                }
                else
                {
                    MessageBox.Show("Failed to update appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
