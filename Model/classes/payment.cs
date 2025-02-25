using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class payment
    {
        public int paymentId { get; set; }
        public float paidAmount {  get; set; }
        public string paymentMethod { get; set; } 
        public float invoiceTotal {  get; set; }    
        public int customerInvoiceId {  get; set; }
        public int vehicleId {  get; set; } 
        public int receiptId {  get; set; }
        public int offerId {  get; set; }   

    }
}
