using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SalesApi.Adapter
{
    public interface IRequestContext
    {
        int? UserId { get; }
    }

    public sealed class RequestContextAdapter : IRequestContext
    {
        private readonly IHttpContextAccessor _accessor;
        public RequestContextAdapter(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }

        public int? UserId
        {
            get
            {
                if (this._accessor.HttpContext.User == null) return null;
                var currentUser = this._accessor.HttpContext.User;
                var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier);
                if (currentUserId != null && !string.IsNullOrEmpty(currentUserId.Value))
                {
                    return Convert.ToInt32(currentUserId.Value);
                }
                return null;
            }
        }
    }
}
