using Microsoft.EntityFrameworkCore;
using RabbitMqDemo.Core.Utilities.Configuration;
using RabbitMqDemo.Entities.Concrete;

namespace RabbitMqDemo.DataAccess.Concrete.EntityFramework.Contexts
{
    public class RabbitMqDemoContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CoreConfig.GetConnectionString("Default"));
        }
    }
}
