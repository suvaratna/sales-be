using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user">Saved user.</param>
        /// <returns>Response.</returns>
        public UserResponse(User user) : base(user)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : base(message)
        { }
    }
}
