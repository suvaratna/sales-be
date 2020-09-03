using Microsoft.AspNetCore.Mvc;
using SalesApi.Domain.Models;
using SalesApi.Domain.Services;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Controllers
{
    [Route("/api/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("UserAuthenticate")]
        public async Task<IActionResult> UserAuthenticate(AuthenticateResource resource)
        {
            var result = await _userService.UserAuthenticate(resource);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var data = await GenerateTokenRequest(result.Resource);
            return Ok(new ResponseResource<object>(data, result.Message, result.Success));
        }

        private async Task<object> GenerateTokenRequest(User user)
        {
            var token = await _userService.GenerateTokenString(user);
            object data = new
            {
                user.Id,
                Username = user.Username,
                RoleName = user.RoleName,
                user.RoleId,
                Token = token.Token,
                TokeExpireOn = token.TokenExpireOn
                //RefreshToken = token.RefreshToken,
            };
            return data;
        }
    }
}
