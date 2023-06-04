namespace MoneyMe.Shared.Abstractions.Kernel.Types;

public class InvestmentComponentId : TypeId
{
	public InvestmentComponentId(Guid value) : base(value) { }

	public static implicit operator InvestmentComponentId(Guid id) => new InvestmentComponentId(id);
}