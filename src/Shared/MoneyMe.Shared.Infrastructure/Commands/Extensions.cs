using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Shared.Infrastructure.Commands;

internal static class Extensions
{
    public static IServiceCollection AddCommands(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.Scan(
            p => p.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}