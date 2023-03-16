using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Investments.Core;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MoneyMe.Bootstrapper")]

namespace MoneyMe.Modules.Investments.Api;

internal static class Extensions
{
	public static IServiceCollection AddInvestments(this IServiceCollection services)
	{
		return services.AddCore();
	}
}