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

        public async Task<InvoiceItemResponse> GetBillDetails(int salesId)
        {
            try
            {
                var result = await _invoiceRepository.GetBillDetails(salesId);

                return new InvoiceItemResponse(result);
            }
            catch (Exception ex)
            {
                return new InvoiceItemResponse($"An error occurred when fetching invoice items: {ex.Message}");
            }
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
