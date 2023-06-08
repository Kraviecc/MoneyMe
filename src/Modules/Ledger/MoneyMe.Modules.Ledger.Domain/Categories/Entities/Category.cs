using MoneyMe.Modules.Ledger.Domain.Categories.Consts;
using MoneyMe.Modules.Ledger.Domain.Categories.Events;
using MoneyMe.Modules.Ledger.Domain.Categories.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Entities;

public class Category : AggregateRoot
{
	public InvestmentId InvestmentId { get; set; }

	public string Name { get; set; }

	public CategoryType Type { get; set; }

	public Category(
		AggregateId id,
		InvestmentId investmentId,
		string name,
		CategoryType type)
	{
		Id = id;
		InvestmentId = investmentId;
		Name = name;
		Type = type;
	}

	public Category(AggregateId id, InvestmentId investmentId) => (Id, InvestmentId) = (id, investmentId);

	public static Category Create(
		AggregateId id,
		InvestmentId investmentId,
		string name,
		string type)
	{
		var category = new Category(id, investmentId);

		category.ChangeName(name);
		category.ChangeType(type);

		category.AddEvent(new CategoryAdded(category));

		return category;
	}

	public void ChangeName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new EmptyCategoryNameException(Id);
		}

		Name = name;
	}

	public void ChangeType(string type)
	{
		if (!CategoryTypes.IsValid(type))
		{
			throw new WrongCategoryTypeException(Id, type);
		}

		Type = type;
	}
}