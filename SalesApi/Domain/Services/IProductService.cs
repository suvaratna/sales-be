using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface IProductService
    {
        Task<ProductListResponse> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
        Task<ProductResponse> FindByIdAsync(int id);
    }
}
