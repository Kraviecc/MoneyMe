using MoneyMe.Modules.Ledger.Core.DTO;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal interface IExpenseService
{
	Task AddAsync(ExpenseDto dto);

	Task<ExpenseDetailsDto?> GetAsync(Guid id);

	Task<IReadOnlyList<ExpenseDto>> GetAllAsync();

	Task UpdateAsync(ExpenseDto dto);

	Task DeleteAsync(Guid id);
}