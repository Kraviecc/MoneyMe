using MoneyMe.Modules.Ledger.Core.DTO;
using MoneyMe.Modules.Ledger.Core.Entities;

namespace MoneyMe.Modules.Ledger.Core.Mappings;

internal static class ExpenseMappings
{
	public static T Map<T>(this Expense expense) where T : ExpenseDto, new() => new()
	{
		Id = expense.Id,
		InvestmentComponentId = expense.InvestmentComponentId,
		UserId = expense.UserId,
		Name = expense.Name,
		Value = expense.Value,
		CategoryId = expense.CategoryId
	};
}