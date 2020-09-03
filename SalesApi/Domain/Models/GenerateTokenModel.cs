using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class GenerateTokenModel
    {
        public string Token { get; set; }
        public DateTime TokenExpireOn { get; set; }
        public string RefreshToken { get; set; }
    }
}
