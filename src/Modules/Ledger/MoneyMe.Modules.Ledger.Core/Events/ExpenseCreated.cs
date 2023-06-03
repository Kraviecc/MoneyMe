using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Ledger.Core.Events;

public record ExpenseCreated(Guid Id) : IEvent;