using finals_UI.Controller;
using finals_UI.Model.classes;
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
            // Set the current date as the selected date 
            monthCalendar1.SelectionStart = DateTime.Today;

            // Manually call the method to load attendance status for today's date
            monthCalendar1_DateSelected(monthCalendar1, new DateRangeEventArgs(DateTime.Now, DateTime.Now));

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
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
        //save button
        private void button8_Click(object sender, EventArgs e)
        {
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
                attendanceController.saveAttendance(records);
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
    }
}
