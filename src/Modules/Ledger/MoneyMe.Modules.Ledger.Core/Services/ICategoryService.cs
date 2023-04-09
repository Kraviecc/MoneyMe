using MoneyMe.Modules.Ledger.Core.DTO;

namespace MoneyMe.Modules.Ledger.Core.Services;

internal interface ICategoryService
{
	Task AddAsync(CategoryDto dto);

	Task<CategoryDetailsDto?> GetAsync(Guid id);

	Task<IReadOnlyList<CategoryDto>> GetAllAsync();

	Task UpdateAsync(CategoryDto dto);

	Task DeleteAsync(Guid id);
}