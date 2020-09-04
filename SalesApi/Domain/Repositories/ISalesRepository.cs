using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Repositories
{
    public interface ISalesRepository
    {
        Task<IEnumerable<Sales>> ListAsync();
        Task AddAsync(Sales sales);
        Task<Sales> FindTransactionByIdAsync(int id);
        Task<Sales> FindByIdAsync(int id);
        void Update(Sales sales);
        void Remove(Sales sales);
    }
}
