namespace MoneyMe.Modules.Ledger.Core.Policies.Category;

internal interface ICategoryModificationPolicy
{
	Task<bool> CanUseAsync(Entities.Category category);
}