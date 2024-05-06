using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using StockManagement.Application.Product.AddProduct;
using StockManagement.Application.Product.GetProducts;
using StockManagement.Contracts.Product.AddProduct;
using StockManagement.Contracts.Product.GetProducts;
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

        [HttpGet("Product")]
        public async Task<IActionResult> GetProducts( CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();

            var result = await _sender.InvokeAsync<GetProductsQuery.Result>(query, cancellationToken);

            var x = Map(result.products);

            return Ok(new GetProductsResponse(x));
        }


        private IEnumerable<Product> Map(IEnumerable<Domain.Product.Product> products)
        {
            
            foreach (var product in products)
            {
                yield return new Product(product.Name.Value, product.Description.Value, product.Price.Value, product.Sku.Value);
            }
        }
    }
}
