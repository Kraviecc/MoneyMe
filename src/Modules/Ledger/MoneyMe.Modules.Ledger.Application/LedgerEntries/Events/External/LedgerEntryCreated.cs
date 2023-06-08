using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Events.External;

public record LedgerEntryCreated(Guid Id) : IEvent;