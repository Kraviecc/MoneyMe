using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Events.External;

public record LedgerEntryCreated(Guid Id) : IEvent;