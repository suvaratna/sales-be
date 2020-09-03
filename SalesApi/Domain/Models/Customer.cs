using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class Customer : CommonData
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
