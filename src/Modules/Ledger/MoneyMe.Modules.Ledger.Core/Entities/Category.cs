using MoneyMe.Modules.Ledger.Core.Models;

namespace MoneyMe.Modules.Ledger.Core.Entities;

internal class Category
{
	public Guid Id { get; set; }

	public Guid InvestmentId { get; set; }

	public string Name { get; set; }

	public CategoryType Type { get; set; }

	public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();

	public IEnumerable<Income> Incomes { get; set; } = new List<Income>();

	public bool HasAnyRelatedItem()
	{
		return Expenses.Any() || Incomes.Any();
	}
}