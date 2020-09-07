using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SalesApi.Helpers
{
    public static class DBManager
    {
        public static IDbConnection DbConnect()
        {
            IDbConnection connection = new SqlConnection(GetConnectionStrings());
            return connection;
        }

        public static string GetConnectionName()
        {
            return "SalesDB";
        }

        public static string GetConnectionStrings()
        {
            //return ConfigurationManager.ConnectionStrings["SalesDB"].ConnectionString;
            return "Server=DESKTOP-19QM68S\\SQLEXPRESS;Initial Catalog=SalesTransactionDb;User ID=suva;Password=suva;";
        }

    }
}
