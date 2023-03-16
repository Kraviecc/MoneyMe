using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Investments.Core.Exceptions;

internal class InvestmentNotFoundException : MoneyMeException
{
	public InvestmentNotFoundException(Guid id) : base($"Investment with ID: {id} was not found") { }
}