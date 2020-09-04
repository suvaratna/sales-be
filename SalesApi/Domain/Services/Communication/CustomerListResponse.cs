using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class CustomerListResponse : BaseResponse<IEnumerable<Customer>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="customers">Saved customers.</param>
        /// <returns>Response.</returns>
        public CustomerListResponse(IEnumerable<Customer> customers) : base(customers)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CustomerListResponse(string message) : base(message)
        { }
    }
}
