using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;

public class ZeroLedgerEntryValueException : MoneyMeException
{
	public Guid LedgerEntryId { get; }

	public ZeroLedgerEntryValueException(Guid ledgerEntryId) : base(
		$"Ledger entry with ID: '{ledgerEntryId}' defines 0 value") => LedgerEntryId = ledgerEntryId;
}