using ETıcaretAPI.Application.Repositories;
using ETıcaretAPI.Domain.Entities;
using ETıcaretAPI.Persistance.Contexts;
using ETıcaretAPI.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETıcaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETıcaretAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
        }

        
    }
}
