using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Repositories;

internal interface IInvestmentRepository
{
	Task<Investment?> GetAsync(Guid id);

	Task<IReadOnlyList<Investment>> GetAllAsync();

	Task AddAsync(Investment investment);

	Task UpdateAsync(Investment investment);

	Task DeleteAsync(Guid id);
}