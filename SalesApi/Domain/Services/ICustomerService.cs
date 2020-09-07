using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface ICustomerService
    {
        Task<CustomerListResponse> ListAsync(bool isWithoutSales);
        Task<CustomerResponse> SaveAsync(Customer customer);
        Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        Task<CustomerResponse> DeleteAsync(int id);
        Task<CustomerResponse> FindByIdAsync(int id);
    }
}
