using Wolverine;
using Wolverine.Http;
using static OrderManagement.Application.Features.Order.CreateOrderCommand.ICreateOrderDao;

namespace OrderManagement.Application.Features.Order.CreateOrderCommand;

public class CreateOrderEndpoint
{
    [WolverinePost("/api/Order")]
    public static async Task<Response> Get(Request request, IMessageBus sender)
    {
        var command = new CreateOrderCommand(request.CustomerId, request.OrderDate, request.OrderItems);

        var result = await sender.InvokeAsync<CreateOrderCommand.Result>(command);

        return new Response(true);
    }

    public record Request(Guid CustomerId, DateTime OrderDate, List<OrderItem> OrderItems);
    public record Response(bool success);
}
