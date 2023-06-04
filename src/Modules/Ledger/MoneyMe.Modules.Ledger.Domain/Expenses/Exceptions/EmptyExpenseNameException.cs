using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Exceptions;

public class EmptyExpenseNameException : MoneyMeException
{
	public Guid ExpenseId { get; }

	public EmptyExpenseNameException(Guid expenseId) : base($"Expense with ID: '{expenseId}' defines empty name") =>
		ExpenseId = expenseId;
}