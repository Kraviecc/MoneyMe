using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentDto
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(100, MinimumLength = 3)]
	public string Name { get; set; }

	[StringLength(1000, MinimumLength = 3)]
	public string Description { get; set; }
}