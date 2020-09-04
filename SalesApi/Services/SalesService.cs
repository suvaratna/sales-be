using SalesApi.Adapter;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Communication;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IRequestContext _requestContext;

        public SalesService(ISalesRepository salesRepository, IRequestContext requestContext)
        {
            _salesRepository = salesRepository;
            _requestContext = requestContext;
        }
        public async Task<SalesResponse> SaveAsync(Sales sales)
        {
            try
            {
                sales.CreatedBy = _requestContext.UserId ?? 0;

                await _salesRepository.AddAsync(sales);
                return new SalesResponse(sales);
            }
            catch (Exception ex)
            {
                return new SalesResponse($"An error occurred when saving the Sales Transaction: {ex.Message}");
            }
        }

        public async Task<SalesResponse> DeleteAsync(int id)
        {
            try
            {
                var existingSales = await _salesRepository.FindByIdAsync(id);

                if (existingSales == null)
                    return new SalesResponse("Sales Transaction Not Found");

                existingSales.DeletedBy = _requestContext.UserId ?? 0;

                _salesRepository.Remove(existingSales);

                return new SalesResponse(existingSales);
            }
            catch (Exception ex)
            {
                return new SalesResponse($"An error occurred when deleting the Sales Transaction: {ex.Message}");
            }
        }

        public async Task<SalesResponse> FindByIdAsync(int id)
        {
            try
            {
                var existingSales = await _salesRepository.FindByIdAsync(id);

                if (existingSales == null)
                    return new SalesResponse("Sales Transaction not found");

                return new SalesResponse(existingSales);
            }
            catch (Exception ex)
            {

                return new SalesResponse($"An error occurred when finding the Sales Transaction: {ex.Message}");

            }
        }

        public async Task<SalesListResponse> ListAsync()
        {
            try
            {
                return new SalesListResponse(await _salesRepository.ListAsync());
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SalesListResponse($"An error occurred when fetching Sales List: {ex.Message}");
            }
        }
        

        public async Task<SalesResponse> UpdateAsync(int id, Sales sales)
        {
            try
            {
                var existingSales = await _salesRepository.FindByIdAsync(id);

                if (existingSales == null)
                    return new SalesResponse("Sales Record Not Found");

                existingSales.CustomerId = sales.CustomerId;
                existingSales.TotalAmount = sales.TotalAmount;
                existingSales.ModifiedBy = _requestContext.UserId ?? 0;
                existingSales.SalesItem = sales.SalesItem;

                _salesRepository.Update(existingSales);

                return new SalesResponse(existingSales);
            }
            catch (Exception ex)
            {
                return new SalesResponse($"An error occurred when updating the Sales Transaction: {ex.Message}");
            }
        }

        public async Task<SalesResponse> FindTransactionByIdAsync(int id)
        {
            try
            {
                var existingSales = await _salesRepository.FindTransactionByIdAsync(id);

                if (existingSales == null)
                    return new SalesResponse("Sales Transaction not found");

                return new SalesResponse(existingSales);
            }
            catch (Exception ex)
            {

                return new SalesResponse($"An error occurred when finding the Sales Transaction: {ex.Message}");

            }
        }
    }
}
