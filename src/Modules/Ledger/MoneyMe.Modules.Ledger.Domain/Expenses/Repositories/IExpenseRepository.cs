using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Repositories;

public interface IExpenseRepository
{
	Task<Expense> GetAsync(AggregateId id);

	Task AddAsync(Expense expense);

	Task UpdateAsync(Expense expense);

	Task DeleteAsync(AggregateId id);
}