using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Users.Core.Exceptions;

internal class UserNotActiveException : MoneyMeException
{
    public Guid UserId { get; }

    public UserNotActiveException(Guid userId) : base($"User with ID: '{userId}' is not active.")
    {
        UserId = userId;
    }
}