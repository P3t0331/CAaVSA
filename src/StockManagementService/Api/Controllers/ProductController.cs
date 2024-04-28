using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Product.AddProduct;
using StockManagement.Contracts.Product.AddProduct;
using Wolverine;

namespace StockManagement.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMessageBus _sender;

        public ProductController(IMessageBus sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductRequest request, CancellationToken cancellationToken)
        {
            var command = new AddProductCommand(request.Name, request.Description, request.Price, request.Sku);

            var result = await _sender.InvokeAsync<AddProductCommand.Result>(command, cancellationToken);

            return Ok(new AddProductResponse(result.Id, result.Name, result.Description, result.Price, result.Sku));
        }
    }
}
