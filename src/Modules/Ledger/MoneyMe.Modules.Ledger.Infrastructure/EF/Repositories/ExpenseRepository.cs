using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.Expenses.Entities;
using MoneyMe.Modules.Ledger.Domain.Expenses.Repositories;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Repositories;

internal sealed class ExpenseRepository : IExpenseRepository
{
	private readonly ExpensesDbContext _context;

	public ExpenseRepository(ExpensesDbContext context)
	{
		_context = context;
	}

	public async Task<Expense?> GetAsync(AggregateId id)
	{
		return await _context.Expenses
		   .Where(p => p.Id.Equals(id))
		   .SingleOrDefaultAsync();
	}

	public async Task AddAsync(Expense expense)
	{
		await _context.Expenses.AddAsync(expense);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Expense expense)
	{
		_context.Update(expense);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(AggregateId id)
	{
		await _context.Expenses
		   .Where(p => p.Id.Equals(id))
		   .ExecuteDeleteAsync();
	}
}