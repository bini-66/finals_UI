using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class appointment
    {
        public int appointmentId { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }
        public string appointmentStatus { get; set; }
        public int plateNumber { get; set; }
        public string description { get; set; }
    }
}
