using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Core.Exceptions;

internal class IncomeNotFoundException : MoneyMeException
{
	public IncomeNotFoundException(Guid id) : base($"Income with ID: {id} was not found") { }
}