using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Users.Core.Exceptions;

internal class InvalidCredentialsException : MoneyMeException
{
    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }
}