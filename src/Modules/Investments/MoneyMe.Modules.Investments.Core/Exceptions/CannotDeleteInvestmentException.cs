using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Investments.Core.Exceptions;

internal class CannotDeleteInvestmentException : MoneyMeException
{
	public CannotDeleteInvestmentException(Guid id, int errorCode) : base($"Investment with ID: {id} cannot be deleted") { }
}