using MoneyMe.Modules.Ledger.Domain.Types;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Policies;

public interface ICategoryDeletionPolicy
{
	Task<bool> CanDeleteAsync(CategoryId categoryId);
}