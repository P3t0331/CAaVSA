namespace StockManagement.Application.Product.AddProduct;

public record AddProductCommand(string Name, string Description, decimal Price, string Sku)
{
    public record Result(Guid Id, string Name, string Description, decimal Price, string Sku);
};
