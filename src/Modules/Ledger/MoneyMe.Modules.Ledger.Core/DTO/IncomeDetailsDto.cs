using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.DTO;

internal class IncomeDetailsDto : IncomeDto
{
	public Category Category { get; set; }
}