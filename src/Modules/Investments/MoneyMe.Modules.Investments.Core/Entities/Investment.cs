namespace MoneyMe.Modules.Investments.Core.Entities;

public class Investment
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public IEnumerable<InvestmentComponent> Components { get; set; }
}