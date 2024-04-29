using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RegisterAttribute<TType> : RegisterAttribute
{
    public RegisterAttribute(ServiceLifetime lifetime = ServiceLifetime.Scoped) : base(typeof(TType), lifetime) { }
}

[AttributeUsage(AttributeTargets.Class)]
public class RegisterAttribute : Attribute
{
    public Type? Interface { get; set; }
    public ServiceLifetime Lifetime { get; }

    public RegisterAttribute(Type? @interface = null, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        Interface = @interface;
        Lifetime = lifetime;
    }
}
