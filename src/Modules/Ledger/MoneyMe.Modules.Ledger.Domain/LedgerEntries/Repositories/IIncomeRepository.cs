using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;

public interface IIncomeRepository
{
	Task<Income?> GetAsync(AggregateId id);

	Task AddAsync(Income income);

	Task UpdateAsync(Income income);

	Task DeleteAsync(AggregateId id);
}