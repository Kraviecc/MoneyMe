using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.Policies.Category;

internal class DuplicatedCategoryPolicy : ICategoryModificationPolicy
{
	private readonly ICategoryRepository _categoryRepository;

	public DuplicatedCategoryPolicy(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<bool> CanUseAsync(Entities.Category category)
	{
		return await _categoryRepository
		   .Get(category.Name)
		   .ConfigureAwait(false) == null;
	}
}