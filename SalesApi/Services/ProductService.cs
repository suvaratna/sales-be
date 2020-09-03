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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IRequestContext _requestContext;

        public ProductService(IProductRepository productRepository, IRequestContext requestContext)
        {
            _productRepository = productRepository;
            _requestContext = requestContext;
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                return new ProductListResponse(await _productRepository.ListAsync());
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductListResponse($"An error occurred when fetching Product List: {ex.Message}");
            }

        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {  
            try
            {
                product.CreatedBy = _requestContext.UserId ?? 0;

                await _productRepository.AddAsync(product);
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error occurred when saving the Product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
            try
            {
                var existingProduct = await _productRepository.FindByIdAsync(id);

                if (existingProduct == null)
                    return new ProductResponse("Product Not Found");

                existingProduct.Name = product.Name;
                existingProduct.Rate = product.Rate;
                existingProduct.ModifiedBy = _requestContext.UserId ?? 0;
                
                _productRepository.Update(existingProduct);

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error occurred when updating the Product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            try
            {
                var existingProduct = await _productRepository.FindByIdAsync(id);

                if (existingProduct == null)
                    return new ProductResponse("Product Not Found");

                existingProduct.DeletedBy = _requestContext.UserId ?? 0;

                _productRepository.Remove(existingProduct);

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error occurred when deleting the Product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> FindByIdAsync(int id)
        {
            try
            {
                var existingProduct = await _productRepository.FindByIdAsync(id);

                if (existingProduct == null)
                    return new ProductResponse("Product not found");

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {

                return new ProductResponse($"An error occurred when finding the Product: {ex.Message}");

            }

        }
    }
}
