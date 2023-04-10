using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.Repositories;

internal interface IIncomeRepository
{
	Task<Income?> GetAsync(Guid id);

	Task<IReadOnlyList<Income>> GetAllAsync();

	Task AddAsync(Income income);

	Task UpdateAsync(Income income);

	Task DeleteAsync(Income income);

	Task<Income?> Get(string name);
}