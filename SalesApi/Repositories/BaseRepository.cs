using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectionString = "Server=DESKTOP-19QM68S\\SQLEXPRESS;Initial Catalog=SalesTransactionDb;User ID=suva;Password=suva;";
            con = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            con.Close();
        }
    }
}
