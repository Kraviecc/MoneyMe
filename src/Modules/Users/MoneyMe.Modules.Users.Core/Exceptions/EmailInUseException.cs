using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Users.Core.Exceptions;

internal class EmailInUseException : MoneyMeException
{
    public EmailInUseException() : base("Email is already in use.")
    {
    }
}