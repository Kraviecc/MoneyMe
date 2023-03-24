using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Policies;

internal class InvestmentDeletionPolicy : IInvestmentDeletionPolicy
{
    public Task<bool> CanDeleteAsync(Investment investment)
    {
        return Task.FromResult(!investment.Components.Any());
    }
}