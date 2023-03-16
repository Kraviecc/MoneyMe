namespace MoneyMe.Shared.Abstractions.Exceptions;

public abstract class MoneyMeException : Exception
{
	protected MoneyMeException(string message) : base(message) { }
}