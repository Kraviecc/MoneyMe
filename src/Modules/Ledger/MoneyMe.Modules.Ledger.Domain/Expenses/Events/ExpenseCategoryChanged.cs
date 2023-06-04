using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.Expenses.Events;

public record ExpenseCategoryChanged(Expense Expense, Guid CategoryId) : IDomainEvent;