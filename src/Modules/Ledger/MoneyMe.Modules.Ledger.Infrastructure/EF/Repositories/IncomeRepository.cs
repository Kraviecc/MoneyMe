using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Repositories;

internal sealed class IncomeRepository : IIncomeRepository
{
	private readonly LedgerDbContext _context;

	public IncomeRepository(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<Income?> GetAsync(AggregateId id)
	{
		return await _context.LedgerEntries
		   .OfType<Income>()
		   .Where(p => p.Id.Equals(id))
		   .SingleOrDefaultAsync();
	}

	public async Task AddAsync(Income income)
	{
		await _context.LedgerEntries.AddAsync(income);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Income income)
	{
		_context.Update(income);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(AggregateId id)
	{
		await _context.LedgerEntries
		   .Where(p => p.Id.Equals(id))
		   .ExecuteDeleteAsync();
	}
}