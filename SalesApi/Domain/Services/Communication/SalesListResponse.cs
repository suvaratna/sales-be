using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Resources
{
    public class SalesListResponse : BaseResponse<IEnumerable<Sales>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="sales">Saved sales.</param>
        /// <returns>Response.</returns>
        public SalesListResponse(IEnumerable<Sales> sales) : base(sales)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SalesListResponse(string message) : base(message)
        { }
    }
}
