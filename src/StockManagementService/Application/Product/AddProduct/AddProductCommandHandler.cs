using Application.Common.Persistance;
using StockManagement.Domain.Product.ValueObjects;
using System.Xml.Linq;

namespace StockManagement.Application.Product.AddProduct;

public class AddProductCommandHandler
{
    private readonly IRepository<Domain.Product.Product> _repository;

    public AddProductCommandHandler(IRepository<Domain.Product.Product> repository)
    {
        _repository = repository;
    }

    public async Task<AddProductCommand.Result> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {

        var product = await _repository.InsertAsync(
                                new (ProductId.CreateUnique(), 
                                new (command.Name), 
                                new (command.Description), 
                                new(command.Price), 
                                new(command.Sku))
                            );
        await _repository.CommitAsync();

        return new(product.Id.Value, product.Name.Value, product.Description.Value, product.Price.Value, product.Sku.Value);
    }
}
