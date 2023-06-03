using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Events;
using System.Reflection;

namespace MoneyMe.Shared.Infrastructure.Events;

internal static class Extensions
{
	public static IServiceCollection AddEvents(
		this IServiceCollection services,
		IEnumerable<Assembly> assemblies)
	{
		services.AddSingleton<IEventDispatcher, EventDispatcher>();
		services.Scan(
			p => p.FromAssemblies(assemblies)
			   .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
			   .AsImplementedInterfaces()
			   .WithScopedLifetime());

		return services;
	}
}