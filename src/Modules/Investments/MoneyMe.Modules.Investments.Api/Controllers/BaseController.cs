using Microsoft.AspNetCore.Mvc;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[ApiController]
[Route(BasePath + "/[controller]")]
internal class BaseController : ControllerBase
{
    protected const string BasePath = "investments-module";

    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model);
    }
}