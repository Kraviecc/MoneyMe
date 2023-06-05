using MoneyMe.Modules.Ledger.Application.Expenses.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Queries;

public class GetExpense : IQuery<ExpenseDto>
{
	public Guid Id { get; set; }
}