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
    [Route("/api/customers")]
    [Produces("application/json")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all customers.
        /// </summary>
        /// <returns>List of customers.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerResource>), 200)]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _customerService.ListAsync();
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(result.Resource);
            return Ok(resources);
        }

        /// <summary>
        /// Saves a new customer.
        /// </summary>
        /// <param name="resource">Customer data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }

        /// <summary>
        /// Updates an existing customer according to an identifier.
        /// </summary>
        /// <param name="id">Customer identifier.</param>
        /// <param name="resource">Updated Customer data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResource resource)
        {
            var product = _mapper.Map<SaveCustomerResource, Customer>(resource);
            var result = await _customerService.UpdateAsync(id, product);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }

        /// <summary>
        /// Deletes a given customer according to an identifier.
        /// </summary>
        /// <param name="id">Customer identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _customerService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }

        /// <summary>
        /// Get a single customer according to an identifier
        /// </summary>
        /// <param name="id">Customer Identifier</param>
        /// <returns>single customer</returns>
        [ProducesResponseType(typeof(CustomerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.FindByIdAsync(id);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }
    }
}
