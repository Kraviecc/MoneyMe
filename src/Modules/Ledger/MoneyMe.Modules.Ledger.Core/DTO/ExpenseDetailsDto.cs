using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.DTO;

internal class ExpenseDetailsDto : ExpenseDto
{
	public Category Category { get; set; }
}