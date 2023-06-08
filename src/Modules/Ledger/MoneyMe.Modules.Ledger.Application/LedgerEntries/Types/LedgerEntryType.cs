using MoneyMe.Modules.Ledger.Application.LedgerEntries.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Types;

public static class LedgerEntryType
{
	public const string Expense = "expense";
	public const string Income = "income";

	public static string GetLedgerEntryType(object entry) => entry switch
	{
		Domain.LedgerEntries.Entities.Expense => Expense,
		Domain.LedgerEntries.Entities.Income => Income,
		_ => throw new LedgerEntryTypeNotFoundException(entry.GetType().Name)
	};
}