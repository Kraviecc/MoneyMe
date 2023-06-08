using MoneyMe.Modules.Ledger.Application.LedgerEntries.DTO;
using MoneyMe.Shared.Abstractions.Queries;

namespace MoneyMe.Modules.Ledger.Application.LedgerEntries.Queries;

public record GetAllIncomesForUser(Guid UserId) : IQuery<IEnumerable<LedgerEntryDto>>;