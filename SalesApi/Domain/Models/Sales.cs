using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class Sales : CommonData
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public IList<SalesItem> SalesItem { get; set; } = new List<SalesItem>();
    }
}
