using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;

public interface IExpenseRepository
{
	Task<Expense?> GetAsync(AggregateId id);

	Task AddAsync(Expense expense);

	Task UpdateAsync(Expense expense);

	Task DeleteAsync(AggregateId id);
}