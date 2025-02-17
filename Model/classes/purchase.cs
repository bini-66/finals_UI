using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class purchase
    {
        public int stockId {  get; set; }
        public int purchaseId {  get; set; }    
        public int itemId { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public DateTime purchaseDate { get; set; }
        public string comment {  get; set; }    
        public int inventoryManagerId {  get; set; }
        public string supplierInvoiceNo {  get; set; }
        public int supplierId {  get; set; }


    }
}
