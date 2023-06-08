using Microsoft.AspNetCore.Mvc;
using MoneyMe.Shared.Infrastructure.Api;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[ApiController]
[ProducesDefaultContentType]
[Route(LedgerModule.BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{
	protected ActionResult<T?> OkOrNotFound<T>(T model)
	{
		if (model is null)
		{
			return NotFound();
		}

		return Ok(model);
	}
}