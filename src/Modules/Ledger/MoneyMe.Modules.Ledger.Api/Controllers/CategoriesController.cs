using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Application.Categories.Commands;
using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Modules.Ledger.Application.Categories.Queries;
using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class CategoriesController : BaseController
{
	private const string Policy = "categories";
	private readonly ICommandDispatcher _commandDispatcher;
	private readonly IQueryDispatcher _queryDispatcher;

	public CategoriesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
	{
		_commandDispatcher = commandDispatcher;
		_queryDispatcher = queryDispatcher;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<CategoryDto?>> Get(Guid id)
	{
		return OkOrNotFound(await _queryDispatcher.QueryAsync(new GetCategory(id)));
	}

	[HttpGet("{type:required}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<CategoryDto>?>> GetAllByTypeAsync(string type)
	{
		return OkOrNotFound(await _queryDispatcher.QueryAsync(new GetCategoriesByType(type)));
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(CreateCategory command)
	{
		await _commandDispatcher.SendAsync(command);

		return CreatedAtAction(
			nameof(Get),
			new
			{
				id = command.Id
			},
			null);
	}

	[HttpPut]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> UpdateAsync(UpdateCategory command)
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
		await _commandDispatcher.SendAsync(new DeleteCategory(id));

		return NoContent();
	}
}