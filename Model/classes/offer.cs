using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finals_UI.Model.classes
{
    internal class offer
    {
        public int offerId {  get; set; }   
        public string offerType { get; set; }
        public string offerDescription { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public float discount {  get; set; }    
    }
}
