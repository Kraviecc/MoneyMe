using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Services;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Authorize(Policy)]
internal class InvestmentsController : BaseController
{
    private const string Policy = "investments";
    private readonly IInvestmentService _investmentService;

    public InvestmentsController(IInvestmentService investmentService)
    {
        _investmentService = investmentService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<InvestmentDetailsDto?>> Get(Guid id)
    {
        return OkOrNotFound(await _investmentService.GetAsync(id));
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult<IReadOnlyList<InvestmentDetailsDto>>> GetAllAsync()
    {
        return Ok(await _investmentService.GetAllAsync());
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> AddAsync(InvestmentDto dto)
    {
        await _investmentService.AddAsync(dto);

        return CreatedAtAction(
            nameof(Get),
            new { id = dto.Id },
            null);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> UpdateAsync(Guid id, InvestmentDto dto)
    {
        dto.Id = id;
        await _investmentService.UpdateAsync(dto);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _investmentService.DeleteAsync(id);

        return NoContent();
    }
}