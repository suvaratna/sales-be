using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Resources
{
    public class SaveSalesResource
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public IList<SalesItemResource> SalesItem { get; set; } = new List<SalesItemResource>();
    }

}
