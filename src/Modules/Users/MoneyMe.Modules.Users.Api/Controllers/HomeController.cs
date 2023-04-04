using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Users.Api.Controllers;

[Route(UsersModule.BasePath)]
internal class HomeController : BaseController
{
    [HttpGet]
    public ActionResult<string> Get() => "Users API";
}