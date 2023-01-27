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
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETıcaretAPIDbContext context) : base(context)
        {
        }
    }
}
