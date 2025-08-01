using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM
{
    public class DefaultContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.SaleNumber).IsRequired();
                entity.Property(x => x.Date).IsRequired();
                entity.Property(x => x.CustomerId).IsRequired();
                entity.Property(x => x.CustomerName).IsRequired();
                entity.Property(x => x.BranchId).IsRequired();
                entity.Property(x => x.BranchName).IsRequired();
                entity.Property(x => x.IsCancelled).IsRequired();
                entity.HasMany(x => x.Items)
                      .WithOne(i => i.Sale)
                      .HasForeignKey(i => i.SaleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ProductId).IsRequired();
                entity.Property(x => x.ProductName).IsRequired();
                entity.Property(x => x.Quantity).IsRequired();
                entity.Property(x => x.UnitPrice).IsRequired();
                entity.Property(x => x.Discount).IsRequired();
                entity.Ignore(x => x.Total);
            });
        }
    }

    public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DefaultContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
            );

            return new DefaultContext(builder.Options);
        }
    }
}