using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceResponse> PayInvoice(Invoice invoice);

        Task<InvoiceItemResponse> GetBillDetails(int salesId);
    }
}
