using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.Categories.Exceptions;

public class CannotDeleteCategoryException : MoneyMeException
{
	public Guid CategoryId { get; }

	public CannotDeleteCategoryException(Guid categoryId) : base($"Category with ID {categoryId} cannot be deleted") =>
		CategoryId = categoryId;
}