using MoneyMe.Shared.Abstractions.Events;

namespace MoneyMe.Modules.Investments.Core.Events;

public record ExpenseCreated(Guid Id) : IEvent;