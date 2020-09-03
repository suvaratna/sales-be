using SalesApi.Domain.Models;
using SalesApi.Domain.Services.Communication;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services
{
    public interface IUserService
    {
        Task<UserListResponse> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        //Task<UserResponse> UserAuthenticate(AuthenticateResource resource);
        Task<GenerateTokenModel> GenerateTokenString(User user);
        Task<UserResponse> FindByUsernameAsync(string username);
        Task<UserResponse> UserAuthenticate(AuthenticateResource resource);
    }
}
