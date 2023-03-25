using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Repositories;

internal interface IInvestmentComponentRepository
{
	Task<InvestmentComponent?> GetAsync(Guid id);

	Task<IReadOnlyList<InvestmentComponent>> GetAllAsync();

	Task AddAsync(InvestmentComponent investmentComponent);

	Task UpdateAsync(InvestmentComponent investmentComponent);

	Task DeleteAsync(InvestmentComponent investmentComponent);
}