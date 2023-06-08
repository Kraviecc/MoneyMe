using MoneyMe.Modules.Ledger.Domain.LedgerEntries.Entities;
using MoneyMe.Modules.Ledger.Domain.Types;
using MoneyMe.Shared.Abstractions.Kernel;

namespace MoneyMe.Modules.Ledger.Domain.LedgerEntries.Events;

public record LedgerEntryMovedToAnotherInvestmentComponent(
	LedgerEntry LedgerEntry,
	InvestmentComponentId InvestmentComponentId) : IDomainEvent;