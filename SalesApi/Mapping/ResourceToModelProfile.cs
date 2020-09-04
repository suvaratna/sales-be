using AutoMapper;
using SalesApi.Domain.Models;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCustomerResource, Customer>();

            CreateMap<SaveSalesResource, Sales>();
            CreateMap<SalesItemResource, SalesItem>();

            CreateMap<SaveInvoiceResource, Invoice>();

        }

    }
}
