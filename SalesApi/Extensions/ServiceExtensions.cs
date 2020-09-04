using Microsoft.Extensions.DependencyInjection;
using SalesApi.Domain.Repositories;
using SalesApi.Domain.Services;
using SalesApi.Repositories;
using SalesApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        }

        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
        }
    }
}
