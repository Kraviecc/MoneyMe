using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands;

public record CreateExpense(
	Guid InvestmentComponentId,
	string Name,
	decimal Value,
	DateTime Date,
	Guid UserId,
	Guid CategoryId) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}