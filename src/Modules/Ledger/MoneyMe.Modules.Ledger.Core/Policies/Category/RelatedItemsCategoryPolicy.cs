namespace MoneyMe.Modules.Ledger.Core.Policies.Category;

internal class RelatedItemsCategoryPolicy : ICategoryDeletionPolicy
{
	public Task<bool> CanDeleteAsync(Entities.Category category)
	{
		return Task.FromResult(!category.HasAnyRelatedItem());
	}
}