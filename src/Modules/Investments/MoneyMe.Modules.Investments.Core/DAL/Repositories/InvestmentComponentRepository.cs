using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Investments.Core.Entities;
using MoneyMe.Modules.Investments.Core.Repositories;

namespace MoneyMe.Modules.Investments.Core.DAL.Repositories;

internal class InvestmentComponentRepository : IInvestmentComponentRepository
{
	private readonly InvestmentsDbContext _context;
	private readonly DbSet<InvestmentComponent> _investmentComponents;

	public InvestmentComponentRepository(InvestmentsDbContext context)
	{
		_context = context;
		_investmentComponents = context.InvestmentComponents;
	}

	public async Task<InvestmentComponent?> GetAsync(Guid id) => await _investmentComponents
	   .Include(p => p.Investment)
	   .SingleOrDefaultAsync(p => p.Id == id);

	public async Task<IReadOnlyList<InvestmentComponent>> GetAllAsync() => await _investmentComponents.ToListAsync();

	public async Task AddAsync(InvestmentComponent investmentComponent)
	{
		await _investmentComponents.AddAsync(investmentComponent);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(InvestmentComponent investmentComponent)
	{
		_investmentComponents.Update(investmentComponent);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(InvestmentComponent investmentComponent)
	{
		_investmentComponents.Remove(investmentComponent);
		await _context.SaveChangesAsync();
	}
}