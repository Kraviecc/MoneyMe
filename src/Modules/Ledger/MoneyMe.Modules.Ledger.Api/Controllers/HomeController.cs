using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Route(LedgerModule.BasePath)]
internal class HomeController : BaseController
{
	[HttpGet]
	[ProducesResponseType(200)]
	public ActionResult<string> Get() => "Ledger API";
}