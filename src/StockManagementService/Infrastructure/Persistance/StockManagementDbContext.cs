using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Product;
using StockManagement.Domain.Stock;
using System.Reflection;

namespace StockManagement.Infrastructure.Persistance;

public class StockManagementDbContext : DbContext
{
    public StockManagementDbContext() { }

    public StockManagementDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
