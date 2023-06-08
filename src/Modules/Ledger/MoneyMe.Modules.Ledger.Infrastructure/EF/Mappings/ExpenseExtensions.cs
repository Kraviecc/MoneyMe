using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;

internal static class ExpenseExtensions
{
	public static LedgerEntryDto AsDto(this Expense expense)
	{
		return new()
		{
			Id = expense.Id,
			InvestmentComponentId = expense.InvestmentComponentId,
			CategoryId = expense.CategoryId,
			UserId = expense.UserId,
			Name = expense.Name,
			Value = expense.Value,
			Date = expense.Date
		};
	}
}