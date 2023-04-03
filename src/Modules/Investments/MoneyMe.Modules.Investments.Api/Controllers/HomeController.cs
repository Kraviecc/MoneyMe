using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Route(InvestmentsModule.BasePath)]
internal class HomeController : BaseController
{
    [HttpGet]
    public ActionResult<string> Get() => "Investments API";
}