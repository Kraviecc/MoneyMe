using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Users.Core.DTO;
using MoneyMe.Modules.Users.Core.Services;
using MoneyMe.Shared.Abstractions.Auth;
using MoneyMe.Shared.Abstractions.Contexts;

namespace MoneyMe.Modules.Users.Api.Controllers;

internal class AccountController : BaseController
{
    private readonly IIdentityService _identityService;
    private readonly IContext _context;

    public AccountController(IIdentityService identityService, IContext context)
    {
        _identityService = identityService;
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<AccountDto?>> GetAsync()
        => OkOrNotFound(await _identityService.GetAsync(_context.Identity.Id));

    [HttpPost("sign-up")]
    public async Task<ActionResult> SignUpAsync(SignUpDto dto)
    {
        await _identityService.SignUpAsync(dto);
        return NoContent();
    }

    [HttpPost("sign-in")]
    public async Task<ActionResult<JsonWebToken>> SignInAsync(SignInDto dto)
        => Ok(await _identityService.SignInAsync(dto));
}