using StockManagement.Application.Stock.ReduceStock;
using StockManagement.Contracts.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolverine;

namespace StockManagement.Infrastructure.MessageHandlers.Order;

public class OrderCreatedHandler
{
    private readonly IMessageBus _sender;

    public OrderCreatedHandler(IMessageBus sender)
    {
        _sender = sender;
    }

    public async void Handle(OrderCreatedMessage message)
    {
        var commad = new ReduceStockCommand(message.Products.Select(p => (p.ProductId, p.Quantity)));
        await _sender.InvokeAsync(commad);
    }
}
