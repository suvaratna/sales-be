using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Services.Communication
{
    public class ProductListResponse : BaseResponse<IEnumerable<Product>>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="products">Saved product.</param>
        /// <returns>Response.</returns>
        public ProductListResponse(IEnumerable<Product> products) : base(products)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductListResponse(string message) : base(message)
        { }
    }
}
