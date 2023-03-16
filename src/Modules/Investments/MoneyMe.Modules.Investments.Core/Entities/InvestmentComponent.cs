using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.Entities;

public class InvestmentComponent
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public InvestmentComponentType Type { get; set; }

	public Investment Investment { get; set; }
}