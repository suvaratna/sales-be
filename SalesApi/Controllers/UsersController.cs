using AutoMapper;
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
    [Route("/api/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : BaseAuthController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all users.
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IActionResult> ListAsync()
        {
            var result = await _userService.ListAsync();
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(result.Resource);
            return Ok(resources);
        }

        /// <summary>
        /// Saves a new user.
        /// </summary>
        /// <param name="resource">User data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}
