using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.Categories.DTO;
using MoneyMe.Modules.Ledger.Application.Categories.Queries;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetCategoryHandler : IQueryHandler<GetCategory, CategoryDto?>
{
	private readonly LedgerDbContext _context;

	public GetCategoryHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<CategoryDto?> HandleAsync(GetCategory query)
	{
		return await _context.Categories
		   .AsNoTracking()
		   .Where(p => p.Id.Equals(query.Id))
		   .Select(p => p.AsDto())
		   .SingleOrDefaultAsync();
	}
}