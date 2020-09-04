using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="customer">Saved customer.</param>
        /// <returns>Response.</returns>
        public CustomerResponse(Customer customer) : base(customer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CustomerResponse(string message) : base(message)
        { }
    }
}
