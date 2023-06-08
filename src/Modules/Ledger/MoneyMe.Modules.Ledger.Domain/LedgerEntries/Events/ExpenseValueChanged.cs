using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;

public record ExpenseValueChanged(Expense Expense, MoneyValue Value) : IDomainEvent;