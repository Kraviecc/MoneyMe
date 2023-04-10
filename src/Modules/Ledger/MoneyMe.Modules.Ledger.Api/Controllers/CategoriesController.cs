using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Services;

namespace MoneyMe.Modules.Ledger.Api.Controllers;

[Authorize(Policy)]
internal class CategoriesController : BaseController
{
	private const string Policy = "categories";
	private readonly ICategoryService _categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		_categoryService = categoryService;
	}

	[HttpGet("{id:guid}")]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	[ProducesResponseType(404)]
	public async Task<ActionResult<CategoryDetailsDto?>> Get(Guid id)
	{
		return OkOrNotFound(await _categoryService.GetAsync(id));
	}

	[HttpGet]
	[ProducesResponseType(200)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult<IReadOnlyList<CategoryDetailsDto>>> GetAllAsync()
	{
		return Ok(await _categoryService.GetAllAsync());
	}

	[HttpPost]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> AddAsync(CategoryDto dto)
	{
		await _categoryService.AddAsync(dto);

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
	public async Task<ActionResult> UpdateAsync(Guid id, CategoryDto dto)
	{
		dto.Id = id;
		await _categoryService.UpdateAsync(dto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	[ProducesResponseType(401)]
	[ProducesResponseType(403)]
	public async Task<ActionResult> DeleteAsync(Guid id)
	{
		await _categoryService.DeleteAsync(id);

		return NoContent();
	}
}