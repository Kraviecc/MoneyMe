using MoneyMe.Modules.Ledger.Application.Categories.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Categories.Policies;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands.Handlers;

public sealed class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICategoryModificationPolicy _categoryModificationPolicy;

	public UpdateCategoryHandler(
		ICategoryRepository categoryRepository,
		ICategoryModificationPolicy categoryModificationPolicy)
	{
		_categoryRepository = categoryRepository;
		_categoryModificationPolicy = categoryModificationPolicy;
	}

	public async Task HandleAsync(UpdateCategory command)
	{
		var category = await _categoryRepository.GetAsync(command.Id);

		if (category is null)
		{
			throw new CategoryNotFoundException(command.Id);
		}

		if (command.Name.IsChanged)
		{
			category.ChangeName(command.Name.Value);
		}

		if (command.Type.IsChanged)
		{
			category.ChangeType(command.Type.Value);
		}

		if (!await _categoryModificationPolicy.CanUseAsync(category))
		{
			throw new CannotModifyCategoryException(category.Id);
		}

		await _categoryRepository.UpdateAsync(category);
	}
}