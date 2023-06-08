using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;

namespace MoneyMe.Modules.Ledger.Infrastructure.EF.Mappings;

internal static class IncomeExtensions
{
	public static LedgerEntryDto AsDto(this Income income)
	{
		return new()
		{
			Id = income.Id,
			InvestmentComponentId = income.InvestmentComponentId,
			CategoryId = income.CategoryId,
			UserId = income.UserId,
			Name = income.Name,
			Value = income.Value,
			Date = income.Date
		};
	}
}