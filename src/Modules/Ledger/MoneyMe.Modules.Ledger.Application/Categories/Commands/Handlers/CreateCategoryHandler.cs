using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands.Handlers;

public sealed class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
	private readonly ICategoryRepository _categoryRepository;

	public CreateCategoryHandler(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task HandleAsync(CreateCategory command)
	{
		var category = Category.Create(
			command.Id,
			command.InvestmentId,
			command.Name,
			command.Type);

		await _categoryRepository.AddAsync(category);
	}
}