using Domain.Common.Models;

namespace StockManagement.Domain.Product.ValueObjects;

public class ProductDescription : ValueObject
{
    public string Value { get; private set; }

    private ProductDescription() { }

    public ProductDescription(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
