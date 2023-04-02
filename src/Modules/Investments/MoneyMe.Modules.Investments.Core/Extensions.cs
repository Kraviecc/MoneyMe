using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Investments.Core.DAL;
using MoneyMe.Modules.Investments.Core.DAL.Repositories;
using System.Runtime.CompilerServices;
using MoneyMe.Modules.Investments.Core.Policies;
using MoneyMe.Modules.Investments.Core.Repositories;
using MoneyMe.Modules.Investments.Core.Services;
using MoneyMe.Shared.Infrastructure.Postgres;

[assembly:InternalsVisibleTo("MoneyMe.Modules.Investments.Api")]

namespace MoneyMe.Modules.Investments.Core;

internal static class Extensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddPostgres<InvestmentsDbContext>();

		services.AddSingleton<IInvestmentDeletionPolicy, InvestmentDeletionPolicy>();
		services.AddScoped<IInvestmentRepository, InvestmentRepository>();
		services.AddScoped<IInvestmentService, InvestmentService>();

		services.AddSingleton<IInvestmentComponentDeletionPolicy, InvestmentComponentDeletionPolicy>();
		services.AddScoped<IInvestmentComponentRepository, InvestmentComponentRepository>();
		services.AddScoped<IInvestmentComponentService, InvestmentComponentService>();

		return services;
	}
}