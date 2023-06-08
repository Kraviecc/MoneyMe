using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Queries;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetIncomeHandler : IQueryHandler<GetIncome, LedgerEntryDto?>
{
	private readonly LedgerDbContext _context;

	public GetIncomeHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<LedgerEntryDto?> HandleAsync(GetIncome query)
	{
		return await _context.LedgerEntries
		   .AsNoTracking()
		   .OfType<Income>()
		   .Where(p => p.Id.Equals(query.Id))
		   .Select(p => p.AsDto())
		   .SingleOrDefaultAsync();
	}
}