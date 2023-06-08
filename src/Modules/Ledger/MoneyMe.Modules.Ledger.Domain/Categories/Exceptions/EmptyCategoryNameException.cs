using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Exceptions;

public class EmptyCategoryNameException : MoneyMeException
{
	public Guid CategoryId { get; }

	public EmptyCategoryNameException(Guid categoryId) : base($"Category with ID: '{categoryId}' defines empty name") =>
		CategoryId = categoryId;
}