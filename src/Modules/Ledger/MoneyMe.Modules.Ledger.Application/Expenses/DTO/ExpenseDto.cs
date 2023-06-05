namespace MoneyMe.Modules.Ledger.Application.Expenses.DTO;

public class ExpenseDto
{
	public Guid Id { get; set; }

	public Guid InvestmentComponentId { get; set; }

	public Guid CategoryId { get; set; }

	public Guid UserId { get; set; }

	public string Name { get; set; }

	public decimal Value { get; set; }
}