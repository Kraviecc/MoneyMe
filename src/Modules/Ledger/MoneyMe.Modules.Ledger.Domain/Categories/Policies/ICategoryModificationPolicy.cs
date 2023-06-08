using MoneyMe.Modules.Ledger.Domain.Categories.Entities;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Policies;

public interface ICategoryModificationPolicy
{
	Task<bool> CanUseAsync(Category category);
}