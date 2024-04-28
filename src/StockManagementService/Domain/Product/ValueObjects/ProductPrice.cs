using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.Product.ValueObjects;

public class ProductPrice : ValueObject
{
    public decimal Value { get; private set; }

    private ProductPrice() { }

    public ProductPrice(decimal value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
