using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.Commands;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Contexts;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class ExpensesController : BaseController
{
	private const string Policy = "expenses";

	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IContext _context;

	public ExpensesController(
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
		return OkOrNotFound(await _queryDispatcher.QueryAsync(new GetExpense(id)));
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<LedgerEntryDto>>> GetAllAsync()
	{
		return Ok(await _queryDispatcher.QueryAsync(new GetAllExpensesForUser(_context.Identity.Id)));
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(CreateExpense command)
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
	public async Task<ActionResult> UpdateAsync(UpdateExpense command)
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
		await _commandDispatcher.SendAsync(new DeleteExpense(id));

		return NoContent();
	}
}