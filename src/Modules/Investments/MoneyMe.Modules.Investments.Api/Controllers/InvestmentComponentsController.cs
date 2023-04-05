using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Services;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Authorize(Policy)]
internal class InvestmentComponentsController : BaseController
{
    private const string Policy = "components";
    private readonly IInvestmentComponentService _investmentComponentService;

    public InvestmentComponentsController(IInvestmentComponentService investmentComponentService)
    {
        _investmentComponentService = investmentComponentService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<InvestmentComponentDetailsDto?>> Get(Guid id)
    {
        return OkOrNotFound(await _investmentComponentService.GetAsync(id));
    }

    [HttpGet]
    [ProducesResponseType(200)]
    public async Task<ActionResult<IReadOnlyList<InvestmentComponentDetailsDto>>> GetAllAsync()
    {
        return Ok(await _investmentComponentService.GetAllAsync());
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> AddAsync(InvestmentComponentDto dto)
    {
        await _investmentComponentService.AddAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new
            {
                id = dto.Id
            },
            null);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> UpdateAsync(Guid id, InvestmentComponentDto dto)
    {
        dto.Id = id;
        await _investmentComponentService.UpdateAsync(dto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _investmentComponentService.DeleteAsync(id);

        return NoContent();
    }
}