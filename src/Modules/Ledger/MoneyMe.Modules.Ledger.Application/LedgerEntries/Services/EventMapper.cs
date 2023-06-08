using MoneyMe.Modules.Ledger.Application.LedgerEntries.Events.External;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;
using MoneyMe.Shared.Abstractions.Kernel;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Services;

public class EventMapper : IEventMapper
{
	public IMessage Map(IDomainEvent @event) => @event switch
	{
		ExpenseAdded expenseAdded => new LedgerEntryCreated(expenseAdded.Expense.Id),
		IncomeAdded incomeAdded => new LedgerEntryCreated(incomeAdded.Income.Id)
	};

	public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> events) => events.Select(Map);
}