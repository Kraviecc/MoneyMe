using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Core.Policies.Category;
using MoneyMe.Modules.Ledger.Core.Repositories;
using MoneyMe.Modules.Ledger.Core.Services;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("MoneyMe.Modules.Ledger.Api")]

namespace MoneyMe.Modules.Ledger.Core;

internal static class Extensions
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddPostgres<LedgerDbContext>();

		services.AddSingleton<ICategoryDeletionPolicy, RelatedItemsCategoryPolicy>();
		services.AddSingleton<ICategoryModificationPolicy, DuplicatedCategoryPolicy>();
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<ICategoryService, CategoryService>();

		return services;
	}
}