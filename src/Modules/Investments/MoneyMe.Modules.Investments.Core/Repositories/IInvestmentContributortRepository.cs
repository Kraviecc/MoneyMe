using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Repositories;

internal interface IInvestmentContributorRepository
{
	Task<InvestmentContributor?> GetAsync(Guid investmentContributorId);
	Task<IReadOnlyList<InvestmentContributor?>> GetByInvestmentComponentAsync(Guid investmentComponentId);

	Task AddAsync(InvestmentContributor investmentContributor);

	Task DeleteAsync(InvestmentContributor investmentContributor);
}