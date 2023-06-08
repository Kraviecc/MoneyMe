using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.Categories.Exceptions;

public class CannotModifyCategoryException : MoneyMeException
{
	public Guid CategoryId { get; }

	public CannotModifyCategoryException(Guid categoryId) : base($"Category with ID {categoryId} cannot be modified") =>
		CategoryId = categoryId;
}