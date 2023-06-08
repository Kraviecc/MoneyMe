using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Queries;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Contexts;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class IncomesController : BaseController
{
	private const string Policy = "incomes";

	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IContext _context;

	public IncomesController(
		ICommandDispatcher commandDispatcher,
		IQueryDispatcher queryDispatcher,
		IContext context)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_context = context;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<LedgerEntryDto?>> Get(Guid id)
	{
		return OkOrNotFound(await _queryDispatcher.QueryAsync(new GetIncome(id)));
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<LedgerEntryDto>>> GetAllAsync()
	{
		return Ok(await _queryDispatcher.QueryAsync(new GetAllIncomesForUser(_context.Identity.Id)));
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(CreateIncome command)
	{
		var userCommand = command with
		{
			UserId = _context.Identity.Id
		};

		await _commandDispatcher.SendAsync(userCommand);

		return CreatedAtAction(
			nameof(Get),
			new
			{
				id = userCommand.Id
			},
			null);
	}

	[HttpPut]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> UpdateAsync(UpdateIncome command)
	{
		await _commandDispatcher.SendAsync(command);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> DeleteAsync(Guid id)
	{
		await _commandDispatcher.SendAsync(new DeleteIncome(id));

		return NoContent();
	}
}