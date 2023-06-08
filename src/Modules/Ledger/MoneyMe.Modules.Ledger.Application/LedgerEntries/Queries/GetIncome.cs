using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;

public record GetIncome(Guid Id) : IQuery<LedgerEntryDto?>;