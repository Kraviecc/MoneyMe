using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.Categories.Queries;

public record GetCategory(Guid Id) : IQuery<CategoryDto?>;