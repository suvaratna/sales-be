using Dapper;
using Newtonsoft.Json;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Domain.Services.Communication;
using SalesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace SalesApi.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        public async Task<IEnumerable<Sales>> ListAsync()
        {
            using IDbConnection connection = DBManager.DbConnect();
            return await connection.QueryAsync<Sales>("[dbo].[GetAllSales]",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Sales> FindTransactionByIdAsync(int id)
        {
            var output = new Sales();

            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);

            var result = await connection.QueryMultipleAsync("[dbo].[GetSalesTransactionById]", param,
                commandType: CommandType.StoredProcedure, commandTimeout:500);

            output = await result.ReadFirstOrDefaultAsync<Sales>();
            output.SalesItem = (await result.ReadAsync<SalesItem>()).ToList();

            return output;
        }

        public async Task AddAsync(Sales sales)
        {
            using (IDbConnection connection = DBManager.DbConnect())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerId", sales.CustomerId);
                param.Add("@TotalAmount", sales.TotalAmount);
                param.Add("@IsPaid", sales.IsPaid);
                param.Add("@CreatedBy", sales.CreatedBy);
                param.Add("@Detailsjson", JsonConvert.SerializeObject(sales.SalesItem));

                await connection.ExecuteAsync("[dbo].[AddSalesTransaction]", param,
                    commandType: CommandType.StoredProcedure);
            }

        }

        public void Update(Sales sales)
        {
            using (IDbConnection connection = DBManager.DbConnect())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", sales.Id);
                param.Add("@CustomerId", sales.CustomerId);
                param.Add("@TotalAmount", sales.TotalAmount);
                param.Add("@ModifiedBy", 2);
                param.Add("@Detailsjson", JsonConvert.SerializeObject(sales.SalesItem));

                connection.Execute("[dbo].[UpdateSalesTransaction]", param,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public void Remove(Sales sales)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", sales.Id);
            param.Add("@DeletedBy", sales.DeletedBy);
            connection.Execute("[dbo].[DeleteSales]", param,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Sales> FindByIdAsync(int id)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return await connection.QueryFirstOrDefaultAsync<Sales>("[dbo].[GetSalesById]", param,
                commandType: CommandType.StoredProcedure);
        }
    }
}
