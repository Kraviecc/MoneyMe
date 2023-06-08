using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.Categories.Events;

public record CategoryAdded(Category Category) : IDomainEvent;