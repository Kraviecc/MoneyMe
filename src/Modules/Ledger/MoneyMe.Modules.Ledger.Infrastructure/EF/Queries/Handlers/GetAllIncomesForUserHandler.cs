using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetAllIncomesForUserHandler : IQueryHandler<GetAllIncomesForUser, IEnumerable<LedgerEntryDto>>
{
	private readonly LedgerDbContext _context;

	public GetAllIncomesForUserHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<LedgerEntryDto>> HandleAsync(GetAllIncomesForUser query)
	{
		return await _context.LedgerEntries
		   .AsNoTracking()
		   .OfType<Income>()
		   .Where(p => p.UserId.Equals(query.UserId))
		   .Select(p => p.AsDto())
		   .ToArrayAsync();
	}
}