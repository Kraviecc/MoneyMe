using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Application.Expenses.Commands;
using MoneyMe.Modules.Ledger.Application.Expenses.Queries;
using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Services;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Contexts;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class ExpensesController : BaseController
{
	private const string Policy = "expenses";

	private readonly IExpenseService _expenseService;
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;
	private readonly IContext _context;

	public ExpensesController(
		IExpenseService expenseService,
		ICommandDispatcher commandDispatcher,
		IQueryDispatcher queryDispatcher,
		IContext context)
	{
		_expenseService = expenseService;
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
		_context = context;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<Application.Expenses.DTO.ExpenseDto>> Get(Guid id)
	{
		return OkOrNotFound(await _queryDispatcher.QueryAsync(new GetExpense(id)));
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<ExpenseDetailsDto>>> GetAllAsync()
	{
		return Ok(await _expenseService.GetAllAsync());
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(CreateExpense command)
	{
		var userCommand = command with { UserId = _context.Identity.Id };
		await _commandDispatcher.SendAsync(userCommand);

		return CreatedAtAction(
			nameof(Get),
			new
			{
				id = userCommand.Id
			},
			null);
	}

	[HttpPut("{id:guid}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> UpdateAsync(Guid id, ExpenseDto dto)
	{
		dto.Id = id;
		dto.UserId = _context.Identity.Id;
		await _expenseService.UpdateAsync(dto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> DeleteAsync(Guid id)
	{
		await _expenseService.DeleteAsync(id);

		return NoContent();
	}
}