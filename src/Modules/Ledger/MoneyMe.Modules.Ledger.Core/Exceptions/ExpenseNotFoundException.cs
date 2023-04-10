using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Core.Exceptions;

internal class ExpenseNotFoundException : MoneyMeException
{
	public ExpenseNotFoundException(Guid id) : base($"Expense with ID: {id} was not found") { }
}