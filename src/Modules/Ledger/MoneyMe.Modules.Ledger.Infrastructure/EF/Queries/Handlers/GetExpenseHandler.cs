using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetExpenseHandler : IQueryHandler<GetExpense, LedgerEntryDto?>
{
	private readonly LedgerDbContext _context;

	public GetExpenseHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<LedgerEntryDto?> HandleAsync(GetExpense query)
	{
		return await _context.LedgerEntries
		   .AsNoTracking()
		   .OfType<Expense>()
		   .Where(p => p.Id.Equals(query.Id))
		   .Select(p => p.AsDto())
		   .SingleOrDefaultAsync();
	}
}