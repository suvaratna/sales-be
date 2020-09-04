using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class SalesResponse : BaseResponse<Sales>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="sale">Saved sale.</param>
        /// <returns>Response.</returns>
        public SalesResponse(Sales sale) : base(sale)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SalesResponse(string message) : base(message)
        { }
    }
}
