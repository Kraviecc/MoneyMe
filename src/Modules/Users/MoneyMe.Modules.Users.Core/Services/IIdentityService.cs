using MoneyMe.Modules.Users.Core.DTO;
using MoneyMe.Shared.Abstractions.Auth;

namespace MoneyMe.Modules.Users.Core.Services;

public interface IIdentityService
{
    Task<AccountDto?> GetAsync(Guid id);
    Task<JsonWebToken> SignInAsync(SignInDto dto);
    Task SignUpAsync(SignUpDto dto);
}