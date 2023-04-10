namespace MoneyMe.Modules.Ledger.Core.DTO;

internal class CategoryDetailsDto : CategoryDto
{
	public List<ExpenseDto> Expenses { get; set; } = new();

	public List<IncomeDto> Incomes { get; set; } = new();
}