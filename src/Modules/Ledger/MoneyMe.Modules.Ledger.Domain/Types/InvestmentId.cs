using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Types;

public class InvestmentId : TypeId
{
	public InvestmentId(Guid value) : base(value) { }

	public static implicit operator InvestmentId(Guid id) => new(id);
}