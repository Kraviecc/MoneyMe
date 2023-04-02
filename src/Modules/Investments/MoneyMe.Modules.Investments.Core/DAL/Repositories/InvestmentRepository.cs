using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.DAL.Repositories;

internal class InvestmentRepository : IInvestmentRepository
{
	private readonly InvestmentsDbContext _context;
	private readonly DbSet<Investment> _investments;

	public InvestmentRepository(InvestmentsDbContext context)
	{
		_context = context;
		_investments = context.Investments;
	}

	public async Task<Investment?> GetAsync(Guid id) => await _investments
	   .Include(p => p.Components)
	   .SingleOrDefaultAsync(p => p.Id == id);

	public async Task<IReadOnlyList<Investment>> GetAllAsync() => await _investments.ToListAsync();

	public async Task AddAsync(Investment investment)
	{
		await _investments.AddAsync(investment);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Investment investment)
	{
		_investments.Update(investment);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Investment investment)
	{
		_investments.Remove(investment);
		await _context.SaveChangesAsync();
	}
}