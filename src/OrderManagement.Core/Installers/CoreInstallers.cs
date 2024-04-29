using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wolverine.Attributes;

[assembly: WolverineModule]
namespace OrderManagement.Core.Installers;

public static class CoreInstaller
{
    public static void InstallCore(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.InstallRegisterAttribute(assembly);
    }

    public static void InstallRegisterAttribute(this IServiceCollection services, Assembly assembly)
    {
        var classes = assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(RegisterAttribute), true).FirstOrDefault() != null).ToList();

        foreach (var @class in classes)
        {
            var attribute = @class.GetCustomAttribute<RegisterAttribute>();

            Type? @interface = attribute!.Interface;
            if (@interface == null)
                @interface = @class;

            services.RegisterService(@interface, @class, attribute.Lifetime);
        }
    }

    private static void RegisterService(this IServiceCollection services, Type @interface, Type type, ServiceLifetime lifeTime)
    {
        switch (lifeTime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton(@interface, type);
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped(@interface, type);
                break;
            case ServiceLifetime.Transient:
                services.AddTransient(@interface, type);
                break;
        }
    }
}
