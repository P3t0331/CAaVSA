using Domain.Common.Models;
using StockManagement.Domain.Product.ValueObjects;
using StockManagement.Domain.Stock.ValueObjects;

namespace StockManagement.Domain.Stock;

public class Stock : AggregateRoot<StockId>
{
    public ProductId Product { get; private set; }
    public StockQuantity StockQuantity { get; private set; }

    private Stock() { }

    public Stock(StockId id, ProductId product, StockQuantity stockQuantity) : base(id)
    {
        Product = product;
        StockQuantity = stockQuantity;
    }
}
