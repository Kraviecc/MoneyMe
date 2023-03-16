using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MoneyMe.Modules.Investments.Api")]

namespace MoneyMe.Modules.Investments.Core;

internal static class Extensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		return services;
	}
}