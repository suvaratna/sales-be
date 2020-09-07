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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IRequestContext _requestContext;

        public CustomerService(ICustomerRepository customerRepository, IRequestContext requestContext)
        {
            _customerRepository = customerRepository;
            _requestContext = requestContext;
        }
        public async Task<CustomerResponse> DeleteAsync(int id)
        {
            try
            {
                var existingCustomer = await _customerRepository.FindByIdAsync(id);

                if (existingCustomer == null)
                    return new CustomerResponse("Customer Not Found");

                existingCustomer.DeletedBy = _requestContext.UserId ?? 0;

                _customerRepository.Remove(existingCustomer);

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when deleting the Customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> FindByIdAsync(int id)
        {
            try
            {
                var existingCustomer = await _customerRepository.FindByIdAsync(id);

                if (existingCustomer == null)
                    return new CustomerResponse("Customer not found");

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {

                return new CustomerResponse($"An error occurred when finding the Customer: {ex.Message}");

            }
        }

        public async Task<CustomerListResponse> ListAsync(bool isWithoutSales)
        {
            try
            {
                return new CustomerListResponse(await _customerRepository.ListAsync(isWithoutSales));
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CustomerListResponse($"An error occurred when fetching Customer List: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> SaveAsync(Customer customer)
        {
            try
            {
                customer.CreatedBy = _requestContext.UserId ?? 0;

                await _customerRepository.AddAsync(customer);
                return new CustomerResponse(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when saving the Customer: {ex.Message}");
            }
        }

        public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
        {
            try
            {
                var existingCustomer = await _customerRepository.FindByIdAsync(id);

                if (existingCustomer == null)
                    return new CustomerResponse("Customer Not Found");

                existingCustomer.Firstname = customer.Firstname;
                existingCustomer.Lastname = customer.Lastname;
                existingCustomer.Address = customer.Address;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.ModifiedBy = _requestContext.UserId ?? 0;

                _customerRepository.Update(existingCustomer);

                return new CustomerResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse($"An error occurred when updating the Customer: {ex.Message}");
            }
        }
    }
}
