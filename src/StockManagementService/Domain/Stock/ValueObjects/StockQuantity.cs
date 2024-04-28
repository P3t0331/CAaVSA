using Domain.Common.Models;

namespace StockManagement.Domain.Stock.ValueObjects;

public class StockQuantity : ValueObject
{
    public string Value { get; private set; }

    private StockQuantity() { }

    public StockQuantity(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
