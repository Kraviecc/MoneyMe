using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Policies;

internal class InvestmentComponentDeletionPolicy : IInvestmentComponentDeletionPolicy
{
	public Task<bool> CanDeleteAsync(InvestmentComponent investmentComponent)
	{
		return Task.FromResult(true);
	}
}