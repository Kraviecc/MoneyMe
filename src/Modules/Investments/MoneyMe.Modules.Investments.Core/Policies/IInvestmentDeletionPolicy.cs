using MoneyMe.Modules.Investments.Core.Entities;

namespace MoneyMe.Modules.Investments.Core.Policies;

internal interface IInvestmentDeletionPolicy
{
   Task<bool> CanDeleteAsync(Investment investment);
}