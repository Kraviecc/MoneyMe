using MoneyMe.Shared.Abstractions.Exceptions;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Exceptions;

public class MissingInvestmentComponentException : MoneyMeException
{
	public Guid LedgerEntryId { get; }

	public MissingInvestmentComponentException(Guid ledgerEntryId) : base(
		$"Ledger entry with ID: '{ledgerEntryId}' defines empty investment component") => LedgerEntryId = ledgerEntryId;
}