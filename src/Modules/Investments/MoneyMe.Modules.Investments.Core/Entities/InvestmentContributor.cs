using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.Entities;

internal class InvestmentContributor
{
	public Guid Id { get; set; }

	public Guid InvestmentComponentId { get; set; }

	public Guid InvestmentContributorId { get; set; }

	public InvestmentContributorType Type { get; set; }
}