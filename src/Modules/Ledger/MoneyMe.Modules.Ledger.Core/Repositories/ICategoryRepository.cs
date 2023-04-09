using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.Repositories;

internal interface ICategoryRepository
{
	Task<Category?> GetAsync(Guid id);

	Task<IReadOnlyList<Category>> GetAllAsync();

	Task AddAsync(Category category);

	Task UpdateAsync(Category category);

	Task DeleteAsync(Category category);

	Task<Category?> Get(string name);
}