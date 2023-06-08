namespace MoneyMe.Modules.Ledger.Domain.Categories.Consts;

public static class CategoryTypes
{
	public const string Expense = nameof(Expense);
	public const string Income = nameof(Income);

	public static bool IsValid(string categoryType) => categoryType is Expense or Income;
}