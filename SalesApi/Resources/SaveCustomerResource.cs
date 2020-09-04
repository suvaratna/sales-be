using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Resources
{
    public class SaveCustomerResource
    {
        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}
