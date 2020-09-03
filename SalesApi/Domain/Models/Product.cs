using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class Product : CommonData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}
