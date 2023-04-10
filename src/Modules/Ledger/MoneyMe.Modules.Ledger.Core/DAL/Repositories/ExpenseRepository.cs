using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Core.Entities;
using MoneyMe.Modules.Ledger.Core.Repositories;

namespace MoneyMe.Modules.Ledger.Core.DAL.Repositories;

internal class ExpenseRepository : IExpenseRepository
{
	private readonly LedgerDbContext _context;
	private readonly DbSet<Expense> _expenses;

	public ExpenseRepository(LedgerDbContext context)
	{
		_context = context;
		_expenses = context.Expenses;
	}

	public async Task<Expense?> GetAsync(Guid id) => await _expenses
	   .Include(p => p.Category)
	   .SingleOrDefaultAsync(p => p.Id == id);

	public async Task<IReadOnlyList<Expense>> GetAllAsync() => await _expenses.ToListAsync();

	public async Task AddAsync(Expense category)
	{
		await _expenses.AddAsync(category);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Expense category)
	{
		_expenses.Update(category);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Expense category)
	{
		_expenses.Remove(category);
		await _context.SaveChangesAsync();
	}

	public async Task<Expense?> Get(string name)
	{
		return await _expenses
		   .FirstOrDefaultAsync(p => p.Name == name);
	}
}