using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Core.Exceptions;

internal class CategoryNotFoundException : MoneyMeException
{
	public CategoryNotFoundException(Guid id) : base($"Category with ID: {id} was not found") { }
}