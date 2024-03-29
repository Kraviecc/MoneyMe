﻿using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Repositories;
using MoneyMe.Shared.Abstractions.Kernel.Types;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Repositories;

internal sealed class ExpenseRepository : IExpenseRepository
{
	private readonly LedgerDbContext _context;

	public ExpenseRepository(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<Expense?> GetAsync(AggregateId id)
	{
		return await _context.LedgerEntries
		   .OfType<Expense>()
		   .Where(p => p.Id.Equals(id))
		   .SingleOrDefaultAsync();
	}

	public async Task AddAsync(Expense expense)
	{
		await _context.LedgerEntries.AddAsync(expense);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Expense expense)
	{
		_context.Update(expense);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(AggregateId id)
	{
		await _context.LedgerEntries
		   .Where(p => p.Id.Equals(id))
		   .ExecuteDeleteAsync();
	}
}