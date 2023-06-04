using MoneyMe.Modules.Ledger.Domain.Expenses.Events;
using MoneyMe.Modules.Ledger.Domain.Expenses.Exceptions;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Entities;

public sealed class Expense : AggregateRoot
{
	public InvestmentComponentId InvestmentComponentId { get; private set; }

	public Guid CategoryId { get; private set; }

	public Guid UserId { get; private set; }

	public string Name { get; private set; }

	public decimal Value { get; private set; }

	public Expense(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		Guid categoryId,
		Guid userId,
		string name,
		decimal value,
		int version = 0) : this(id, investmentComponentId)
	{
		CategoryId = categoryId;
		UserId = userId;
		Name = name;
		Value = value;
		Version = version;
	}

	public Expense(AggregateId id, InvestmentComponentId investmentComponentId) =>
		(Id, InvestmentComponentId) = (id, investmentComponentId);

	public static Expense Create(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		Guid categoryId,
		Guid userId,
		string name,
		decimal value)
	{
		var expense = new Expense(id, investmentComponentId);
		expense.ChangeName(name);
		expense.ChangeValue(value);
		expense.ChangeCategory(categoryId);
		expense.ChangeUserId(userId);
		expense.ReinitAggregate();

		expense.AddEvent(new ExpenseAdded(expense));

		return expense;
	}

	public void ChangeName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new EmptyExpenseNameException(Id);
		}

		Name = name;
		IncrementVersion();
	}

	public void ChangeValue(decimal value)
	{
		if (value == 0)
		{
			throw new ZeroExpenseValueException(Id);
		}

		Value = value;
		AddEvent(new ExpenseValueChanged(this, value));
	}

	public void ChangeCategory(Guid categoryId)
	{
		CategoryId = categoryId;
		AddEvent(new ExpenseCategoryChanged(this, categoryId));
	}

	public void ChangeUserId(Guid userId)
	{
		if (userId == Guid.Empty)
		{
			throw new MissingExpenseUserException(Id);
		}

		UserId = userId;
		IncrementVersion();
	}
}