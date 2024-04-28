using Domain.Common.Installers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wolverine.Attributes;

[assembly: WolverineModule]
namespace Application.Installers;

public static class ApplicationInstaller
{
    public static void InstallApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.InstallRegisterAttribute(assembly);
    }
}
