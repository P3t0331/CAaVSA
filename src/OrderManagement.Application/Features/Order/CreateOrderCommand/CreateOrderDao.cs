using Dapper;
using OrderManagement.Core.Attributes;
using OrderManagement.Core.Database;
using static OrderManagement.Application.Features.Order.CreateOrderCommand.ICreateOrderDao;

namespace OrderManagement.Application.Features.Order.CreateOrderCommand;

public interface ICreateOrderDao
{
    Task AddOrderItems(Guid orderId, List<OrderItem> orderItems);
    Task<Guid> CreateOrder(Guid customerId, DateTime orderDate, decimal totalAmount);

    public record OrderItem
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}

[Register<ICreateOrderDao>]
public class CreateOrderDao : ICreateOrderDao
{
    private readonly IDataContext _context;

    public CreateOrderDao(IDataContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateOrder(Guid customer, DateTime orderDate, decimal totalAmount)
    {
        var id = Guid.NewGuid();
        var customerId = customer.ToString();

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(@"
            INSERT INTO Orders (Id, CustomerId, OrderDate, TotalAmount) VALUES (@id, @customerId, @orderDate, @totalAmount)
        ", new { id, customerId, orderDate, totalAmount });

        return id;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItems()
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<OrderItem>(@"Select * from OrderItem");
    }

    public async Task AddOrderItems(Guid orderId, List<OrderItem> orderItems)
    {
        foreach (var item in orderItems)
        {
            var id = Guid.NewGuid();
            var quantity = item.Quantity;
            var productId = item.ProductId;
            var currentPrice = item.CurrentPrice;

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(@"
                INSERT INTO OrderItem (Id, OrderId, ProductId, Quantity, CurrentPrice) VALUES (@id, @orderId, @productId, @quantity, @currentPrice)
            ", new { id, orderId, productId, quantity, currentPrice });
        }
    }
}
