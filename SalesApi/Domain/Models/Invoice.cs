using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class Invoice : CommonData
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
    }
}
