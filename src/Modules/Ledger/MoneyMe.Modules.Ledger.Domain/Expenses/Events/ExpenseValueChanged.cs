using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Events;

public record ExpenseValueChanged(Expense Expense, decimal Value) : IDomainEvent;