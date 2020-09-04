using SalesApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Task PayInvoice(Invoice invoice);
    }
}
