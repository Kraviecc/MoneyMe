using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands;

public record CreateCategory(
	Guid InvestmentId,
	string Name,
	string Type) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}