using MoneyMe.Modules.Ledger.Application.LedgerEntry.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntry.Queries;

public record GetIncome(Guid Id) : IQuery<LedgerEntryDto?>;