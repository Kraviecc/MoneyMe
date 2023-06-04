using Microsoft.Extensions.DependencyInjection;

namespace MoneyMe.Modules.Ledger.Domain;

public static class Extensions
{
	public static IServiceCollection AddDomain(this IServiceCollection services)
	{
		return services;
	}
}