using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SalesApi.Adapter;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Communication;
using SalesApi.Helpers;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private readonly IRequestContext _requestContext;

        public UserService(IUserRepository userRepository, 
            IOptions<AppSettings> appSetting, IRequestContext requestContext)
        {
            _userRepository = userRepository;
            _appSettings = appSetting.Value;
            _requestContext = requestContext;
        }
        public async Task<UserListResponse> ListAsync()
        {
            try
            {
                return new UserListResponse(await _userRepository.ListAsync());
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new UserListResponse($"An error occurred when fetching User List: {ex.Message}");
            }
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when saving the User: {ex.Message}");
            }
        }

        public async Task<UserResponse> FindByUsernameAsync(string username)
        {
            try
            {
                var existingUser = await _userRepository.FindByUsernameAsync(username);

                if (existingUser == null)
                    return new UserResponse("User not found");

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {

                return new UserResponse($"An error occurred when finding the User: {ex.Message}");

            }
        }

        public async Task<GenerateTokenModel> GenerateTokenString(User user)
        {
            try
            {
                var model = new GenerateTokenModel();

                var accessTokinMin = 240;
                var expire = DateTime.UtcNow.AddMinutes(accessTokinMin);

                model.TokenExpireOn = expire;
                var userName = user.Username;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.RoleName)
                    }),
                    Expires = expire,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                model.Token = tokenString;
                
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UserResponse> UserAuthenticate(AuthenticateResource resource)
        {
            try
            {
                var existingUser = await _userRepository.FindByUsernameAsync(resource.UserName);
                if (existingUser == null)
                    return new UserResponse($"User Not Found!");

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when finding the User: {ex.Message}");
            }
            


        }
    }
}
