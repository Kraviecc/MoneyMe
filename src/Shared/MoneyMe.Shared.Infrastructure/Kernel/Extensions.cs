using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Shared.Infrastructure.Kernel;

internal static class Extensions
{
    public static IServiceCollection AddDomainEvents(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        return services
            .AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>()
            .Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}