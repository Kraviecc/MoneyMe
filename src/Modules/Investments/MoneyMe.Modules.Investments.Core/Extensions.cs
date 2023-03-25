using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using MoneyMe.Modules.Investments.Core.Policies;
using MoneyMe.Modules.Investments.Core.Repositories;
using MoneyMe.Modules.Investments.Core.Services;

[assembly:InternalsVisibleTo("MoneyMe.Modules.Investments.Api")]

namespace MoneyMe.Modules.Investments.Core;

internal static class Extensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddSingleton<IInvestmentRepository, InMemoryInvestmentRepository>();
		services.AddSingleton<IInvestmentDeletionPolicy, InvestmentDeletionPolicy>();
		services.AddScoped<IInvestmentService, InvestmentService>();

		services.AddSingleton<IInvestmentComponentRepository, InMemoryInvestmentComponentRepository>();
		services.AddSingleton<IInvestmentComponentDeletionPolicy, InvestmentComponentDeletionPolicy>();
		services.AddScoped<IInvestmentComponentService, InvestmentComponentService>();

		return services;
	}
}