using System.ComponentModel.DataAnnotations;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Models;

namespace MoneyMe.Modules.Investments.Core.DTO;

internal class InvestmentComponentDto
{
	public Guid Id { get; set; }

	public Guid InvestmentId { get; set; }

	[Required]
	[StringLength(100, MinimumLength = 3)]
	public string Name { get; set; }

	public string Description { get; set; } = string.Empty;

	public InvestmentComponentType Type { get; set; }

	public Investment? Investment { get; set; }
}