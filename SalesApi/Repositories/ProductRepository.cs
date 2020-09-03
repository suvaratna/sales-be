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
    //public class ProductRepository : BaseRepository, IProductRepository
    //{
    //    public IEnumerable<Product> ListAsync()
    //    {
    //        return SqlMapper.Query<Product>(con, "GetAllProducts", commandType: CommandType.StoredProcedure);
    //    }

    //    public Task AddAsync(Product product)
    //    {
    //        throw new NotImplementedException();
    //        //DynamicParameters parameters = new DynamicParameters();
    //        //con.Open();
    //        //parameters.Add("EmpName", objEmp.EmpName);
    //        //parameters.Add("EmpAddress", objEmp.EmpAddress);
    //        //parameters.Add("EmailId", objEmp.EmailId);
    //        //parameters.Add("MobileNum", objEmp.MobileNum);
    //        //await SqlMapper.Execute(con, "AddEmp", param: parameters, commandType: CommandType.StoredProcedure);
    //    }

    //    public Task<Product> FindByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }



    //    public void Remove(Product product)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Product product)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> ListAsync()
        {
            using IDbConnection connection = DBManager.DbConnect();
            return await connection.QueryAsync<Product>("[dbo].[GetAllProducts]", commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(Product product)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", product.Name);
            param.Add("@Rate", product.Rate);
            param.Add("@CreatedBy", product.CreatedBy);
            await connection.ExecuteAsync("[dbo].[AddProduct]", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);
            return await connection.QueryFirstOrDefaultAsync<Product>("[dbo].[GetProductById]", param, commandType: CommandType.StoredProcedure);
        }

        public void Update(Product product)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", product.Id);
            param.Add("@Name", product.Name);
            param.Add("@Rate", product.Rate);
            param.Add("@ModifiedBy", product.ModifiedBy);
            connection.Execute("[dbo].[Updateproduct]", param, commandType: CommandType.StoredProcedure);
        }

        public void Remove(Product product)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", product.Id);
            param.Add("@DeletedBy", product.DeletedBy);
            connection.Execute("[dbo].[Deleteproduct]", param, commandType: CommandType.StoredProcedure);
        }
    }
}
