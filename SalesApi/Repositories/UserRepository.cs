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
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> ListAsync()
        {
            using IDbConnection connection = DBManager.DbConnect();
            return await connection.QueryAsync<User>("[dbo].[GetAllUsers]", commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(User user)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Username", user.Username);
            param.Add("@RoleId", user.RoleId);
            param.Add("@IsSystemAccount", user.IsSystemAccount);
            await connection.ExecuteAsync("[dbo].[AddUser]", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            using IDbConnection connection = DBManager.DbConnect();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Username", username);
            return await connection.QueryFirstOrDefaultAsync<User>("[dbo].[GetUserByUsername]", param, commandType: CommandType.StoredProcedure);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User user)
        {
            throw new NotImplementedException();
        }

        
    }
}
