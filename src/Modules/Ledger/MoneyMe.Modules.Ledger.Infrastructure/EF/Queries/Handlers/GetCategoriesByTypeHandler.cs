using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Modules.Ledger.Application.Categories.Queries;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetCategoriesByTypeHandler : IQueryHandler<GetCategoriesByType, IReadOnlyList<CategoryDto>>
{
	private readonly ICategoryRepository _categoryRepository;

	public GetCategoriesByTypeHandler(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<IReadOnlyList<CategoryDto>> HandleAsync(GetCategoriesByType query)
	{
		return (await _categoryRepository
			   .GetAllByTypeAsync(query.Type))
		   .Select(p => p.AsDto())
		   .ToArray();
	}
}