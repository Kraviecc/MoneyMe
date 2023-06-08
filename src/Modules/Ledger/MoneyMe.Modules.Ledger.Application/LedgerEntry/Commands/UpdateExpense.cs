using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Commands;

public record UpdateExpense(
	Guid Id,
	ValueChanged<Guid> InvestmentComponentId,
	ValueChanged<string> Name,
	ValueChanged<decimal> Value,
	ValueChanged<DateTime> Date,
	ValueChanged<Guid> CategoryId) : ICommand;