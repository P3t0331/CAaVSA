using Domain.Common.Models;
using StockManagement.Domain.Product.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.Product;

public sealed class Product : AggregateRoot<ProductId>
{
    public ProductName Name { get; private set; }
    public ProductDescription Description { get; private set; }
    public ProductPrice Price { get; private set; }
    public ProductSku Sku { get; private set; }

    private Product() { }

    public Product(ProductId id, ProductName name, ProductDescription description, ProductPrice price, ProductSku sku) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        Sku = sku;
    }
}
