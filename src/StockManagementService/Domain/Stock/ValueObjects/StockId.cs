using Domain.Common.Models;

namespace StockManagement.Domain.Stock.ValueObjects;

public class StockId : ValueObject
{
    public Guid Value { get; private set; }

    private StockId(Guid value)
    {
        Value = value;
    }

    public static StockId CreateUnique() => new StockId(Guid.NewGuid());
    public static StockId Create(Guid value) => new StockId(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
