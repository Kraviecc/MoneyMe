using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;

public record ExpenseAdded(Expense Expense) : IDomainEvent;