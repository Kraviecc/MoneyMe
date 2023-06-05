using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Expenses.Commands;

public record CreateExpense(
    Guid InvestmentComponentId,
    string Name,
    decimal Value,
    Guid UserId,
    Guid CategoryId) : ICommand
{
    public Guid Id { get; } = Guid.NewGuid();
}