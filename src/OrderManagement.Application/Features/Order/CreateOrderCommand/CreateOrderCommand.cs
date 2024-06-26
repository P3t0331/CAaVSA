﻿using StockManagement.Contracts.Messages;
using Wolverine;
using static OrderManagement.Application.Features.Order.CreateOrderCommand.ICreateOrderDao;

namespace OrderManagement.Application.Features.Order.CreateOrderCommand;

public record CreateOrderCommand(Guid CustomerId, DateTime OrderDate, List<OrderItem> OrderItems)
{
    public record Result();
}

public class CreateOrderCommandHandler
{
    private readonly ICreateOrderDao _dao;
    private readonly IMessageBus _sender;

    public CreateOrderCommandHandler(ICreateOrderDao dao, IMessageBus sender)
    {
        _dao = dao;
        _sender = sender;
    }

    public async Task Handle(CreateOrderCommand command, CancellationToken CancellationToken)
    {
        decimal totalSum = command.OrderItems.Sum(item => item.CurrentPrice * item.Quantity);

        var orderId = await _dao.CreateOrder(command.CustomerId, command.OrderDate, totalSum);

        await _dao.AddOrderItems(orderId, command.OrderItems);

        var message = new OrderCreatedMessage(orderId, command.OrderItems.Select(oi => new ProductItem(oi.ProductId, oi.Quantity)));
        await _sender.PublishAsync(message);
    }
}
