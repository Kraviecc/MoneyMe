using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Route(InvestmentsModule.BasePath)]
internal class HomeController : BaseController
{
    [HttpGet]
    [ProducesResponseType(200)]
    public ActionResult<string> Get() => "Investments API";
}