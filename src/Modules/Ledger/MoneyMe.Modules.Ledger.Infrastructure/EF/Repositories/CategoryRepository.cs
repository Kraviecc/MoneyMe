using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.Categories.Entities;
using MoneyMe.Modules.Ledger.Domain.Categories.Repositories;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
	private readonly LedgerDbContext _context;

	public CategoryRepository(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<Category?> GetAsync(AggregateId id)
	{
		return await _context.Categories
		   .Where(p => p.Id.Equals(id))
		   .SingleOrDefaultAsync();
	}

	public async Task<IReadOnlyList<Category>> GetAllByTypeAsync(CategoryType categoryType)
	{
		return await _context.Categories
		   .Where(p => p.Type.Equals(categoryType))
		   .ToArrayAsync();
	}

	public async Task<Category?> GetByNameAsync(string name)
	{
		return await _context.Categories
		   .Where(p => p.Name == name)
		   .FirstOrDefaultAsync();
	}

	public async Task AddAsync(Category category)
	{
		await _context.Categories.AddAsync(category);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Category category)
	{
		_context.Update(category);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(AggregateId id)
	{
		await _context.Categories
		   .Where(p => p.Id.Equals(id))
		   .ExecuteDeleteAsync();
	}
}