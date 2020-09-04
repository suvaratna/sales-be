using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalesApi.Domain.Models;
using SalesApi.Domain.Services;
using SalesApi.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesApi.Controllers
{
    [Route("/api/sales")]
    [Produces("application/json")]
    [ApiController]
    public class SalesController : BaseAuthController
    {
        private readonly ISalesService _salesService;
        private readonly IMapper _mapper;

        public SalesController(ISalesService salesService, IMapper mapper)
        {
            _salesService = salesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all sales Transactions.
        /// </summary>
        /// <returns>List of sales Transactions.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SalesResource>), 200)]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _salesService.ListAsync();
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var resources = _mapper.Map<IEnumerable<Sales>, IEnumerable<SalesResource>>(result.Resource);
            return Ok(resources);
        }

        /// <summary>
        /// Saves a new sales transaction.
        /// </summary>
        /// <param name="resource">Sales Transaction data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(SalesResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSalesResource resource)
        {
            var sales = _mapper.Map<SaveSalesResource, Sales>(resource);

            var result = await _salesService.SaveAsync(sales);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var salesResource = _mapper.Map<Sales, SalesResource>(result.Resource);
            return Ok(salesResource);
        }

        /// <summary>
        /// Updates an existing Sales Transaction according to an identifier.
        /// </summary>
        /// <param name="id">Sales identifier.</param>
        /// <param name="resource">Updated Sales data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSalesResource resource)
        {
            var sales = _mapper.Map<SaveSalesResource, Sales>(resource);
            var result = await _salesService.UpdateAsync(id, sales);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var salesResource = _mapper.Map<Sales, SalesResource>(result.Resource);
            return Ok(salesResource);
        }

        /// <summary>
        /// Deletes a given Sales according to an identifier.
        /// </summary>
        /// <param name="id">Sales identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SalesResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _salesService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var salesResource = _mapper.Map<Sales, SalesResource>(result.Resource);
            return Ok(salesResource);
        }

        /// <summary>
        /// Get a single sales according to an identifier
        /// </summary>
        /// <param name="id">Sales Identifier</param>
        /// <returns>single sales</returns>
        [ProducesResponseType(typeof(SalesResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _salesService.FindTransactionByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var salesResource = _mapper.Map<Sales, SalesResource>(result.Resource);
            return Ok(salesResource);
        }
    }
}
