using AutoMapper;
using SalesApi.Domain.Models;
using SalesApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<User, UserResource>();
            CreateMap<Customer, CustomerResource>();
            CreateMap<Sales, SalesResource>();
            CreateMap<SalesItem, SalesItemResource>();
            CreateMap<Invoice, InvoiceResource>();
        }
    }
}
