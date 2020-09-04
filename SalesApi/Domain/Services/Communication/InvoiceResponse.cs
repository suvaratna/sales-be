using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class InvoiceResponse : BaseResponse<Invoice>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="invoice">Saved invoice.</param>
        /// <returns>Response.</returns>
        public InvoiceResponse(Invoice invoice) : base(invoice)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public InvoiceResponse(string message) : base(message)
        { }
    }
}
