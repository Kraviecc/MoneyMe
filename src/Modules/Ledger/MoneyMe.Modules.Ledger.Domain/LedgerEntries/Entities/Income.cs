using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

public sealed class Income : LedgerEntry
{
	public Income(
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

	public Income(AggregateId id, InvestmentComponentId investmentComponentId, UserId userId) : base(
		id,
		investmentComponentId,
		userId) { }

	public static Income Create(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		CategoryId categoryId,
		UserId userId,
		string name,
		decimal value,
		DateTime date)
	{
		var income = new Income(id, investmentComponentId, userId)
		{
			Date = date
		};

		income.ChangeName(name);
		income.ChangeValue(value);
		income.ChangeCategory(categoryId);
		income.ReinitAggregate();

		income.AddEvent(new IncomeAdded(income));

		return income;
	}

	public void ChangeValue(MoneyValue value)
	{
		if (!value.HasValue || value.IsZeroValue)
		{
			throw new ZeroLedgerEntryValueException(Id);
		}

		Value = value;
		AddEvent(new IncomeValueChanged(this, value));
	}
}