using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Exceptions;

public class WrongCategoryTypeException : MoneyMeException
{
	public Guid CategoryId { get; }

	public string Type { get; }

	public WrongCategoryTypeException(Guid categoryId, string type) : base(
		$"Category with ID: '{categoryId}' defines wrong type: '{type}'")
	{
		CategoryId = categoryId;
		Type = type;
	}
}