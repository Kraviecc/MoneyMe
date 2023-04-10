using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Services;
using MoneyMe.Shared.Abstractions.Contexts;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class IncomesController : BaseController
{
	private const string Policy = "incomes";
	private readonly IIncomeService _incomeService;
	private readonly IContext _context;

	public IncomesController(
		IIncomeService incomeService,
		IContext context)
	{
		_incomeService = incomeService;
		_context = context;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<IncomeDetailsDto?>> Get(Guid id)
	{
		return OkOrNotFound(await _incomeService.GetAsync(id));
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<IncomeDetailsDto>>> GetAllAsync()
	{
		return Ok(await _incomeService.GetAllAsync());
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(IncomeDto dto)
	{
		dto.UserId = _context.Identity.Id;
		await _incomeService.AddAsync(dto);

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
	public async Task<ActionResult> UpdateAsync(Guid id, IncomeDto dto)
	{
		dto.Id = id;
		dto.UserId = _context.Identity.Id;
		await _incomeService.UpdateAsync(dto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> DeleteAsync(Guid id)
	{
		await _incomeService.DeleteAsync(id);

		return NoContent();
	}
}