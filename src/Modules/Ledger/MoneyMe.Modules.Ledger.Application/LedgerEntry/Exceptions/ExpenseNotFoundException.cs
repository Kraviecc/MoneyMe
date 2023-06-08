using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Exceptions;

public class ExpenseNotFoundException : MoneyMeException
{
	public Guid ExpenseId { get; }

	public ExpenseNotFoundException(Guid expenseId) : base($"Expense not found for ID {expenseId}") =>
		ExpenseId = expenseId;
}