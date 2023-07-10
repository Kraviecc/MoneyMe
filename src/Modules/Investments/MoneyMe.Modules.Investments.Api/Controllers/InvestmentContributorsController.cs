using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Investments.Core.DTO;
using MoneyMe.Modules.Investments.Core.Services;

namespace MoneyMe.Modules.Investments.Api.Controllers;

[Authorize(Policy)]
internal class InvestmentContributorsController : BaseController
{
    private const string Policy = "contributors";
    private readonly IInvestmentContributorService _investmentContributorService;

    public InvestmentContributorsController(IInvestmentContributorService investmentContributorService)
    {
        _investmentContributorService = investmentContributorService;
    }

    [HttpGet("{investmentComponentId:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<IReadOnlyList<InvestmentContributorDetailsDto>>> GetForInvestmentComponent(
        Guid investmentComponentId)
    {
        return OkOrNotFound(await _investmentContributorService.GetAsync(investmentComponentId));
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> AddAsync(InvestmentContributorDto dto)
    {
        await _investmentContributorService.AddAsync(dto);

        return CreatedAtAction(
            nameof(GetForInvestmentComponent),
            new
            {
                id = dto.Id
            },
            null);
    }

    [HttpDelete("{investmentComponentId:guid}/{investmentContributorId:guid}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public async Task<ActionResult> DeleteAsync(Guid investmentContributorId)
    {
        await _investmentContributorService.DeleteAsync(investmentContributorId);

        return NoContent();
    }
}