using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.Mappings;

internal static class IncomeMappings
{
	public static T Map<T>(this Income income) where T : IncomeDto, new() => new()
	{
		Id = income.Id,
		InvestmentComponentId = income.InvestmentComponentId,
		UserId = income.UserId,
		Name = income.Name,
		Value = income.Value,
		CategoryId = income.CategoryId
	};
}