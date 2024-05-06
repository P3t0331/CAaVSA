using Application.Common.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Product.GetProducts;

public record GetProductsQuery()
{
    public record Result(IEnumerable<Domain.Product.Product> products);
}

public class GetProductsHandler
{
    private readonly IQueryObject<Domain.Product.Product> _productQueryObject;

    public GetProductsHandler(IQueryObject<Domain.Product.Product> productQueryObject)
    {
        _productQueryObject = productQueryObject;
    }

    public async Task<GetProductsQuery.Result> Handle(GetProductsQuery query)
    {
        var products = await _productQueryObject.ExecuteAsync();

        return new(products);
    }
}
