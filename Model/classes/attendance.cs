using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finals_UI.Model.classes
{
    internal class attendance
    {
        public int attendanceId {  get; set; }
        public int employeeId {  get; set; }
        public string employeeName {  get; set; }
        public DateTime date { get; set; }  
        public string status {  get; set; }

        public attendance(int employeeId, DateTime date, string status)
        {
            this.employeeId = employeeId;
            this.date = date;
            this.status = status;
        }

    }
}
