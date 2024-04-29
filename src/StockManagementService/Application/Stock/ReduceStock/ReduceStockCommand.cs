namespace StockManagement.Application.Stock.ReduceStock;

public record ReduceStockCommand(IEnumerable<(Guid ProductId, int Quantity)> Products);
