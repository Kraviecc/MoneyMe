using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Types;

public class InvestmentComponentId : TypeId
{
	public InvestmentComponentId(Guid value) : base(value) { }

	public static implicit operator InvestmentComponentId(Guid id) => new(id);
}