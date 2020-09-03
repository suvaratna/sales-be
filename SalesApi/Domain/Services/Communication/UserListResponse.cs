using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class UserListResponse : BaseResponse<IEnumerable<User>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="users">Saved users.</param>
        /// <returns>Response.</returns>
        public UserListResponse(IEnumerable<User> users) : base(users)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserListResponse(string message) : base(message)
        { }
    }
}
