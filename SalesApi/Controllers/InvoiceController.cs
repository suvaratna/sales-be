using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Domain.Models;
using SalesApi.Domain.Services;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Controllers
{
    [Route("/api/invoices")]
    [Produces("application/json")]
    [ApiController]
    public class InvoiceController : BaseAuthController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        /// <summary>
        /// Saves a new invoice.
        /// </summary>
        /// <param name="resource">Invoice data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(InvoiceResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveInvoiceResource resource)
        {
            var invoice = _mapper.Map<SaveInvoiceResource, Invoice>(resource);

            var result = await _invoiceService.PayInvoice(invoice);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var invoiceResource = _mapper.Map<Invoice, InvoiceResource>(result.Resource);
            return Ok(invoiceResource);
        }

        /// <summary>
        /// Get a single Bill according to an identifier
        /// </summary>
        /// <param name="id">Bill Identifier</param>
        /// <returns>single bill info</returns>
        [ProducesResponseType(typeof(BillItem), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            var result = await _invoiceService.GetBillDetails(id);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            return Ok(result.Resource);
        }
    }
}
