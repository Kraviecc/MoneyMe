using Microsoft.Extensions.DependencyInjection;

namespace MoneyMe.Modules.Ledger.Application;

public static class Extensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		return services;
	}
}