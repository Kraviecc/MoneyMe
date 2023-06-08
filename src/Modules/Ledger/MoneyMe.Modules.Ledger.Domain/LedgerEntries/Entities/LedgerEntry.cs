using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

public abstract class LedgerEntry : AggregateRoot
{
	public InvestmentComponentId InvestmentComponentId { get; protected set; }

	public CategoryId CategoryId { get; protected set; }

	public UserId UserId { get; protected set; }

	public string Name { get; protected set; }

	public MoneyValue Value { get; protected set; }

	public DateTime Date { get; protected set; }

	protected LedgerEntry(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		CategoryId categoryId,
		UserId userId,
		string name,
		MoneyValue value,
		DateTime date,
		int version = 0) : this(id, investmentComponentId, userId)
	{
		CategoryId = categoryId;
		Name = name;
		Value = value;
		Date = date;
		Version = version;
	}

	protected LedgerEntry(
		AggregateId id,
		InvestmentComponentId investmentComponentId,
		UserId userId) => (Id, InvestmentComponentId, UserId) = (id, investmentComponentId, userId);

	public void ChangeName(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			throw new EmptyLedgerEntryNameException(Id);
		}

		Name = name;
		IncrementVersion();
	}

	public void ChangeInvestmentComponent(InvestmentComponentId investmentComponentId)
	{
		if (investmentComponentId.IsEmpty())
		{
			throw new MissingInvestmentComponentException(Id);
		}

		InvestmentComponentId = investmentComponentId;
		AddEvent(new LedgerEntryMovedToAnotherInvestmentComponent(this, investmentComponentId));
	}

	public void ChangeCategory(CategoryId categoryId)
	{
		CategoryId = categoryId;
		AddEvent(new LedgerEntryCategoryChanged(this, categoryId));
	}

	public void ChangeDate(DateTime date)
	{
		Date = date;
	}
}