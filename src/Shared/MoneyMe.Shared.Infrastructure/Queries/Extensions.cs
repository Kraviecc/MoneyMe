using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Shared.Abstractions.Queries;
using System.Reflection;

namespace MoneyMe.Shared.Infrastructure.Queries;

public static class Extensions
{
	public static IServiceCollection AddQueries(
		this IServiceCollection services,
		IEnumerable<Assembly> assemblies)
	{
		services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
		services.Scan(
			p => p.FromAssemblies(assemblies)
			   .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
			   .AsImplementedInterfaces()
			   .WithScopedLifetime());

		return services;
	}
}