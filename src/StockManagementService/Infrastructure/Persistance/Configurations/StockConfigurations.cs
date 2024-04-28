using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Stock;
using StockManagement.Domain.Stock.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Infrastructure.Persistance.Configurations;

public class StockConfigurations : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        ConfigureStock(builder);
    }

    private void ConfigureStock(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .HasConversion(
                stock => stock.Value,
                stockValue => StockId.Create(stockValue)
            );

        builder.OwnsOne(s => s.Product);
        builder.OwnsOne(s => s.StockQuantity);
    }
}
