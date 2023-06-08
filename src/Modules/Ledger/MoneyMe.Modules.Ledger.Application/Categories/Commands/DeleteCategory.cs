using MoneyMe.Shared.Abstractions.Commands;

namespace MoneyMe.Modules.Ledger.Application.Categories.Commands;

public record DeleteCategory(Guid Id) : ICommand;