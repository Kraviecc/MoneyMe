using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Events.External;

public record ExpenseCreated(Guid Id) : IEvent;