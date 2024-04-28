namespace StockManagement.Contracts.Product.AddProduct;

public record AddProductResponse(Guid Id, string Name, string Description, decimal Price, string Sku);
