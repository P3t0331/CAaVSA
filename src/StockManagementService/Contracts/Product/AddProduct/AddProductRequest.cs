namespace StockManagement.Contracts.Product.AddProduct;

public record AddProductRequest(string Name, string Description, decimal Price, string Sku);
