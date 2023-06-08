using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Modules.Ledger.Domain.Types;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Policies;

internal class RelatedItemsCategoryPolicy : ICategoryDeletionPolicy
{
	private readonly ICategoryRepository _categoryRepository;

	public RelatedItemsCategoryPolicy(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<bool> CanDeleteAsync(CategoryId categoryId)
	{
		return !await _categoryRepository.IsAnyRelatedItem(categoryId);
	}
}