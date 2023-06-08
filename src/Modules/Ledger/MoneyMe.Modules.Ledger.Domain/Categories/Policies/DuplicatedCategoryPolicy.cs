using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Policies;

internal class DuplicatedCategoryPolicy : ICategoryModificationPolicy
{
	private readonly ICategoryRepository _categoryRepository;

	public DuplicatedCategoryPolicy(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<bool> CanUseAsync(Category category)
	{
		return await _categoryRepository
		   .GetByNameAsync(category.Name)
		   .ConfigureAwait(false) == null;
	}
}