namespace StockManagement.Contracts.Messages;

public record OrderCreatedMessage(Guid OrderId, IEnumerable<ProductItem> Products);

public record ProductItem(Guid ProductId, int Quantity);
