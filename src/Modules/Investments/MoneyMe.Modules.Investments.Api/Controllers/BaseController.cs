using Microsoft.AspNetCore.Mvc;
using MoneyMe.Shared.Infrastructure.Api;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[ApiController]
[ProducesDefaultContentType]
[Route(InvestmentsModule.BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model);
    }
}