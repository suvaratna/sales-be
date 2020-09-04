using Dapper;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task AddAsync(Customer customer)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Firstname", customer.Firstname);
            param.Add("@Lastname", customer.Lastname);
            param.Add("@Address", customer.Address);
            param.Add("@PhoneNumber", customer.PhoneNumber);
            param.Add("@CreatedBy", customer.CreatedBy);
            await connection.ExecuteAsync("[dbo].[AddCustomer]", param,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Customer> FindByIdAsync(int id)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return await connection.QueryFirstOrDefaultAsync<Customer>("[dbo].[GetCustomerById]", param,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            using IDbConnection connection = DBManager.DbConnect();
            return await connection.QueryAsync<Customer>("[dbo].[GetAllCustomers]",
                commandType: CommandType.StoredProcedure);
        }

        public void Remove(Customer product)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", product.Id);
            param.Add("@DeletedBy", product.DeletedBy);
            connection.Execute("[dbo].[DeleteCustomer]", param,
                commandType: CommandType.StoredProcedure);
        }

        public void Update(Customer customer)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", customer.Id);
            param.Add("@Firstname", customer.Firstname);
            param.Add("@Lastname", customer.Lastname);
            param.Add("@Address", customer.Address);
            param.Add("@PhoneNumber", customer.PhoneNumber);
            param.Add("@ModifiedBy", customer.ModifiedBy);
            connection.Execute("[dbo].[UpdateCustomer]", param,
                commandType: CommandType.StoredProcedure);
        }
    }
}
