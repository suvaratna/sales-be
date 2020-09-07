using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public class InvoiceItemResponse : BaseResponse<IEnumerable<BillItem>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="invoiceitems">Saved invoice items.</param>
        /// <returns>Response.</returns>
        public InvoiceItemResponse(IEnumerable<BillItem> invoiceitems) : base(invoiceitems)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public InvoiceItemResponse(string message) : base(message)
        { }
    }
}
