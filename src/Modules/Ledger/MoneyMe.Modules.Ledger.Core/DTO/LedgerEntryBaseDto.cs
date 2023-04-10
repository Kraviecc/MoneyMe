using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Modules.Ledger.Core.DTO;

internal abstract class LedgerEntryBaseDto
{
	public Guid Id { get; set; }

	[Required]
	public Guid InvestmentComponentId { get; set; }

	[Required]
	public Guid UserId { get; set; }

	[Required]
	[StringLength(50, MinimumLength = 3)]
	public string Name { get; set; }

	[Required]
	public decimal Value { get; set; }

	public Guid CategoryId { get; set; }
}