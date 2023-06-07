using MoneyMe.Modules.Ledger.Application.Expenses.Events.External;
using MoneyMe.Modules.Ledger.Domain.Expenses.Events;
using MoneyMe.Shared.Abstractions.Kernel;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Services;

public class EventMapper : IEventMapper
{
    public IMessage Map(IDomainEvent @event) =>
        @event switch
        {
            ExpenseAdded expenseAdded => new ExpenseCreated(expenseAdded.Expense.Id),
            ExpenseCategoryChanged expenseCategoryChanged => throw new NotImplementedException(),
            ExpenseValueChanged expenseValueChanged => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(@event))
        };

    public IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> events) =>
        events.Select(Map);
}