using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Exceptions;

public class ZeroExpenseValueException : MoneyMeException
{
	public Guid ExpenseId { get; }

	public ZeroExpenseValueException(Guid expenseId) : base($"Expense with ID: '{expenseId}' defines 0 value") =>
		ExpenseId = expenseId;
}