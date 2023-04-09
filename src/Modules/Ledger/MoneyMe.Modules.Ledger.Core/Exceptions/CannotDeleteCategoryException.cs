using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Core.Exceptions;

internal class CannotDeleteCategoryException : MoneyMeException
{
	public CannotDeleteCategoryException(Guid id, int errorCode) :
		base($"Category with ID: {id} cannot be deleted") { }
}