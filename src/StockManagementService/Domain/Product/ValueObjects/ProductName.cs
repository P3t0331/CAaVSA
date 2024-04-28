using Domain.Common.Models;

namespace StockManagement.Domain.Product.ValueObjects;

public class ProductName : ValueObject
{
    public string Value { get; private set; }

    private ProductName() { }

    public ProductName(string name)
    {
        Value = name;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
