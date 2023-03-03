using ETıcaretAPI.Domain.Entities;
using ETıcaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETıcaretAPI.Persistance.Contexts
{
    
    public class ETıcaretAPIDbContext : DbContext
    {
        public ETıcaretAPIDbContext(DbContextOptions options) : base(options)
        {
           // DbContextOptionsBuilder<ETıcaretAPIDbContext> dbContextOptionsBuilder = new();
           // dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ETıcaretAPIDb;Integrated Security=true");
           //// return new ETıcaretAPIDbContext(dbContextOptionsBuilder.Options);
        }

        
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Track edilen verileri yakalayıp elde etmenizi sağlar.

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                   
                };//_ yazma nedeni: Burada istenilen data üzerinde işlem yapılmayacağı için herhangi bir değişkene atamaya gerek yok
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
