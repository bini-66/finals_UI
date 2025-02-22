using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class maintenance
    {
        public int maintenanceId { get; set; }
        public string maintenanceStatus { get; set; }
        public string maintenanceDescription { get; set; }
        public int vehicleId { get; set; }
        public int serviceId { get; set; }
        public int customerInvoiceId { get; set; }
        public int employeeId { get; set; }
        public DateTime maintenanceDate { get; set; }
        public string selectedServices { get; set; }
    }
}
