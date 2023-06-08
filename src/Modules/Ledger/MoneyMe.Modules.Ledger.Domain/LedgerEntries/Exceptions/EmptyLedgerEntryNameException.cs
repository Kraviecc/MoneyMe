using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;

public class EmptyLedgerEntryNameException : MoneyMeException
{
	public Guid LedgerEntryId { get; }

	public EmptyLedgerEntryNameException(Guid ledgerEntryId) : base(
		$"Ledger entry with ID: '{ledgerEntryId}' defines empty name") => LedgerEntryId = ledgerEntryId;
}