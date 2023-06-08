using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Events.External;

public record ExpenseCreated(Guid Id) : IEvent;