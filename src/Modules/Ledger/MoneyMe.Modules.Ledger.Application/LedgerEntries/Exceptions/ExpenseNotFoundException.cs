using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Exceptions;

public class ExpenseNotFoundException : MoneyMeException
{
	public Guid ExpenseId { get; }

	public ExpenseNotFoundException(Guid expenseId) : base($"Expense not found for ID {expenseId}") =>
		ExpenseId = expenseId;
}