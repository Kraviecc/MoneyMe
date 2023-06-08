using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Queries;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetAllExpensesForUserHandler : IQueryHandler<GetAllExpensesForUser, IEnumerable<LedgerEntryDto>>
{
	private readonly LedgerDbContext _context;

	public GetAllExpensesForUserHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<LedgerEntryDto>> HandleAsync(GetAllExpensesForUser query)
	{
		return await _context.LedgerEntries
		   .AsNoTracking()
		   .OfType<Expense>()
		   .Where(p => p.UserId.Equals(query.UserId))
		   .Select(p => p.AsDto())
		   .ToArrayAsync();
	}
}