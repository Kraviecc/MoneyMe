using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

public sealed class Expense : LedgerEntry
{
	public Expense(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		CategoryId categoryId,
		UserId userId,
		string name,
		MoneyValue value,
		DateTime date,
		int version = 0) : base(
		id,
		investmentComponentId,
		categoryId,
		userId,
		name,
		value,
		date,
		version) { }

	public Expense(AggregateId id, InvestmentComponentId investmentComponentId, UserId userId) : base(
		id,
		investmentComponentId,
		userId) { }

	public static Expense Create(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		CategoryId categoryId,
		UserId userId,
		string name,
		decimal value,
		DateTime date)
	{
		var expense = new Expense(id, investmentComponentId, userId)
		{
			Date = date
		};

		expense.ChangeName(name);
		expense.ChangeValue(value);
		expense.ChangeCategory(categoryId);
		expense.ReinitAggregate();

		expense.AddEvent(new ExpenseAdded(expense));

		return expense;
	}

	public void ChangeValue(MoneyValue value)
	{
		if (!value.HasValue || value.IsZeroValue)
		{
			throw new ZeroLedgerEntryValueException(Id);
		}

		Value = value;
		AddEvent(new ExpenseValueChanged(this, value));
	}
}