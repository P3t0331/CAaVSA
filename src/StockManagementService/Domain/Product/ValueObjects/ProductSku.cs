using Domain.Common.Models;

namespace StockManagement.Domain.Product.ValueObjects;

public class ProductSku : ValueObject
{
    public string Value { get; private set; }

    private ProductSku() { }

    public ProductSku(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
