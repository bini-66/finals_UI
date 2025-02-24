using finals_UI.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finals_UI.Model;
using finals_UI.Model.classes;

namespace finals_UI
{
    public partial class maintenance_transaction : Form
    {
        maintenanceController maintenanceController = new maintenanceController();
        maintenance maintenance = new maintenance();
        public maintenance_transaction()
        {
            InitializeComponent();
            DataSet ds = maintenanceController.viewMaintenanceDetails();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["MaintenanceIDs"].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manage_stock_Load(object sender, EventArgs e)
        { 

        }

        private void btnview_Click(object sender, EventArgs e)
        {
            DataSet ds = maintenanceController.viewMaintenanceDetails();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["MaintenanceIDs"].Visible = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //validations
            if (this.cbVehicleNo.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.cbVehicleNo, "Please select an vehicle plate number");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            //supplier company
            if (this.cbEmp.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(this.cbEmp, "Please select an employee");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            if (this.cbStatus.SelectedIndex == -1)
            {
                this.errorProvider3.SetError(this.cbStatus, "Please select a maintenance status");
                return;
            }
            else
            {
                errorProvider3.Clear();
            }
            if (this.cbInvoiceNo.SelectedIndex == -1)
            {
                this.errorProvider4.SetError(this.cbInvoiceNo, "Please select an invoice number");
                return;
            }
            else
            {
                errorProvider4.Clear();
            }
            if (this.cbServices.SelectedIndex == -1)
            {
                this.errorProvider6.SetError(this.cbServices, "Please select the services to be performed");
                return;
            }
            else
            {
                errorProvider6.Clear();
            }
            //supplier invoice
            if (this.txtDesc.Text == "")
            {
                this.errorProvider5.SetError(this.txtDesc, "Please enter a maintenance description");
                return;
            }
            else
            {
                errorProvider5.Clear();

            }
            maintenance.vehicleId = Convert.ToInt32(this.cbVehicleNo.SelectedValue);
            maintenance.employeeId = Convert.ToInt32(this.cbEmp.SelectedValue);
            maintenance.maintenanceStatus = this.cbStatus.SelectedItem.ToString();
            maintenance.serviceId = Convert.ToInt32(this.cbServices.SelectedValue);
            maintenance.customerInvoiceId = Convert.ToInt32(cbInvoiceNo.SelectedValue);
            maintenance.maintenanceDate = Convert.ToDateTime(this.dtpMaintDate.Value);
            maintenance.maintenanceDescription = this.txtDesc.Text;

            maintenanceController.addMaintenance(maintenance);

            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.cbEmp.Text = this.dataGridView1.CurrentRow.Cells["Employee"].Value.ToString();
            this.cbVehicleNo.Text = this.dataGridView1.CurrentRow.Cells["PlateNo"].Value.ToString();
            this.cbServices.Text = this.dataGridView1.CurrentRow.Cells["Services"].Value.ToString();
            this.cbStatus.Text = this.dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
            this.txtDesc.Text = this.dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            this.dtpMaintDate.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["Date"].Value);
            this.cbInvoiceNo.Text = this.dataGridView1.CurrentRow.Cells["InvoiceNo"].Value.ToString();
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            //validations
            if (this.cbVehicleNo.SelectedIndex == -1)
            {
                this.errorProvider1.SetError(this.cbVehicleNo, "Please select an vehicle plate number");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            //supplier company
            if (this.cbEmp.SelectedIndex == -1)
            {
                this.errorProvider2.SetError(this.cbEmp, "Please select an employee");
                return;
            }
            else
            {
                errorProvider2.Clear();
            }
            if (this.cbStatus.SelectedIndex == -1)
            {
                this.errorProvider3.SetError(this.cbStatus, "Please select a maintenance status");
                return;
            }
            else
            {
                errorProvider3.Clear();
            }
            if (this.cbInvoiceNo.SelectedIndex == -1)
            {
                this.errorProvider4.SetError(this.cbInvoiceNo, "Please select an invoice number");
                return;
            }
            else
            {
                errorProvider4.Clear();
            }
            if (this.cbServices.SelectedIndex == -1)
            {
                this.errorProvider6.SetError(this.cbServices, "Please select the services to be performed");
                return;
            }
            else
            {
                errorProvider6.Clear();
            }
            //supplier invoice
            if (this.txtDesc.Text == "")
            {
                this.errorProvider5.SetError(this.txtDesc, "Please enter a maintenance description");
                return;
            }
            else
            {
                errorProvider5.Clear();

            }
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a maintenance record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected Maintenance ID(s) from the DataGridView
                string maintenanceIdString = dataGridView1.CurrentRow.Cells["MaintenanceIDs"].Value.ToString();
                List<int> maintenanceIds = maintenanceIdString
                    .Split(',')
                    .Select(id => int.TryParse(id.Trim(), out int parsedId) ? parsedId : -1)
                    .Where(parsedId => parsedId != -1) // Remove invalid IDs
                    .ToList();

                if (maintenanceIds.Count == 0)
                {
                    MessageBox.Show("Invalid Maintenance ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                maintenance.maintenanceStatus = this.cbStatus.SelectedItem.ToString();
                maintenance.maintenanceDate = Convert.ToDateTime(this.dtpMaintDate.Value);
                maintenance.maintenanceDescription = this.txtDesc.Text;

                maintenanceController.updateMaintenance(maintenanceIds, maintenance.maintenanceStatus, maintenance.maintenanceDescription, maintenance.maintenanceDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();
        }

        private void btndlt_Click(object sender, EventArgs e)
        {
            maintenanceController.deleteMaintenance(this.dataGridView1.CurrentRow.Cells["MaintenanceIDs"].Value.ToString());
            //refresh grid
            refreshGrid();

            //clear Fields
            clearFields();
        }

        private void refreshGrid()
        {
            DataSet ds = maintenanceController.viewMaintenanceDetails();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["MaintenanceIDs"].Visible = false;
        }
        private void clearFields()
        {
            this.cbVehicleNo.SelectedIndex = -1;
            this.dtpMaintDate.Value = DateTime.Now;
            this.cbEmp.SelectedIndex = -1;
            this.cbServices.SelectedIndex = -1;
            this.cbStatus.SelectedIndex = -1;
            this.cbInvoiceNo.SelectedIndex = -1;
            this.txtDesc.Text = "";
            this.CBcolumns.SelectedIndex = -1;
            this.txtsearch.Text = "";
            refreshGrid();
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (this.CBcolumns.SelectedIndex == 0)
            {
                string employeeName = this.txtsearch.Text.Trim();

                // Ensure search text is not empty
                if (string.IsNullOrEmpty(employeeName))
                {
                    MessageBox.Show("Please enter an employee name to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = maintenanceController.searchByEmployee(employeeName);

                // Check if dataset is null or empty
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    this.dataGridView1.DataSource = null; // Clears the grid without reloading all data
                    return;
                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex == 1)
            {
                string plateNumber = this.txtsearch.Text;

                // Ensure search text is not empty
                if (string.IsNullOrEmpty(plateNumber))
                {
                    MessageBox.Show("Please enter a vehicle plate number to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet ds = maintenanceController.searchByPlateNumber(plateNumber);

                // Check if dataset is null or empty
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    this.dataGridView1.DataSource = null;
                    return;
                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex == 2)
            {
                string maintenanceStatus = this.txtsearch.Text;

                // Ensure search text is not empty
                if (string.IsNullOrEmpty(maintenanceStatus))
                {
                    MessageBox.Show("Please enter a maintenance status to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet ds = maintenanceController.searchByMaintenanceStatus(maintenanceStatus);

                // Check if dataset is null or empty
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    this.dataGridView1.DataSource = null;
                    return;
                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else if (this.CBcolumns.SelectedIndex == 3)
            {
                string customerInvoiceNo = this.txtsearch.Text;

                // Ensure search text is not empty
                if (string.IsNullOrEmpty(customerInvoiceNo))
                {
                    MessageBox.Show("Please enter an invoice number to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataSet ds = maintenanceController.searchByInvoiceNo(customerInvoiceNo);

                // Check if dataset is null or empty
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No matching results found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtsearch.Text = "";
                    this.dataGridView1.DataSource = null;
                    return;
                }
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Please select a column to search by", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void maintenance_transaction_Load(object sender, EventArgs e)
        {
            DataSet ds = maintenanceController.loadVehicleNo();
            cbVehicleNo.DataSource = ds.Tables[0];
            cbVehicleNo.DisplayMember = "plateNumber";
            cbVehicleNo.ValueMember = "vehicleId";
            // Make the ComboBox display empty initially
            cbVehicleNo.SelectedIndex = -1;

            DataSet ds1 = maintenanceController.loadEmployeeName();
            cbEmp.DataSource = ds1.Tables[0];
            cbEmp.DisplayMember = "Name";
            cbEmp.ValueMember = "employeeId";
            // Make the ComboBox display empty initially
            cbEmp.SelectedIndex = -1;

            DataSet ds2 = maintenanceController.loadServices();
            cbServices.DataSource = ds2.Tables[0];
            cbServices.DisplayMember = "Services";
            cbServices.ValueMember = "appointmentId";
            // Make the ComboBox display empty initially
            cbServices.SelectedIndex = -1;

            DataSet ds3 = maintenanceController.loadInvoiceNo();
            cbInvoiceNo.DataSource = ds3.Tables[0];
            cbInvoiceNo.DisplayMember = "invoiceNo";
            cbInvoiceNo.ValueMember = "customerInvoiceId";
            // Make the ComboBox display empty initially
            cbInvoiceNo.SelectedIndex = -1;
        }
    }
}
