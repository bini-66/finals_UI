using finals_UI.Model.classes;
using finals_UI.Model.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finals_UI.Controller
{
    internal class attendanceController
    {

        public DataSet loadEmployeeInfo()
        {
            //connection class
            dbConnection con=new dbConnection();
            con.openConnection();

            //command class
            string query = "SELECT employeeId,firstName FROM employee";
            MySqlCommand com=new MySqlCommand(query,con.getConnection());

            //data adapter class
            MySqlDataAdapter DAP = new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);

            return ds;
        }

        public DataSet loadAttendanceStatus(DateTime date)
        {
            //connection class
            dbConnection con= new dbConnection();   
            con.openConnection();

            //command class
            string query = "SELECT employeeId,attendanceStatus FROM attendance WHERE date=@date  ";
            MySqlCommand com=new MySqlCommand( query,con.getConnection());

            com.Parameters.AddWithValue("@date",date);
            //data adapter class
            MySqlDataAdapter DAP= new MySqlDataAdapter(com);
            DataSet ds = new DataSet();
            DAP.Fill(ds);
            return ds;
        }
        public void saveAttendance(List<attendance> records)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
 

            string query = "INSERT INTO attendance (employeeId, date, attendanceStatus) VALUES (@employeeId, @date, @status)";

            foreach (var record in records)
            {
                string status = string.IsNullOrEmpty(record.status) ? "absent" : record.status;

                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@employeeId", record.employeeId);
                com.Parameters.AddWithValue("@date", record.date.ToString("yyyy-MM-dd"));
                com.Parameters.AddWithValue("@status", status);

                com.ExecuteNonQuery();
            }

            MessageBox.Show("Attendance records inserted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void updateAttendance(List<attendance> records)
        {
            //connection class
            dbConnection con = new dbConnection();
            con.openConnection();

            //command class
            string query = "UPDATE attendance SET attendanceStatus=@status WHERE employeeId=@employeeId AND date=@date";
            foreach (var record in records)
            {
                string status = string.IsNullOrEmpty(record.status) ? "absent" : record.status;

                MySqlCommand com = new MySqlCommand(query, con.getConnection());
                com.Parameters.AddWithValue("@status", status);
                com.Parameters.AddWithValue("@employeeId", record.employeeId);
                com.Parameters.AddWithValue("@date", record.date.ToString("yyyy-MM-dd"));
              

                com.ExecuteNonQuery();
            }

            MessageBox.Show("Attendance record(s) updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        //public DataSet loadSearchResults(string empInfo,DateTime date)
        //{
        //    //connection class
        //    dbConnection con = new dbConnection();
        //    con.openConnection();

        //    //command class
        //    string query = "SELECT attendance.employeeId,employee.firstName,date, attendanceStatus FROM employee INNER JOIN attendance ON employee.employeeId=attendance.employeeId WHERE (firstName LIKE @firstName OR employee.employeeId=@employeeId OR lastName LIKE @lastName) AND date=@date";
        //    MySqlCommand com = new MySqlCommand(query, con.getConnection());

        //    com.Parameters.AddWithValue("@firstName", empInfo + "%");
        //    com.Parameters.AddWithValue("@lastName",  empInfo + "%");
        //    com.Parameters.AddWithValue("@employeeId", empInfo);
        //    com.Parameters.AddWithValue("@date", date);



        //    //data adapter class
        //    MySqlDataAdapter DAP = new MySqlDataAdapter(com);
        //    DataSet ds = new DataSet();

        //    DAP.Fill(ds);

        //    return ds;

        //}

    }

        
    }

