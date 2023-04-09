namespace MoneyMe.Modules.Ledger.Core.Policies.Category;

internal interface ICategoryDeletionPolicy
{
	Task<bool> CanDeleteAsync(Entities.Category category);
}