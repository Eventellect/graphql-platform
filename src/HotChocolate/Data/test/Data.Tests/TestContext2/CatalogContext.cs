using HotChocolate.Data.TestContext2.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HotChocolate.Data.TestContext2;

public class CatalogContext(string connectionString) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }

    public DbSet<Product> Products { get; set; } = default!;

    public DbSet<ProductType> ProductTypes { get; set; } = default!;

    public DbSet<Brand> Brands { get; set; } = default!;

    public DbSet<Test> Tests { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BrandEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductTypeEntityTypeConfiguration());
        builder.ApplyConfiguration(new ProductEntityTypeConfiguration());

        // Add the outbox table to this context
        // builder.UseIntegrationEventLogs();
    }
}
