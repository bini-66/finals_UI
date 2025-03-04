using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class customerInvoice
    {
        public int customerInvoiceId {  get; set; }
        public string invoiceNo {  get; set; }  
        public DateTime date { get; set; }  
        public float invoiceTotal {  get; set; }   
        public int receptionistId {  get; set; }
        public int vehicleId { get; set; }
        public int customerId { get; set; }
        public int offerId {  get; set; }





    }
}
