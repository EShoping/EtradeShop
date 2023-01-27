using ETıcaretAPI.Application.Repositories;
using ETıcaretAPI.Domain.Entities;
using ETıcaretAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETıcaretAPI.Persistance.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETıcaretAPIDbContext context) : base(context)
        {
        }
    }
}
