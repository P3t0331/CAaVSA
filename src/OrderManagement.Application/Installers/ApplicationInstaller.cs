using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using OrderManagement.Core.Installers;
using Wolverine.Attributes;
using Carter;

[assembly: WolverineModule]
namespace OrderManagement.Application.Installers;

public static class ApplicationInstaller
{
    public static void InstallApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.InstallRegisterAttribute(assembly);
        services.AddCarter();
    }
}
