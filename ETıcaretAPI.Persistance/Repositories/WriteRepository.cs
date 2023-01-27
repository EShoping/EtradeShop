using ETıcaretAPI.Application.Repositories;
using ETıcaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETıcaretAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => throw new NotImplementedException();

        public Task<bool> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(List<T> model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
