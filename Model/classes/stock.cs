using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class stock
    {
        public int stockId {  get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
        public DateTime purchaseDate { get; set; }
        public int inventoryManagerId {  get; set; }


    }
}
