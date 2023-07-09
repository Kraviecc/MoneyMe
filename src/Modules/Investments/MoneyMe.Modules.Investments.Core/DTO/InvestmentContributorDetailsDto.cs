using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentContributorDetailsDto : InvestmentContributorDto
{
	public InvestmentContributorType Type { get; set; }
}