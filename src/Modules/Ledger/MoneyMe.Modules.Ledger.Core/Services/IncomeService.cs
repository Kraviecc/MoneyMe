using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Exceptions;
using MoneyMe.Modules.Ledger.Core.Mappings;
using MoneyMe.Modules.Ledger.Core.Models;
using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal class IncomeService : IIncomeService
{
	private readonly IIncomeRepository _incomeRepository;
	private readonly ICategoryRepository _categoryRepository;

	public IncomeService(
		IIncomeRepository incomeRepository,
		ICategoryRepository categoryRepository)
	{
		_incomeRepository = incomeRepository;
		_categoryRepository = categoryRepository;
	}

	public async Task AddAsync(IncomeDto dto)
	{
		dto.Id = Guid.NewGuid();
		await ValidateCategoryAsync(dto.CategoryId);

		await _incomeRepository.AddAsync(
			new Income
			{
				Id = dto.Id,
				InvestmentComponentId = dto.InvestmentComponentId,
				UserId = dto.UserId,
				Name = dto.Name,
				Value = dto.Value,
				CategoryId = dto.CategoryId
			});
	}

	public async Task<IncomeDetailsDto?> GetAsync(Guid id)
	{
		var income = await _incomeRepository.GetAsync(id);

		if (income is null)
		{
			return null;
		}

		var incomeDetailsDto = income.Map<IncomeDetailsDto>();
		incomeDetailsDto.Category = income.Category;

		return incomeDetailsDto;
	}

	public async Task<IReadOnlyList<IncomeDto>> GetAllAsync()
	{
		var incomes = await _incomeRepository.GetAllAsync();

		return incomes
		   .Select(p => p.Map<IncomeDto>())
		   .ToList();
	}

	public async Task UpdateAsync(IncomeDto dto)
	{
		var incomes = await _incomeRepository.GetAsync(dto.Id);

		if (incomes is null)
		{
			throw new IncomeNotFoundException(dto.Id);
		}

		await ValidateCategoryAsync(dto.CategoryId);

		incomes.InvestmentComponentId = dto.InvestmentComponentId;
		incomes.UserId = dto.UserId;
		incomes.Name = dto.Name;
		incomes.Value = dto.Value;
		incomes.CategoryId = dto.CategoryId;

		await _incomeRepository.UpdateAsync(incomes);
	}

	public async Task DeleteAsync(Guid id)
	{
		var income = await _incomeRepository.GetAsync(id);

		if (income is null)
		{
			return;
		}

		await _incomeRepository.DeleteAsync(income);
	}

	private async Task ValidateCategoryAsync(Guid categoryId)
	{
		var category = await _categoryRepository.GetAsync(categoryId);

		if (category is null
			|| category.Type != CategoryType.Income)
		{
			throw new CategoryNotFoundException(categoryId);
		}
	}
}