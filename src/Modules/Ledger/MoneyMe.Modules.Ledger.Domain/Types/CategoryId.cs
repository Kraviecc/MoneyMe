using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Types;

public class CategoryId : TypeId
{
	public CategoryId(Guid value) : base(value) { }

	public static implicit operator CategoryId(Guid id) => new(id);
}