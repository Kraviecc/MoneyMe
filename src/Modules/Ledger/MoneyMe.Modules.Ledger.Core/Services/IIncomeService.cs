using MoneyMe.Modules.Ledger.Core.DTO;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal interface IIncomeService
{
	Task AddAsync(IncomeDto dto);

	Task<IncomeDetailsDto?> GetAsync(Guid id);

	Task<IReadOnlyList<IncomeDto>> GetAllAsync();

	Task UpdateAsync(IncomeDto dto);

	Task DeleteAsync(Guid id);
}