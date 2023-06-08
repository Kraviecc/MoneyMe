using Microsoft.Extensions.DependencyInjection;
using MoneyMe.Modules.Ledger.Domain.Categories.Policies;

namespace MoneyMe.Modules.Ledger.Domain;

public static class Extensions
{
	public static IServiceCollection AddDomain(this IServiceCollection services)
	{
		return services
		   .AddTransient<ICategoryDeletionPolicy, RelatedItemsCategoryPolicy>()
		   .AddTransient<ICategoryModificationPolicy, DuplicatedCategoryPolicy>();
	}
}