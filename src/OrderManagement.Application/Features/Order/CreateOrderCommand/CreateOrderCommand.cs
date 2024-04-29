using static OrderManagement.Application.Features.Order.CreateOrderCommand.CreateOrderCommand;
using static OrderManagement.Application.Features.Order.CreateOrderCommand.ICreateOrderDao;

namespace OrderManagement.Application.Features.Order.CreateOrderCommand;

public record CreateOrderCommand(Guid CustomerId, DateTime OrderDate, List<OrderItem> OrderItems)
{
    public record Result();
}

public class CreateOrderCommandHandler
{
    private readonly ICreateOrderDao _dao;

    public CreateOrderCommandHandler(ICreateOrderDao dao)
    {
        _dao = dao;
    }

    public async Task Handle(CreateOrderCommand command, CancellationToken CancellationToken)
    {
        decimal totalSum = command.OrderItems.Sum(item => item.CurrentPrice * item.Quantity);

        var orderId = await _dao.CreateOrder(command.CustomerId, command.OrderDate, totalSum);

        await _dao.AddOrderItems(orderId, command.OrderItems);
    }
}
