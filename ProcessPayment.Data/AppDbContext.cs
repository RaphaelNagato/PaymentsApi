using Microsoft.EntityFrameworkCore;
using ProcessPayment.Models;
using System.Linq;
using System.Reflection;

namespace ProcessPayment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // change decimal type to double when using sqlite
            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite") {
                foreach (var entityType in builder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(
                        p => p.PropertyType == typeof(decimal)
                    );

                    foreach (var property in properties)
                    {
                        builder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }
                }
            }
        }
        public DbSet<Payment> Payments {get; set;}
    }
}
