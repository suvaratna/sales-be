using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByUsernameAsync(string username);
        void Update(User user);
        void Remove(User user);

        //Task AddUserPasswordAsync(UserPassword password);
        //Task<UserPassword> FindUserPasswordByIdAsync(int userId);
        //void UpdateUserPassword(UserPassword userPassword);
        //Task<UserPassword> FindDuplicateUsername(string username);
        //Task<User> AddUserTransaction(int updatedBy, User user, UserPassword userPassword);
        //Task<User> FindByUsernameAsync(string username);
    }
}
