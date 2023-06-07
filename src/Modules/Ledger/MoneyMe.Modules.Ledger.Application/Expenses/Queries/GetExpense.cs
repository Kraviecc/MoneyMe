using MoneyMe.Modules.Ledger.Application.Expenses.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Queries;

public record GetExpense(Guid Id) : IQuery<ExpenseDto>;