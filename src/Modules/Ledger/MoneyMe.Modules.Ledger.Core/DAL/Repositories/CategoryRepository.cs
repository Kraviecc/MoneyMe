using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.DAL.Repositories;

internal class CategoryRepository : ICategoryRepository
{
	private readonly LedgerDbContext _context;
	private readonly DbSet<Category> _categories;

	public CategoryRepository(LedgerDbContext context)
	{
		_context = context;
		_categories = context.Categories;
	}

	public async Task<Category?> GetAsync(Guid id) => await _categories
	   .Include(p => p.Expenses)
	   .Include(p => p.Incomes)
	   .SingleOrDefaultAsync(p => p.Id == id);

	public async Task<IReadOnlyList<Category>> GetAllAsync() => await _categories.ToListAsync();

	public async Task AddAsync(Category category)
	{
		await _categories.AddAsync(category);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Category category)
	{
		_categories.Update(category);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Category category)
	{
		_categories.Remove(category);
		await _context.SaveChangesAsync();
	}

	public async Task<Category?> GetByNameAsync(string name)
	{
		return await _categories
		   .FirstOrDefaultAsync(p => p.Name == name);
	}
}