using System.Reflection;

using Microsoft.EntityFrameworkCore;

using Syslog.Data.Mapping;
using Syslog.Domain.Entities;

namespace Syslog.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }

        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new DeliveryMap());
            modelBuilder.ApplyConfiguration(new DeliveryEventMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}