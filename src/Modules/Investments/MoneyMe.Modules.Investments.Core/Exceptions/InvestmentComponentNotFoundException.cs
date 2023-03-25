using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Investments.Core.Exceptions;

internal class InvestmentComponentNotFoundException : MoneyMeException
{
	public InvestmentComponentNotFoundException(Guid id) : base($"Investment component with ID: {id} was not found") { }
}