using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.DTO;

internal class CategoryDetailsDto : CategoryDto
{
	public List<Expense> Expenses { get; set; } = new();

	public List<Income> Incomes { get; set; } = new();
}