using MoneyMe.Shared.Abstractions.Kernel;
using MoneyMe.Shared.Abstractions.Messaging;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Services;

public interface IEventMapper
{
    IMessage Map(IDomainEvent @event);
    IEnumerable<IMessage> MapAll(IEnumerable<IDomainEvent> events);
}