using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Extensions
{
    public static class EnumExtensions
    {

    }

    public enum PasswordFormat
    {
        /// <summary>
        /// Hashed
        /// </summary>
        Hashed = 0,

        /// <summary>
        /// Encrypted
        /// </summary>
        Encrypted = 1
    }
}
