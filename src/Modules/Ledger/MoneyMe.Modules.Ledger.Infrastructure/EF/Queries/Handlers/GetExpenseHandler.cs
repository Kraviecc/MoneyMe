using Microsoft.EntityFrameworkCore;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Modules.Ledger.Application.LedgerEntry.Queries;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Queries.Handlers;

internal sealed class GetExpenseHandler : IQueryHandler<GetExpense, ExpenseDto>
{
	private readonly LedgerDbContext _context;

	public GetExpenseHandler(LedgerDbContext context)
	{
		_context = context;
	}

	public async Task<ExpenseDto> HandleAsync(GetExpense query)
	{
		return await _context.LedgerEntries
		   .AsNoTracking()
		   .Where(p => p.Id.Equals(query.Id))
		   .Select(
				p => new ExpenseDto
				{
					Id = p.Id,
					InvestmentComponentId = p.InvestmentComponentId,
					CategoryId = p.CategoryId,
					UserId = p.UserId,
					Name = p.Name,
					Value = p.Value
				})
		   .SingleOrDefaultAsync();
	}
}