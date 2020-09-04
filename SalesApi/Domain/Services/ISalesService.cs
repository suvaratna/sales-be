using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface ISalesService
    {
        Task<SalesListResponse> ListAsync();
        Task<SalesResponse> SaveAsync(Sales sales);
        Task<SalesResponse> UpdateAsync(int id, Sales sales);
        Task<SalesResponse> DeleteAsync(int id);
        Task<SalesResponse> FindByIdAsync(int id);

        Task<SalesResponse> FindTransactionByIdAsync(int id);
    }
}
