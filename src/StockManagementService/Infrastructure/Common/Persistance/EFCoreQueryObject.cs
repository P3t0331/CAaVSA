using Application.Common.Persistance;
using Domain.Common.Attributes;
using Infrastructure.Common.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StockManagement.Infrastructure.Common.Persistance;

[Register(typeof(IQueryObject<>), ServiceLifetime.Transient)]
public class EFCoreQueryObject<TAggregate> : QueryObject<TAggregate> where TAggregate : class
{
    private readonly StockManagementDbContext _dbContext;

    public EFCoreQueryObject(StockManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = _dbContext.Set<TAggregate>().AsQueryable();
    }

    public override async Task<IEnumerable<TAggregate>> ExecuteAsync()
    {
        return await _query.ToListAsync();
    }
}
