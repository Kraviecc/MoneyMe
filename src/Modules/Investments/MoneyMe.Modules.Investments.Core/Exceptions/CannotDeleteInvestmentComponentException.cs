using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Investments.Core.Exceptions;

internal class CannotDeleteInvestmentComponentException : MoneyMeException
{
	public CannotDeleteInvestmentComponentException(Guid id, int errorCode) : base(
		$"Investment component with ID: {id} cannot be deleted") { }
}