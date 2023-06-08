using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Exceptions;

public class LedgerEntryTypeNotFoundException : MoneyMeException
{
	private readonly string _typeName;

	public LedgerEntryTypeNotFoundException(string typeName) : base(
		$"Ledger entry type mapping not found for type {typeName}") => _typeName = typeName;
}