using MoneyMe.Modules.Ledger.Application.Categories.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Categories.Policies;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands.Handlers;

public sealed class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICategoryDeletionPolicy _categoryDeletionPolicy;

	public DeleteCategoryHandler(
		ICategoryRepository categoryRepository,
		ICategoryDeletionPolicy categoryDeletionPolicy)
	{
		_categoryRepository = categoryRepository;
		_categoryDeletionPolicy = categoryDeletionPolicy;
	}

	public async Task HandleAsync(DeleteCategory command)
	{
		if (!await _categoryDeletionPolicy.CanDeleteAsync(command.Id))
		{
			throw new CannotDeleteCategoryException(command.Id);
		}

		await _categoryRepository.DeleteAsync(command.Id);
	}
}