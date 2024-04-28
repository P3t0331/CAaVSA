using Domain.Common.Installers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockManagement.Infrastructure.Persistance;
using Wolverine.Attributes;

[assembly: WolverineModule]
namespace Infrastructure.Installers;

public static class InfrastructureInstaller
{
    public static void InstallInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<StockManagementDbContext>(options =>
        {
            //TODO: refactor
            options.UseSqlite("Data Source=SQLLiteDatabase.db");
        });


        services.InstallRegisterAttribute(System.Reflection.Assembly.GetExecutingAssembly());
    }
}
