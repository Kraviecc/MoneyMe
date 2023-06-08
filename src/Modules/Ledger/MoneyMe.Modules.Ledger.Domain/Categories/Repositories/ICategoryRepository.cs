using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Repositories;

public interface ICategoryRepository
{
	Task<Category?> GetAsync(AggregateId id);

	Task<IReadOnlyList<Category>> GetAllByTypeAsync(CategoryType categoryType);

	Task<Category?> GetByNameAsync(string name);

	Task AddAsync(Category category);

	Task UpdateAsync(Category category);

	Task DeleteAsync(AggregateId id);
}