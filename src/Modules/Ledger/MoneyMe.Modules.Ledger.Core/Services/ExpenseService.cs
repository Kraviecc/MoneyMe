using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Events;
using MoneyMe.Modules.Ledger.Core.Exceptions;
using MoneyMe.Modules.Ledger.Core.Mappings;
using MoneyMe.Modules.Ledger.Core.Models;
using MoneyMe.Modules.Ledger.Core.Repositories;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal class ExpenseService : IExpenseService
{
	private readonly IMessageBroker _messageBroker;
	private readonly IExpenseRepository _expenseRepository;
	private readonly ICategoryRepository _categoryRepository;

	public ExpenseService(
		IMessageBroker messageBroker,
		IExpenseRepository expenseRepository,
		ICategoryRepository categoryRepository)
	{
		_messageBroker = messageBroker;
		_expenseRepository = expenseRepository;
		_categoryRepository = categoryRepository;
	}

	public async Task AddAsync(ExpenseDto dto)
	{
		dto.Id = Guid.NewGuid();
		await ValidateCategoryAsync(dto.CategoryId);

		await _expenseRepository.AddAsync(
			new Expense
			{
				Id = dto.Id,
				InvestmentComponentId = dto.InvestmentComponentId,
				UserId = dto.UserId,
				Name = dto.Name,
				Value = dto.Value,
				CategoryId = dto.CategoryId
			});

		await _messageBroker.PublishAsync(new ExpenseCreated(dto.Id));
	}

	private async Task ValidateCategoryAsync(Guid categoryId)
	{
		var category = await _categoryRepository.GetAsync(categoryId);

		if (category is null
			|| category.Type != CategoryType.Expense)
		{
			throw new CategoryNotFoundException(categoryId);
		}
	}

	public async Task<ExpenseDetailsDto?> GetAsync(Guid id)
	{
		var expense = await _expenseRepository.GetAsync(id);

		if (expense is null)
		{
			return null;
		}

		var expenseDetailsDto = expense.Map<ExpenseDetailsDto>();
		expenseDetailsDto.Category = expense.Category;

		return expenseDetailsDto;
	}

	public async Task<IReadOnlyList<ExpenseDto>> GetAllAsync()
	{
		var expenses = await _expenseRepository.GetAllAsync();

		return expenses
		   .Select(p => p.Map<ExpenseDto>())
		   .ToList();
	}

	public async Task UpdateAsync(ExpenseDto dto)
	{
		var expenses = await _expenseRepository.GetAsync(dto.Id);

		if (expenses is null)
		{
			throw new ExpenseNotFoundException(dto.Id);
		}

		await ValidateCategoryAsync(dto.CategoryId);

		expenses.InvestmentComponentId = dto.InvestmentComponentId;
		expenses.UserId = dto.UserId;
		expenses.Name = dto.Name;
		expenses.Value = dto.Value;
		expenses.CategoryId = dto.CategoryId;

		await _expenseRepository.UpdateAsync(expenses);
	}

	public async Task DeleteAsync(Guid id)
	{
		var expense = await _expenseRepository.GetAsync(id);

		if (expense is null)
		{
			return;
		}

		await _expenseRepository.DeleteAsync(expense);
	}
}