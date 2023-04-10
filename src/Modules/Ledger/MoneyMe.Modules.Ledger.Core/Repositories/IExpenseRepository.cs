using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.Repositories;

internal interface IExpenseRepository
{
	Task<Expense?> GetAsync(Guid id);

	Task<IReadOnlyList<Expense>> GetAllAsync();

	Task AddAsync(Expense expense);

	Task UpdateAsync(Expense expense);

	Task DeleteAsync(Expense expense);

	Task<Expense?> Get(string name);
}