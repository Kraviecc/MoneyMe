using Microsoft.Extensions.DependencyInjection;

namespace MoneyMe.Modules.Ledger.Infrastructure;

public static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		return services;
	}
}