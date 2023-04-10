using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Core.DAL;
using MoneyMe.Modules.Ledger.Core.DAL.Repositories;
using MoneyMe.Modules.Ledger.Core.Policies.Category;
using MoneyMe.Modules.Ledger.Core.Repositories;
using MoneyMe.Modules.Ledger.Core.Services;
using MoneyMe.Shared.Infrastructure.Postgres;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MoneyMe.Modules.Ledger.Api")]

namespace MoneyMe.Modules.Ledger.Core;

internal static class Extensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddPostgres<LedgerDbContext>();

		services.AddScoped<ICategoryDeletionPolicy, RelatedItemsCategoryPolicy>();
		services.AddScoped<ICategoryModificationPolicy, DuplicatedCategoryPolicy>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICategoryService, CategoryService>();

		services.AddScoped<IExpenseRepository, ExpenseRepository>();
		services.AddScoped<IExpenseService, ExpenseService>();

		services.AddScoped<IIncomeRepository, IncomeRepository>();
		services.AddScoped<IIncomeService, IncomeService>();

		return services;
	}
}