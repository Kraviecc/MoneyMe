using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Exceptions;

public class IncomeNotFoundException : MoneyMeException
{
	public Guid IncomeId { get; }

	public IncomeNotFoundException(Guid expenseId) : base($"Income not found for ID {expenseId}") =>
		IncomeId = expenseId;
}