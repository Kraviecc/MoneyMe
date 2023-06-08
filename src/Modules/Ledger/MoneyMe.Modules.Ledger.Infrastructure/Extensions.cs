using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Modules.Ledger.Infrastructure.EF;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Repositories;
using MoneyMe.Shared.Infrastructure.Postgres;

namespace MoneyMe.Modules.Ledger.Infrastructure;

public static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		return services
		   .AddPostgres<LedgerDbContext>()
		   .AddScoped<IExpenseRepository, ExpenseRepository>()
		   .AddScoped<IIncomeRepository, IncomeRepository>();
	}
}