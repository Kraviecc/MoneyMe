using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Route("investments-module")]
internal class HomeController : ControllerBase
{
	[HttpGet]
	public ActionResult<string> Get() => "Investments API";
}