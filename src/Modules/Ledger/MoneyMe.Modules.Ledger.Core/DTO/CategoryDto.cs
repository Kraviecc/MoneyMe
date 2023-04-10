using MoneyMe.Modules.Ledger.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Modules.Ledger.Core.DTO;

internal class CategoryDto
{
	public Guid Id { get; set; }

	[Required]
	public Guid InvestmentId { get; set; }

	[Required]
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }

	[Required]
	public CategoryType Type { get; set; }
}