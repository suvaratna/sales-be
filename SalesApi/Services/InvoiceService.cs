using SalesApi.Adapter;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IRequestContext _requestContext;

        public InvoiceService(IInvoiceRepository invoiceRepository, IRequestContext requestContext)
        {
            _invoiceRepository = invoiceRepository;
            _requestContext = requestContext;
        }
        public async Task<InvoiceResponse> PayInvoice(Invoice invoice)
        {
            try
            {
                invoice.CreatedBy = _requestContext.UserId ?? 0;

                await _invoiceRepository.PayInvoice(invoice);

                return new InvoiceResponse(invoice);
            }
            catch (Exception ex)
            {
                return new InvoiceResponse($"An error occurred when saving the Invoice: {ex.Message}");
            }
        }
    }
}
