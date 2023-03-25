using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.Entities;

internal class InvestmentComponent
{
	public Guid Id { get; set; }

	public Guid InvestmentId { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public InvestmentComponentType Type { get; set; }

	public Investment Investment { get; set; }
}