using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Users.Api.Controllers;

[Route(UsersModule.BasePath)]
internal class HomeController : BaseController
{
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<string> Get() => "Users API";
}