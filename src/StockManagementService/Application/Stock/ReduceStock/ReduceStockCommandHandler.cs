using Application.Common.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Application.Stock.ReduceStock;

public class ReduceStockCommandHandler
{
    private readonly IRepository<Domain.Stock.Stock> _repository;
    private readonly IQueryObject<Domain.Stock.Stock> _queryObject;

    public ReduceStockCommandHandler(IRepository<Domain.Stock.Stock> repository, IQueryObject<Domain.Stock.Stock> queryObject)
    {
        _repository = repository;
        _queryObject = queryObject;
    }

    public async void Handle(ReduceStockCommand command)
    {
        //TODO: Update stockLevel
    }
}
