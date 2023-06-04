using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Exceptions;

public class MissingExpenseUserException : MoneyMeException
{
	public Guid ExpenseId { get; }

	public MissingExpenseUserException(Guid expenseId) : base($"Expense with ID: '{expenseId}' defines no user") =>
		ExpenseId = expenseId;
}