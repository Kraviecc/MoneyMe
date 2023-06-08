using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Events.External;

public record LedgerEntryDeleted(Guid Id) : IEvent;