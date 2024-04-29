using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Wolverine;
using static OrderManagement.Application.Features.Order.CreateOrderCommand.ICreateOrderDao;

namespace OrderManagement.Application.Features.Order.CreateOrderCommand;

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/Order", async (Request request, IMessageBus sender) =>
        {
            var command = new CreateOrderCommand(request.CustomerId, request.OrderDate, request.OrderItems);

            var result = await sender.InvokeAsync<CreateOrderCommand.Result>(command);

            return new Response(true);
        });
    }

    public record Request(Guid CustomerId, DateTime OrderDate, List<OrderItem> OrderItems);
    public record Response(bool success);
}
