using MoneyMe.Modules.Investments.Core.DTO;

namespace MoneyMe.Modules.Investments.Core.Services;

internal interface IInvestmentService
{
	Task AddAsync(InvestmentDto dto);

	Task<InvestmentDetailsDto?> GetAsync(Guid id);

	Task<IReadOnlyList<InvestmentDto>> GetAllAsync();

	Task UpdateAsync(InvestmentDto dto);

	Task DeleteAsync(Guid id);
}