using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.DAL.Repositories;

internal class IncomeRepository : IIncomeRepository
{
	private readonly LedgerDbContext _context;
	private readonly DbSet<Income> _incomes;

	public IncomeRepository(LedgerDbContext context)
	{
		_context = context;
		_incomes = context.Incomes;
	}

	public async Task<Income?> GetAsync(Guid id) => await _incomes
	   .Include(p => p.Category)
	   .SingleOrDefaultAsync(p => p.Id == id);

	public async Task<IReadOnlyList<Income>> GetAllAsync() => await _incomes.ToListAsync();

	public async Task AddAsync(Income category)
	{
		await _incomes.AddAsync(category);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Income category)
	{
		_incomes.Update(category);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Income category)
	{
		_incomes.Remove(category);
		await _context.SaveChangesAsync();
	}

	public async Task<Income?> Get(string name)
	{
		return await _incomes
		   .FirstOrDefaultAsync(p => p.Name == name);
	}
}