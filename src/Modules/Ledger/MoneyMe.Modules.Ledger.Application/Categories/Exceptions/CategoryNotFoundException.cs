using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.Categories.Exceptions;

public class CategoryNotFoundException : MoneyMeException
{
	public Guid CategoryId { get; }

	public CategoryNotFoundException(Guid categoryId) : base($"Category not found for ID {categoryId}") =>
		CategoryId = categoryId;
}