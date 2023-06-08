using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.Categories.Queries;

public record GetCategoriesByType(string Type) : IQuery<IReadOnlyList<CategoryDto>>;