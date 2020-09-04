using Dapper;
using SalesApi.Domain.Models;
using SalesApi.Domain.Repositories;
using SalesApi.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public async Task PayInvoice(Invoice invoice)
        {
            using (IDbConnection connection = DBManager.DbConnect())
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@SalesId", invoice.SalesId);
                param.Add("@CreatedBy", invoice.CreatedBy);
                await connection.ExecuteAsync("[dbo].[PayInvoice]", param,
                    commandType: CommandType.StoredProcedure);
            }
            
        }
    }
}
