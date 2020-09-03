using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
    }
}
