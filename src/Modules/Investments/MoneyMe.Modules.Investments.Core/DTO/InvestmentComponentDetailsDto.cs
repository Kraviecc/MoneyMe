using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentComponentDetailsDto : InvestmentComponentDto
{
	[Required]
	[StringLength(1000, MinimumLength = 3)]
	public string Description { get; set; }
}