using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class sale
    {
        public int saleId {  get; set; }
        public DateTime date {  get; set; }
        public string comment {  get; set; }
        public int quantity { get; set; }
        public string invoiceNo {  get; set; }
        public int customerId {  get; set; }
        public int itemId {  get; set; }
        public string plateNumber {  get; set; }
        public int operationalManagerId {  get; set; }
        public int saleItemId {  get; set; }    
    }
}
