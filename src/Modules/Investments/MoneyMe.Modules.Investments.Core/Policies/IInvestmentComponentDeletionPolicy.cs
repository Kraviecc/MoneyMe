using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Policies;

internal interface IInvestmentComponentDeletionPolicy
{
	Task<bool> CanDeleteAsync(InvestmentComponent investmentComponent);
}