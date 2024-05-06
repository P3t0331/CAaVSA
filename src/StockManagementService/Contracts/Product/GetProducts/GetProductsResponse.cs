namespace StockManagement.Contracts.Product.GetProducts;

public record GetProductsResponse(IEnumerable<Product> products);
