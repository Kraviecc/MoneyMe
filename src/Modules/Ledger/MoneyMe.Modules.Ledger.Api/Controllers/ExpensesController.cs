﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Services;
using MoneyMe.Shared.Abstractions.Contexts;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class ExpensesController : BaseController
{
	private const string Policy = "expenses";
	private readonly IExpenseService _expenseService;
	private readonly IContext _context;

	public ExpensesController(
		IExpenseService expenseService,
		IContext context)
	{
		_expenseService = expenseService;
		_context = context;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<ExpenseDetailsDto?>> Get(Guid id)
	{
		return OkOrNotFound(await _expenseService.GetAsync(id));
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
	public async Task<ActionResult> AddAsync(ExpenseDto dto)
	{
		dto.UserId = _context.Identity.Id;
		await _expenseService.AddAsync(dto);

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