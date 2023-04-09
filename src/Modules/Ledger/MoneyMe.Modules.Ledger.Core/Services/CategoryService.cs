using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Exceptions;
using MoneyMe.Modules.Ledger.Core.Policies;
using MoneyMe.Modules.Ledger.Core.Policies.Category;
using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICategoryDeletionPolicy _categoryDeletionPolicy;

	public CategoryService(
		ICategoryRepository categoryRepository,
		ICategoryDeletionPolicy categoryDeletionPolicy)
	{
		_categoryRepository = categoryRepository;
		_categoryDeletionPolicy = categoryDeletionPolicy;
	}

	public async Task AddAsync(CategoryDto dto)
	{
		dto.Id = Guid.NewGuid();
		await _categoryRepository.AddAsync(
			new Category
			{
				Id = dto.Id,
				InvestmentId = dto.InvestmentId,
				Name = dto.Name,
				Type = dto.Type
			});
	}

	public async Task<CategoryDetailsDto?> GetAsync(Guid id)
	{
		var category = await _categoryRepository.GetAsync(id);

		if (category is null)
		{
			return null;
		}

		var dto = Map<CategoryDetailsDto>(category);
		dto.Expenses = category.Expenses
		   .Select(
				p => new ExpenseDto
				{
					Id = p.Id,
					Name = p.Name
				})
		   .ToList();

		dto.Incomes = category.Incomes
		   .Select(
				p => new IncomeDto
				{
					Id = p.Id,
					Name = p.Name
				})
		   .ToList();

		return dto;
	}

	public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
	{
		var categories = await _categoryRepository.GetAllAsync();

		return categories
		   .Select(Map<CategoryDto>)
		   .ToList();
	}

	public async Task UpdateAsync(CategoryDto dto)
	{
		var category = await _categoryRepository.GetAsync(dto.Id);

		if (category is null)
		{
			throw new CategoryNotFoundException(dto.Id);
		}

		category.InvestmentId = dto.InvestmentId;
		category.Name = dto.Name;
		category.Type = dto.Type;
		await _categoryRepository.UpdateAsync(category);
	}

	public async Task DeleteAsync(Guid id)
	{
		var category = await _categoryRepository.GetAsync(id);

		if (category is null)
		{
			return;
		}

		if (await _categoryDeletionPolicy.CanDeleteAsync(category) is false)
		{
			throw new CannotDeleteCategoryException(id, 11);
		}

		await _categoryRepository.DeleteAsync(category);
	}

	private static T Map<T>(Category category) where T : CategoryDto, new() => new()
	{
		Id = category.Id,
		InvestmentId = category.InvestmentId,
		Name = category.Name,
		Type = category.Type
	};
}