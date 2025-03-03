using finals_UI.Controller;
using finals_UI.Model.classes;
using finals_UI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI
{
    public partial class employee_attendance : Form
    {
        attendanceController attendanceController = new attendanceController();
        //attendance attendance = new attendance();
        public employee_attendance()
        {
            InitializeComponent();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void employee_attendance_Load(object sender, EventArgs e)
        {
            monthCalendar1.MaxDate = DateTime.Today;

            // Set the current date as the selected date 
            monthCalendar1.SelectionStart = DateTime.Today;
            //this.btnup.Visible = false;

            // Manually call the method to load attendance status for today's date
           // monthCalendar1_DateSelected(monthCalendar1, new DateRangeEventArgs(DateTime.Now, DateTime.Now));

            //load employee details on load
            DataSet ds = attendanceController.loadEmployeeInfo();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            // Map predefined columns to dataset columns
            dataGridView1.Columns["Employee_ID"].DataPropertyName = "employeeId";
            dataGridView1.Columns["Employee_Name"].DataPropertyName = "firstName";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)  // Ensure we don't modify the new (empty) row
                {
                    row.Cells["Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }
            DataSet ds2 = attendanceController.loadAttendanceStatus(monthCalendar1.SelectionStart.Date);
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {

                if (dgvRow.Cells["Employee_ID"].Value != null)
                {
                    string employeeId = dgvRow.Cells["Employee_ID"].Value.ToString();

                    foreach (DataRow dbRow in ds2.Tables[0].Rows)
                    {
                        if (dbRow["employeeId"].ToString() == employeeId)
                        {
                            string status = dbRow["attendanceStatus"].ToString().ToLower();
                            dgvRow.Cells["Status"].Value = (status == "present"); // Checkbox checked if present
                            break;
                        }
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //this.btnup.Enabled = true;
            calendarDateChange();

        }
        //save button
        private void button8_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
           // this.btnsave.Enabled = false;
            List<attendance> records = new List<attendance>();

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
               int employeeId = Convert.ToInt32(row.Cells["Employee_ID"].Value);
               DateTime date= Convert.ToDateTime(row.Cells["Date"].Value);

                bool isChecked = row.Cells["Status"].Value != null && (bool)row.Cells["Status"].Value;
                string status = isChecked ? "present" : "absent";

                records.Add(new attendance(employeeId,date,status));

            }



            if (records.Count > 0)
            {
                attendanceController.saveAttendance(records,selectedDate);
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            List<attendance> records = new List<attendance>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int employeeId = Convert.ToInt32(row.Cells["Employee_ID"].Value);
                DateTime date = Convert.ToDateTime(row.Cells["Date"].Value);

                bool isChecked = row.Cells["Status"].Value != null && (bool)row.Cells["Status"].Value;
                string status = isChecked ? "present" : "absent";

                records.Add(new attendance(employeeId, date, status));

            }



            if (records.Count > 0)
            {
                attendanceController.updateAttendance(records);
            }

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
           this.txtdate.Text= monthCalendar1.SelectionStart.ToShortDateString();
            //load employee details
            DataSet ds = attendanceController.loadEmployeeInfo();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            // Map predefined columns to dataset columns
            dataGridView1.Columns["Employee_ID"].DataPropertyName = "employeeId";
            dataGridView1.Columns["Employee_Name"].DataPropertyName = "firstName";

            // Set the selected date from MonthCalendar to "Date" column
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Ensure we don't modify the new (empty) row
                {
                    row.Cells["Date"].Value = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
                }
            }

            DataSet ds2 = attendanceController.loadAttendanceStatus(monthCalendar1.SelectionStart.Date);
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {

                if (dgvRow.Cells["Employee_ID"].Value != null)
                {
                    string employeeId = dgvRow.Cells["Employee_ID"].Value.ToString();

                    foreach (DataRow dbRow in ds2.Tables[0].Rows)
                    {
                        if (dbRow["employeeId"].ToString() == employeeId)
                        {
                            string status = dbRow["attendanceStatus"].ToString().ToLower();
                            dgvRow.Cells["Status"].Value = (status == "present"); // Checkbox checked if present
                            break;
                        }
                    }
                }
            }
        }
        private void calendarDateChange()
        {
            this.txtdate.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //load employee details
            DataSet ds = attendanceController.loadEmployeeInfo();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];

            // Map predefined columns to dataset columns
            dataGridView1.Columns["Employee_ID"].DataPropertyName = "employeeId";
            dataGridView1.Columns["Employee_Name"].DataPropertyName = "firstName";

            // Set the selected date from MonthCalendar to "Date" column
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // Ensure we don't modify the new (empty) row
                {
                    row.Cells["Date"].Value = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
                }
            }

            DataSet ds2 = attendanceController.loadAttendanceStatus(monthCalendar1.SelectionStart.Date);
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {

                if (dgvRow.Cells["Employee_ID"].Value != null)
                {
                    string employeeId = dgvRow.Cells["Employee_ID"].Value.ToString();

                    foreach (DataRow dbRow in ds2.Tables[0].Rows)
                    {
                        if (dbRow["employeeId"].ToString() == employeeId)
                        {
                            string status = dbRow["attendanceStatus"].ToString().ToLower();
                            dgvRow.Cells["Status"].Value = (status == "present"); // Checkbox checked if present
                            break;
                        }
                    }
                }
            }
        
            // dataGridView1.Refresh();

        }
       
        //search button
        private void button7_Click(object sender, EventArgs e)
        {
           
            //    string empInfo = this.txtsearch.Text;
            //    DateTime date= monthCalendar1.SelectionStart;

            ////load data in to data grid
            //DataSet ds = attendanceController.loadSearchResults(empInfo,date);
            //dataGridView1.Columns["Date"].DataPropertyName = "date";
            ////dataGridView1.Columns["Status"].DataPropertyName = "attendanceStatus";

            //dataGridView1.Columns["Status"].DataPropertyName = "attendanceStatus"; 

            //// Convert "attendanceStatus" to boolean for checkbox column
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (!row.IsNewRow && row.Cells["Status"].Value != null)
            //    {
            //        string status = row.Cells["Status"].Value.ToString().Trim().ToLower();
            //        row.Cells["Status"].Value= status == "present"; // True if "present", false otherwise
            //            dataGridView1.Refresh();

            //    }
            //}



            //// Check if dataset is empty
            //if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            //    {
            //        MessageBox.Show("No matching employee found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        this.txtsearch.Text = "";
            //        return;

            //    }
            //    this.dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void btndash_Click(object sender, EventArgs e)
        {
            employee_attendance employee_Attendance = new employee_attendance();
            employee_Attendance.Show();
            this.Hide();
        }

        private void btnacc_Click(object sender, EventArgs e)
        {
            manage_offers manage_Offers = new manage_offers();
            manage_Offers.Show();
            this.Hide();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            userSession.Logout();

            sign_in sign_In = new sign_in();
            sign_In.Show();
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnservices_Click(object sender, EventArgs e)
        {
            manage_services manage_Services = new manage_services();
            manage_Services.Show();
            this.Hide();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {

            manage_employees manage_Employees = new manage_employees();
            manage_Employees.Show();
            this.Hide();
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            view_feedback view_Feedback = new view_feedback();
            view_Feedback.Show();
            this.Hide();
        }

        private void txtacc_Click(object sender, EventArgs e)
        {
           serviceManager_profile profile = new serviceManager_profile();
            profile.Show();
            this.Hide();
        }
    }
}
