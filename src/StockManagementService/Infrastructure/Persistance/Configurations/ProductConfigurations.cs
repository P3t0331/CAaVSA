using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Product;
using StockManagement.Domain.Product.ValueObjects;

namespace StockManagement.Infrastructure.Persistance.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProduct(builder);
    }

    private void ConfigureProduct(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever()
            .HasConversion(
                product => product.Value,
                productValue => ProductId.Create(productValue)
            );

        builder.OwnsOne(p => p.Name);
        builder.OwnsOne(p => p.Description);
        builder.OwnsOne(p => p.Price);
        builder.OwnsOne(p => p.Sku);
    }
}
