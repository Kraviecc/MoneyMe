using MoneyMe.Shared.Abstractions.Commands;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands;

public record UpdateCategory(
	Guid Id,
	ValueChanged<string> Name,
	ValueChanged<string> Type) : ICommand;